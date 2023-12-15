using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;

namespace WinFileHistory
{
    public class ClsTaskRuning : System.IDisposable
    {
        internal const string SC_PIPE_NAME_CISO = "IMK_FILE_HISTORY_CISO";
        internal const string SC_PIPE_NAME_COSI = "IMK_FILE_HISTORY_COSI";
        internal const string SC_CMD_REFRESH_CONFIG = "refresh_config";
        internal const string SC_CMD_MANUAL_BACKUP = "manual_backup";
        internal const string SC_CMD_MANUAL_CLEAN = "manual_clean";
        internal const string SC_CMD_SYNC_WORK_STARTING = "sync:work_starting";
        internal const string SC_CMD_SYNC_WORK_COMPLETED = "sync:work_completed";

        public event TaskItemStartHandler OnTaskItemStart;
        public event TaskItemCompletedHandler OnTaskItemCompleted;
        public event TaskHandler OnAllTaskStart;
        public event TaskHandler OnAllTaskCompleted;

        private System.Threading.Thread thTasks;
        private bool m_runing;
        private bool m_working;
        private bool m_log;
        public bool runingLog { get { return m_log; } set { m_log = value; }}
        private ClsConfig cfg;
        private ClsCatalog catalog;
        private ClsBackup m_backer;

        private Queue<string> m_pipe_send_tasks = new Queue<string>(5);

        public ClsTaskRuning()
        {
            this.cfg = ClsConfig.Instance;
            if (this.cfg != null && cfg.Target != null)
            {
                this.catalog = cfg.Target.GetCatelog();
            }
        }

        public void Start()
        {
            if (!m_runing)
            {
                m_runing = true;
                if (thTasks == null)
                {
                    thTasks = new System.Threading.Thread(new System.Threading.ThreadStart(proc));
                    thTasks.IsBackground = true;
                    thTasks.Start();
                }
                this.startPipeComm();
            }
        }

        protected void proc()
        {
            while (m_runing)
            {
                if (cfg != null && catalog != null && (catalog.nextTaskTime == null || catalog.nextTaskTime.Value < DateTime.Now))
                {
                    catalog.nextTaskTime = DateTime.Now.AddMinutes((int)cfg.DPFrequency);
                    m_working = true;
                    try
                    {
                        writeLog("= work task start =");
                        if (OnAllTaskStart != null) { OnAllTaskStart(this, cfg); }
                        this.addSendTask(SC_CMD_SYNC_WORK_STARTING);
                        BackupResult result = BackupAll();
                        if (OnAllTaskCompleted != null) { OnAllTaskCompleted(this, result); }
                        this.addSendTask(SC_CMD_SYNC_WORK_COMPLETED);
                        if (result.Status < 0) { writeLog("IMK: " + result.Msg); }
                        writeLog("= work task completed =");


                        //////////////////////////////////////////////////////////////////////////////////////////////

                        try
                        {
                            writeLog("= work clean start =");
                            CleanExpired();
                            writeLog("= work clean completed =");
                        }
                        catch { } //| 清理过期文件

                    }
                    catch(Exception err)
                    {
                        writeLog("IMK: [proc] "+ err.Message);
                    }
                    finally
                    {
                        m_working = false;
                    }

                }
                System.Threading.Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// IMK: 开启管道通信服务
        /// </summary>
        protected void startPipeComm()
        {
            PipeSecurity _pipeSecurity = new PipeSecurity();
            SecurityIdentifier _secId = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
            _pipeSecurity.SetAccessRule(new PipeAccessRule(_secId, PipeAccessRights.ReadWrite, System.Security.AccessControl.AccessControlType.Allow));

            bool _cosi_close_flag = false;

            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                string cmd;
                while (m_runing)
                {
                    using (NamedPipeServerStream pipe_cosi = new NamedPipeServerStream(SC_PIPE_NAME_COSI, PipeDirection.In, 2
                        , PipeTransmissionMode.Message
                        , PipeOptions.Asynchronous
                        , 0x4000
                        , 0x400
                        , _pipeSecurity
                        , HandleInheritability.Inheritable))
                    {
                        pipe_cosi.WaitForConnection();
                        _cosi_close_flag = false;
                        using (StreamReader sr = new StreamReader(pipe_cosi))
                        {
                            while (pipe_cosi.IsConnected)
                            {
                                try
                                {
                                    cmd = sr.ReadLine();
                                    if (cmd == null) { break; }
                                    else { procPipeCommand(cmd); }
                                }
                                catch { break; }
                            }//loop connected
                        }//sr
                        _cosi_close_flag = true;
                    }//psvr
                }//loop runing
            });

            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                while (m_runing)
                {
                    using (NamedPipeServerStream pipe_ciso = new NamedPipeServerStream(SC_PIPE_NAME_CISO, PipeDirection.Out, 2
                        , PipeTransmissionMode.Message
                        , PipeOptions.Asynchronous
                        , 0x400
                        , 0x4000
                        , _pipeSecurity
                        , HandleInheritability.Inheritable
                        ))
                    {
                        pipe_ciso.WaitForConnection();
                        using (StreamWriter sw = new StreamWriter(pipe_ciso))
                        {
                            while (pipe_ciso.IsConnected && !_cosi_close_flag)
                            {
                                if (m_pipe_send_tasks.Count > 0)
                                {
                                    try
                                    {
                                        sw.WriteLine(m_pipe_send_tasks.Dequeue());
                                        sw.Flush();
                                        pipe_ciso.WaitForPipeDrain();
                                    }
                                    catch { break; }
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(1000);
                                }
                            }//loop connected
                        }//sw
                    }//psvr
                }//loop runing
            });
        }

        private void procPipeCommand(string cmd)
        {
            //writeLog("recv cmd: "+ cmd);
            switch (cmd.ToLower())
            {
                case SC_CMD_REFRESH_CONFIG:
                    {
                        refreshConfig();
                        break;
                    }
                case SC_CMD_MANUAL_BACKUP:
                    {
                        manualStart();
                        break;
                    }
                case "test":
                    {
                        addSendTask("Hello, Welcome! -- IMKCode.MARK @ YBZL");
                        break;
                    }
            }
        }

        private void addSendTask(string cmd)
        {
            if (m_pipe_send_tasks.Count > 3){m_pipe_send_tasks.Dequeue();}
            m_pipe_send_tasks.Enqueue(cmd);
        }

        /// <summary>
        /// IMK: 刷新配置
        /// </summary>
        public void refreshConfig()
        {
            //if (m_log){ writeLog("- refresh -"); }

            if (!this.m_working)
            {
                this.cfg = this.cfg.refresh();
                if (this.cfg != null && cfg.Target != null)
                {
                    this.catalog = cfg.Target.GetCatelog();
                }
            }
        }

        /// <summary>
        /// IMK: 手动备份
        /// </summary>
        public void manualStart()
        {
            if (m_log) { writeLog("- manual start -"); }
            if (!this.m_working)
            {
                if (cfg != null && catalog != null)
                {
                    catalog.nextTaskTime = DateTime.Now.AddMinutes((int)cfg.DPFrequency);
                    m_working = true;
                    try
                    {
                        if (OnAllTaskStart != null) { OnAllTaskStart(this, cfg); }
                        this.addSendTask(SC_CMD_SYNC_WORK_STARTING);
                        BackupResult result = BackupAll();
                        if (OnAllTaskCompleted != null) { OnAllTaskCompleted(this, result); }
                        this.addSendTask(SC_CMD_SYNC_WORK_COMPLETED);
                        if (result.Status < 0){ writeLog("IMK: " + result.Msg); }
                    }
                    finally { m_working = false; }
                }
            }
        }

        /// <summary>
        /// IMK: 手动清理
        /// </summary>
        public void manualClean()
        {
            if (m_log) { writeLog("- manual clean -"); }
            if (!this.m_working)
            {
                m_working = true;
                try
                {
                    CleanExpired();
                }
                finally
                {
                    m_working = false;
                }
            }
        }

        protected BackupResult BackupAll()
        {
            BackupResult result = new BackupResult();
            Dictionary<string, DiffFlag> _group;
            if (cfg == null) { return result.setError("IMK: 加载配置文件错"); }
            if (cfg.UserFolder == null) { return result.setError("IMK: 未配置任务源"); }
            if (cfg.Target == null) { return result.setError("IMK: 加载目标驱动器错"); }
            if (string.IsNullOrWhiteSpace(cfg.Target.Drive)){return result.setError("IMK: 未设置目标驱动器");}
            if (string.IsNullOrWhiteSpace(cfg.Target.CatelogFile)) { return result.setError("IMK: 加载目录文件错"); }
            if (catalog == null){return result.setError("IMK: 初始化目录对象失败");}

            if (m_backer == null) { m_backer = new ClsBackup(); }

            string[] sourceFolders = new string[] { };
            try
            {
                sourceFolders = cfg.UserFolder.ToArray();
                foreach (string sourceFolder in sourceFolders)
                {
                    _group = catalog.GetGroup(sourceFolder);
                    string targetFolder = cfg.Target.GetTargetFolder(sourceFolder);
                    try
                    {
                        if (OnTaskItemStart != null){this.OnTaskItemStart(sourceFolder);}
                        var diff = m_backer.Backup(_group, sourceFolder, targetFolder, cfg.FolderExclude, cfg.FileType);
                        catalog.save();
                        if (OnTaskItemCompleted != null) { this.OnTaskItemCompleted(sourceFolder, diff); }
                        result.diffs.AddRange(diff.Select(n=>sourceFolder +"/"+ n.relativePath +"["+ n.Change +"]"));
                        if (m_log) { writeLog($"{sourceFolder} : [{diff.Count()}]"); }
                    }
                    catch (Exception err)
                    {
                        result.addError("IMK: " + sourceFolder + " | " + err.Message);
                        writeLog("IMK: " + sourceFolder + " | " + err.Message);
                    }
                    System.Threading.Thread.Sleep(1000);
                }

                return result;
            }
            finally
            {
                catalog.lastDoneTime = DateTime.Now;
                catalog.nextTaskTime = DateTime.Now.AddMinutes((int)cfg.DPFrequency);
                if (catalog.listTimeTasks == null) { catalog.listTimeTasks = new Dictionary<DateTime, string[]>(); }
                catalog.listTimeTasks.Add(DateTime.Now, sourceFolders);
                catalog.save();
            }
        }

        protected void CleanExpired()
        {
            //TODO: 清理过期文件(未开发)
        }

        public void Stop()
        {
            m_runing = false;

            if (m_backer != null){m_backer.Break(); m_backer = null; }
            
            if (thTasks != null)
            {
                try { thTasks.Abort(); } catch { }
                finally { thTasks = null; }
            }
        }

        public void Dispose()
        {
            this.Stop();
            catalog = null;
        }


        protected void writeLog(string msg)
        {
            try
            {
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "runing.log", string.Format("{0}\t{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg));
            }
            catch { }
        }
    }
}

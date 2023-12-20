using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;

namespace WinFileHistory
{
    public class ClsTaskClient : System.IDisposable
    {
        private int timeout = 1000;
        private bool disposedValue;
        private bool m_pipe_ciso_status;
        private bool m_pipe_cosi_status;
        public bool IsConnected { get { return m_pipe_ciso_status && m_pipe_cosi_status; } }

        private Queue<string> m_pipe_send_tasks = new Queue<string>(5);
        public event Action<string> OnReceive;
        public event Action<bool, bool> OnConnect;
        public event Action<bool, bool> OnDisconnect;

        public ClsTaskClient(int timeout = 1000)
        {
            this.timeout = timeout;
        }

        public void initClient()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                string cmd;
                while (!disposedValue)
                {
                    using (NamedPipeClientStream pipe_ciso = new NamedPipeClientStream(".", ClsTaskRuning.SC_PIPE_NAME_CISO, PipeDirection.In))
                    {
                        try
                        {
                            pipe_ciso.Connect(timeout);
                            m_pipe_ciso_status = true;
                            if (OnConnect != null) { OnConnect(m_pipe_ciso_status, m_pipe_cosi_status); }
                            using (StreamReader sr = new StreamReader(pipe_ciso))
                            {
                                while (pipe_ciso.IsConnected)
                                {
                                    try
                                    {
                                        cmd = sr.ReadLine();
                                        if (cmd == null) { break; }
                                        else { procRecvCmd(cmd); }
                                    }
                                    catch { break; }
                                }//loop connected
                            }//sr
                            m_pipe_ciso_status = false;
                            if (OnDisconnect != null) { OnDisconnect(m_pipe_ciso_status, m_pipe_cosi_status); }
                        }
                        catch { System.Threading.Thread.Sleep(5000); }
                    }
                }
            });

            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                while (!disposedValue)
                {
                    using (NamedPipeClientStream pipe_cosi = new NamedPipeClientStream(".", ClsTaskRuning.SC_PIPE_NAME_COSI, PipeDirection.Out))
                    {
                        try
                        {
                            pipe_cosi.Connect(timeout);
                            m_pipe_cosi_status = true;
                            if (OnConnect != null) { OnConnect(m_pipe_ciso_status, m_pipe_cosi_status); }
                            using (StreamWriter sw = new StreamWriter(pipe_cosi))
                            {
                                while (pipe_cosi.IsConnected)
                                {
                                    if (m_pipe_send_tasks.Count > 0)
                                    {
                                        try
                                        {
                                            sw.WriteLine(m_pipe_send_tasks.Dequeue());
                                            sw.Flush();
                                            pipe_cosi.WaitForPipeDrain();
                                        }
                                        catch { break; }
                                    }
                                    else
                                    {
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                }//loop connected
                            }//sw
                            m_pipe_cosi_status = false;
                            if (OnDisconnect != null) { OnDisconnect(m_pipe_ciso_status, m_pipe_cosi_status); }
                        }
                        catch { System.Threading.Thread.Sleep(5000); }
                    }
                }
            });

        }

        private void procRecvCmd(string cmd)
        {
            if (OnReceive != null) { OnReceive.Invoke(cmd); }
        }

        public void SendRefreshConfig()
        {
            addSendTask(ClsTaskRuning.SC_CMD_REFRESH_CONFIG);
        }

        public void SendManualBackup()
        {
            addSendTask(ClsTaskRuning.SC_CMD_MANUAL_BACKUP);
        }
        public void SendManualClean()
        {
            addSendTask(ClsTaskRuning.SC_CMD_MANUAL_CLEAN);
        }

        public void addSendTask(string cmd)
        {
            if (m_pipe_send_tasks.Count > 3) { m_pipe_send_tasks.Dequeue(); }
            m_pipe_send_tasks.Enqueue(cmd);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~ClsTaskClient()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

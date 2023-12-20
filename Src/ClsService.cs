using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace WinFileHistory
{
    [System.ComponentModel.DesignerCategory("code")]
    public class ClsService : ServiceBase
    {
        internal const string SC_SERVICE_NAME = "WinFileHistory";

        ClsTaskRuning task_runing;
        bool m_log;
        public ClsService() : this(false) { }
        public ClsService(bool log)
        {
            ServiceName = SC_SERVICE_NAME;

            task_runing = new ClsTaskRuning();
            if (m_log = log)
            {
                task_runing.runingLog = true;
                task_runing.OnAllTaskStart += Task_runing_OnAllTaskStart;
                task_runing.OnAllTaskCompleted += Task_runing_OnAllTaskCompleted;
                this.writeLog("INIT SERVICE");
            }
        }

        private void Task_runing_OnAllTaskStart(object sender, object args)
        {
            writeLog("ALL TASK START");
        }
        private void Task_runing_OnAllTaskCompleted(object sender, object args)
        {
            writeLog("ALL TASK COMPLETED");
        }


        protected void writeLog(string msg)
        {
            try
            {
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "service.log", string.Format("{0}\t{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg));
            }
            catch { }
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            if (task_runing != null)
            {
                task_runing.Start();
                if (m_log) { this.writeLog("START SERVICE"); }
            }
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        protected override void OnStop()
        {
            if (task_runing != null)
            {
                task_runing.Stop();
                if (m_log) { this.writeLog("STOP SERVICE"); }
            }
        }

        private void InitializeComponent()
        {
            // 
            // ClsService
            // 
            this.ServiceName = "WinFileHistory";

        }
    }
}

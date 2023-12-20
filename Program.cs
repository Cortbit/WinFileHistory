using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ServiceProcess;

namespace WinFileHistory
{
    static class Program
    {
        public const string scr_svr = "-svr"; // Service
        public const string scr_log = "-log"; // Service write log

        private static string[] m_startArgs;
        /// <summary>
        /// 获取 程序启动时调用的参数
        /// </summary>
        public static string[] StartArguments
        {
            get
            {
                return m_startArgs;
            }
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            m_startArgs = args;
            if (m_startArgs != null && m_startArgs.Contains(scr_svr))
            {//| 以服务方式运行
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new ClsService(m_startArgs.Contains(scr_log))
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmConfig());
            }
        }
    }
}

/**
 * AUTHOR IMKCode.MARK
 * cqdyhcn@gmail.com
 * **/
using System;
using System.Linq;
using Microsoft.Win32;

namespace IMKCode
{
    public class ServiceHelper
    {
        #region 设置服务项
        private static bool? m_isAdmin;
        public static bool IsAdministrator
        {
            get
            {
                if (!m_isAdmin.HasValue)
                {
                    System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                    System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                    //| System.Environment.OSVersion.Version.Major >= 6
                    if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                    {
                        m_isAdmin = true;
                    }
                    else
                    {
                        m_isAdmin = false;
                    }
                }
                return m_isAdmin.Value;
            }
        }

        public static bool ExistService(string key_name)
        {
            if (string.IsNullOrEmpty(key_name)) { return false; }
            key_name = string.Join("_", key_name.Split(@"\/*?:|'""".ToCharArray()));
            using (RegistryKey lmkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\services", true))
            {
                return lmkey.GetSubKeyNames().Contains(key_name);
            }
        }

        #endregion

        public static void RunInstall()
        {
            //string exeurl = System.Windows.Forms.Application.ExecutablePath + " " + Program.scr_svr;

            using (System.Configuration.Install.AssemblyInstaller installer = new System.Configuration.Install.AssemblyInstaller())
            {
                //| /InstallStateDir=
                installer.UseNewContext = true;
                installer.Path = System.Windows.Forms.Application.ExecutablePath;
                System.Collections.IDictionary savedState = new System.Collections.Hashtable();
                installer.Install(savedState);
                installer.Commit(savedState);
            }
        }

        public static void RunUninstall()
        {
            using (System.Configuration.Install.AssemblyInstaller installer = new System.Configuration.Install.AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = System.Windows.Forms.Application.ExecutablePath;
                installer.Uninstall(null);
            }
        }

        public static bool AddFileMenu(string text, string par)
        {
            string _key = System.Windows.Forms.Application.ProductName;
            try
            {
                using (RegistryKey _cmnu = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("*").OpenSubKey("shell", true).CreateSubKey(_key))
                {
                    _cmnu.SetValue(null, text);
                    using (RegistryKey _cmd = _cmnu.CreateSubKey("command"))
                    {
                        _cmd.SetValue(null, System.Windows.Forms.Application.ExecutablePath + " " + par + " \"%1\"");
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        public static bool RemoveFileMenu()
        {
            string _key = System.Windows.Forms.Application.ProductName;
            try
            {
                Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("*").OpenSubKey("shell", true).DeleteSubKeyTree(_key, false);
                return true;
            }
            catch { return false; }
        }

    }
}

/**
 * AUTHOR IMKCode.MARK
 * cqdyhcn@gmail.com
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace WinFileHistory
{
    [RunInstaller(true)]
    [System.ComponentModel.DesignerCategory("code")]
    public class ProjectInstaller : System.Configuration.Install.Installer
    {
        private string _Parameters;

        private ServiceProcessInstaller _ServiceProcessInstaller;
        private ServiceInstaller _ServiceInstaller;

        public ProjectInstaller()
        {
            _ServiceProcessInstaller = new ServiceProcessInstaller();
            _ServiceInstaller = new ServiceInstaller();

            _ServiceProcessInstaller.Account = ServiceAccount.LocalSystem;
            _ServiceProcessInstaller.Password = null;
            _ServiceProcessInstaller.Username = null;

            _ServiceInstaller.ServiceName = "WinFileHistory";
            _ServiceInstaller.Description = "自定义文件历史记录备份";
            _ServiceInstaller.StartType = ServiceStartMode.Automatic;
            _ServiceInstaller.DelayedAutoStart = true;

            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
                _ServiceProcessInstaller,
                _ServiceInstaller});

            _Parameters = Program.scr_svr +" "+ Program.scr_log;
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            IntPtr hScm = OpenSCManager(null, null, SC_MANAGER_ALL_ACCESS);
            if (hScm == IntPtr.Zero) { throw new Win32Exception(); }
            try
            {
                IntPtr hSvc = OpenService(hScm, this._ServiceInstaller.ServiceName, SERVICE_ALL_ACCESS);
                if (hSvc == IntPtr.Zero){ throw new Win32Exception(); }
                try
                {
                    QUERY_SERVICE_CONFIG oldConfig;
                    uint bytesAllocated = 8192; // Per documentation, 8K is max size.
                    IntPtr ptr = Marshal.AllocHGlobal((int)bytesAllocated);
                    try
                    {
                        uint bytesNeeded;
                        if (!QueryServiceConfig(hSvc, ptr, bytesAllocated, out bytesNeeded))
                        {
                            throw new Win32Exception();
                        }
                        oldConfig = (QUERY_SERVICE_CONFIG)Marshal.PtrToStructure(ptr, typeof(QUERY_SERVICE_CONFIG));
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(ptr);
                    }

                    string newBinaryPathAndParameters = oldConfig.lpBinaryPathName + " " + _Parameters;

                    if (!ChangeServiceConfig(hSvc, SERVICE_NO_CHANGE, SERVICE_NO_CHANGE, SERVICE_NO_CHANGE,
                        newBinaryPathAndParameters, null, IntPtr.Zero, null, null, null, null))
                        { throw new Win32Exception(); }
                }
                finally
                {
                    if (!CloseServiceHandle(hSvc)) { throw new Win32Exception(); }
                }
            }
            finally
            {
                if (!CloseServiceHandle(hScm)) { throw new Win32Exception(); }
            }
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr OpenSCManager(
            string lpMachineName,
            string lpDatabaseName,
            uint dwDesiredAccess);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr OpenService(
            IntPtr hSCManager,
            string lpServiceName,
            uint dwDesiredAccess);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct QUERY_SERVICE_CONFIG
        {
            public uint dwServiceType;
            public uint dwStartType;
            public uint dwErrorControl;
            public string lpBinaryPathName;
            public string lpLoadOrderGroup;
            public uint dwTagId;
            public string lpDependencies;
            public string lpServiceStartName;
            public string lpDisplayName;
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool QueryServiceConfig(
            IntPtr hService,
            IntPtr lpServiceConfig,
            uint cbBufSize,
            out uint pcbBytesNeeded);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ChangeServiceConfig(
            IntPtr hService,
            uint dwServiceType,
            uint dwStartType,
            uint dwErrorControl,
            string lpBinaryPathName,
            string lpLoadOrderGroup,
            IntPtr lpdwTagId,
            string lpDependencies,
            string lpServiceStartName,
            string lpPassword,
            string lpDisplayName);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseServiceHandle(
            IntPtr hSCObject);

        private const uint SERVICE_NO_CHANGE = 0xffffffffu;
        private const uint SC_MANAGER_ALL_ACCESS = 0xf003fu;
        private const uint SERVICE_ALL_ACCESS = 0xf01ffu;
    }
}

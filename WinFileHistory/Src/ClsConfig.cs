using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFileHistory
{
    [Serializable]
    public class ClsConfig
    {
        private const string ConfigVersion = "1.0.0";
        private static string file { get { return System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.json"); } }

        private static ClsConfig m_instance;
        public static ClsConfig Instance { get { if (m_instance == null) { m_instance = reload(); } return m_instance; } }

        public string CVer = ConfigVersion;
        public string UserName = System.Environment.UserName;
        public string PCName = System.Environment.MachineName;
        /// <summary>
        /// 要备份的文件夹
        /// </summary>
        public List<string> UserFolder = new List<string>();
        /// <summary>
        /// 排除的文件夹或名称
        /// </summary>
        public List<string> FolderExclude = new List<string>() { "/node_modules/", "/.android/avd/", ".gradle/caches/", "/AppData/Local/", "/AppData/Roaming/" };
        /// <summary>
        /// 文件类型过滤器
        /// </summary>
        public FileTypeConfig FileType = new FileTypeConfig();

        public int TargetAbsenceTime = 5;
        public int TimeInUnprotectedState = 3;
        /// <summary>
        /// 检测频率(分钟)
        /// </summary>
        public EnScheduleTimes DPFrequency = EnScheduleTimes.Hour_1;
        /// <summary>
        /// 服务启用状态
        /// </summary>
        public bool DPStatus = true;
        /// <summary>
        /// 保留月数(-1:永远，且不删除), (0:直到空间不足)
        /// </summary>
        public EnFileKeepTimes Retention = EnFileKeepTimes.Never;
        /// <summary>
        /// 目标驱动器
        /// </summary>
        public TargetConfig Target;


        public void SetTarget(TargetConfig _target)
        {
            UserName = System.Environment.UserName;
            PCName = System.Environment.MachineName;

            this.Target = _target;

            this.save();

            if (!System.IO.Directory.Exists(Target.GetConfigPath()))
            {
                System.IO.Directory.CreateDirectory(Target.GetConfigPath());
            }
            System.IO.File.Copy(file, System.IO.Path.Combine(Target.GetConfigPath(), "config.json"), true);
            if (!System.IO.Directory.Exists(Target.GetStorePath()))
            {
                System.IO.Directory.CreateDirectory(Target.GetStorePath());
            }
        }

        public void save()
        {
            string jstr = JsonHelper.ToJson(this);
            jstr = jstr.Replace("],\"", "],\r\n\"").Replace("},{\"", "},\r\n{\"");
            System.IO.File.WriteAllText(file, jstr);
        }


        /// <summary>
        /// 重新读取文件，并更新当前对象
        /// </summary>
        /// <returns></returns>
        internal ClsConfig refresh()
        {
            ClsConfig tmp = reload();
            this.UserFolder = tmp.UserFolder;
            this.FolderExclude = tmp.FolderExclude;
            this.FileType = tmp.FileType;
            this.TargetAbsenceTime = tmp.TargetAbsenceTime;
            this.TimeInUnprotectedState = tmp.TimeInUnprotectedState;
            this.DPFrequency = tmp.DPFrequency;
            this.Retention = tmp.Retention;
            this.Target = tmp.Target;
            this.DPStatus = tmp.DPStatus;
            return this;
        }

        private static ClsConfig reload()
        {
            ClsConfig jobj;
            if (System.IO.File.Exists(file))
            {
                string jstr = System.IO.File.ReadAllText(file);
                try
                {
                    jobj = JsonHelper.ToObject<ClsConfig>(jstr);
                    if (jobj == null) { jobj = new ClsConfig(); }
                    if (jobj.CVer != ConfigVersion)
                    {
                        jobj.CVer = ConfigVersion;
                        jobj.save();
                    }
                    jobj.UserFolder = jobj.UserFolder.Select(n => n.Replace("\\", "/")).ToList();
                    jobj.FolderExclude = jobj.FolderExclude.Select(n => n.Replace("\\", "/")).ToList();
                    return jobj;
                }
                catch {
                    try { string _bak = System.IO.Path.ChangeExtension(file, ".bak"); System.IO.File.Move(file, _bak); } catch { }
                    jobj = new ClsConfig();
                    jobj.save();
                }
            }
            else
            {
                jobj = new ClsConfig();
                jobj.save();
            }
            return jobj;

        }

    }

    [Serializable]
    public class FileTypeConfig
    {        /// <summary>
        /// 文件过滤方式: 0-全部，1-筛选法，2-排除法
        /// </summary>
        public int FilterStatus = 0;
        /// <summary>
        /// 筛选法，文件类型
        /// </summary>
        public List<string> ChoosedTypes = new List<string>() { ".aspx", ".ascx", ".dll", ".asp", ".htm", ".html", ".js", ".css", ".mdb", ".config" };
        /// <summary>
        /// 排除法，文件类型
        /// </summary>
        public List<string> ExcludeTypes = new List<string>() { ".user", ".scc", ".suo", ".vssscc", ".vspscc", ".pdb", ".refresh", ".ldf", ".lock" };

        /// <summary>
        /// IMK: 检查文件类型是否需备份
        /// </summary>
        /// <param name="extName"></param>
        /// <returns></returns>
        public bool filterExtName(string extName)
        {
            switch (FilterStatus)
            {
                case 0: { return true; }
                case 1: { return ChoosedTypes.Contains(extName, StringComparer.CurrentCultureIgnoreCase); }
                case 2: { return !ExcludeTypes.Contains(extName, StringComparer.CurrentCultureIgnoreCase); }
                default: { return false; }
            }
            
        }

    }

    [Serializable]
    public class TargetConfig
    {
        public string Drive;
        public string DriveType;

        public string CatelogFile;

        public string ConfigPath;
        public string StorePath;

        public string GetConfigPath() { return string.Format("{0}FileHistory/{1}", Drive, ConfigPath); }
        public string GetStorePath() { return string.Format("{0}FileHistory/{1}", Drive, StorePath); }

        public string GetTargetFolder(string source)
        {
            return System.IO.Path.Combine(GetStorePath(), source.Replace(":", "").Replace("\\", "/").Replace("//", "/"));
        }

        public long GetTotalSize()
        {
            var allFiles = new System.IO.DirectoryInfo(GetStorePath()).EnumerateFiles("*.*", System.IO.SearchOption.AllDirectories);
            return allFiles.Sum(f => f.Length);
        }
        public void GetTotalSizeAsync(Action<long> action)
        {
            if (action == null) { return; }
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                action.Invoke(GetTotalSize());
            });
        }

        private ClsCatalog m_catalog;
        public ClsCatalog GetCatelog()
        {
            if (m_catalog == null) { m_catalog = ClsCatalog.LoadFrom(CatelogFile); }
            return m_catalog;
        }

        public TargetConfig() { }
        public TargetConfig(System.IO.DriveInfo drive)
        {
            this.Drive = drive.Name.Replace("\\", "/");

            Drive = drive.Name.Replace("\\", "/");
            DriveType = drive.DriveType.ToString();

            string _UserName = System.Environment.UserName;
            string _PCName = System.Environment.MachineName;

            ConfigPath = string.Format("{0}/{1}/{2}", _UserName, _PCName, "Configuration"); 
            StorePath = string.Format("{0}/{1}/{2}", _UserName, _PCName, "Data");
            CatelogFile = string.Format("{0}/{1}", GetConfigPath(), "catelog.db");

        }
    }
}

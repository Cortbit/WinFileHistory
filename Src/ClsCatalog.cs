using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFileHistory
{
    [Serializable]
    public class ClsCatalog
    {
        private const string CatelogVersion = "1.0.0";
        private static string getDefaultFile() { return System.IO.Path.Combine(System.Environment.CurrentDirectory, "catelog.jdb"); }
        private string file;

        public string CVer = CatelogVersion;
        public DateTime? lastDoneTime;
        public DateTime? lastCleanTime;
        public DateTime? nextTaskTime;
        public Dictionary<string, Dictionary<string, DiffFlag>> catelogs = new Dictionary<string, Dictionary<string, DiffFlag>>();
        /// <summary>
        /// 任务执行记录
        /// </summary>
        public Dictionary<string, string[]> listTimeTasks = new Dictionary<string, string[]>();

        public ClsCatalog() { }

        protected ClsCatalog(string catelog_file)
        {
            this.file = catelog_file;
        }

        public void save()
        {
            string _file = this.file;
            if (string.IsNullOrWhiteSpace(_file))
            {
                _file = getDefaultFile();
            }
            //|this.SaveObject(_file);
            //|this.SaveJDB(System.IO.Path.ChangeExtension(_file, ".jdb"));
            this.SaveJDB(_file);
        }

        public static ClsCatalog LoadFrom(string catelog_file)
        {
            ClsCatalog jobj;
            string _file = catelog_file ?? getDefaultFile();
            if (System.IO.File.Exists(_file))
            {
                //string jstr = System.IO.File.ReadAllText(_file);
                try
                {
                    //jobj = _file.ReadObject<ClsCatalog>(); //old .db file
                    //try { jobj.SaveJDB(System.IO.Path.ChangeExtension(_file, ".jdb")); } catch { }
                    jobj = _file.ReadJDB<ClsCatalog>();
                    if (jobj == null) { jobj = new ClsCatalog(_file); }
                    if (jobj.CVer != CatelogVersion)
                    {
                        jobj.CVer = CatelogVersion;
                        jobj.save();
                    }
                    if (jobj.listTimeTasks == null) { jobj.listTimeTasks = new Dictionary<string, string[]>(); }
                    jobj.file = _file;
                    return jobj;
                }
                catch
                {
                    try { string _bak = System.IO.Path.ChangeExtension(_file, ".bak"); System.IO.File.Move(_file, _bak); } catch { }
                    jobj = new ClsCatalog(_file);
                    jobj.save();
                }
            }
            else
            {
                jobj = new ClsCatalog(_file);
                jobj.save();
            }
            return jobj;

        }

        public Dictionary<string, DiffFlag> GetGroup(string source)
        {
            Dictionary<string, DiffFlag> group;
            if (!catelogs.TryGetValue(source, out group))
            {
                group = new Dictionary<string, DiffFlag>(StringComparer.CurrentCultureIgnoreCase);
                catelogs.Add(source, group);
            }
            return group;
        }

        public bool ExistHistory(string source, string filePath)
        {
            return GetGroup(source).ContainsKey(filePath);
        }

        


    }
}

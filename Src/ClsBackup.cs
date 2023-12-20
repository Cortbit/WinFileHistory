using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WinFileHistory
{
    public class ClsBackup
    {
        private bool m_break;
        /// <summary>
        /// IMK: 中止正在进行的任务
        /// </summary>
        public void Break(){ m_break = true; }

        public IEnumerable<DiffFlag> Backup(Dictionary<string, DiffFlag> group, string sourcePath, string targetPath, List<string> excludePaths, FileTypeConfig fileTypes)
        {
            m_break = false;

            IList<DiffFlag> _fileDiffs = new List<DiffFlag>();
            var sourceFiles = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories).Select(n=>n.Replace("\\","/")).ToArray();
            var targetFiles = group.Keys.ToArray(); //| keys -> relativePath
            foreach (var sourceFile in sourceFiles)
            {
                if (m_break) { break; }
                if (excludePaths != null && excludePaths.IsExclude(sourceFile)) { continue; }
                if (fileTypes != null && !fileTypes.filterExtName(System.IO.Path.GetExtension(sourceFile))) { continue; }

                var relativePath = GetFilePathRelativeTo(sourceFile, sourcePath);
                var sourceFileInfo = new FileInfo(sourceFile);

                if (!group.ContainsKey(relativePath))
                {
                    DiffFlag _diff = new DiffFlag
                    {
                        relativePath = relativePath,
                        length = sourceFileInfo.Length,
                        modifyTime = sourceFileInfo.LastWriteTimeUtc,
                        Change = EnChangeType.Added,
                    };
                    group.Add(relativePath, _diff);
                    if (CopyFile(sourceFile, getNewFile(targetPath, relativePath, sourceFileInfo.LastWriteTimeUtc)))
                    {
                        _fileDiffs.Add(_diff);
                    }
                    System.Threading.Thread.Sleep(10);
                }
                else
                {
                    DiffFlag _diff = this.CheckDiff(group, sourceFileInfo);
                    if (_diff != null && _diff.Change == EnChangeType.Modified)
                    {
                        if (CopyFile(sourceFile, getNewFile(targetPath, relativePath, sourceFileInfo.LastWriteTimeUtc)))
                        {
                            _fileDiffs.Add(_diff);
                        }
                        System.Threading.Thread.Sleep(10);
                    }
                }
            }

            foreach (var relativePath in targetFiles)
            {
                //var sourceFile = Path.Combine(sourcePath, relativePath); "E:/www","/index.html" => "/index.html"
                var sourceFile = sourcePath + relativePath;

                if (!File.Exists(sourceFile))
                {
                    group.Remove(relativePath); //| delete item in group @ catelog
                }
            }

            return _fileDiffs;
        }

        private string GetFilePathRelativeTo(string path, string basePath)
        {
            return ClsExts.GetRelativePath(basePath, path, true);
        }

        public DiffFlag CheckDiff(Dictionary<string, DiffFlag> group, System.IO.FileInfo fiSource)
        {
            DiffFlag fd;
            if (group.TryGetValue(fiSource.FullName, out fd))
            {
                if (fd.length != fiSource.Length || fd.modifyTime != fiSource.LastWriteTimeUtc)
                {
                    fd.Change = EnChangeType.Modified;
                    fd.length = fiSource.Length;
                    fd.modifyTime = fiSource.LastWriteTimeUtc;
                }
                else
                {
                    fd.Change = EnChangeType.None;
                }
            }
            return fd;
        }

        private string getNewFile(string targetPath, string relativePath, DateTime? dtmUtc)
        {
            string _foler = targetPath + Path.GetDirectoryName(relativePath);
            string _tagFile = string.Concat(
                Path.GetFileNameWithoutExtension(relativePath),
                (dtmUtc ?? DateTime.UtcNow).ToString(" (yyyy_MM_dd HH_mm_ss UTC)"),
                Path.GetExtension(relativePath)
                );
            if (!System.IO.Directory.Exists(_foler))
            {
                System.IO.Directory.CreateDirectory(_foler);
            }    
            return _foler + "/"+ _tagFile;

        }
        private bool CopyFile(string source, string target)
        {
            try
            {
                if (!System.IO.File.Exists(target)){ System.IO.File.Copy(source, target); }
                return true;
            }
            catch (Exception err){ Console.WriteLine(err.Message); return false; }
        }
    }
}

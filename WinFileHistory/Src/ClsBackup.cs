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
                DiffFlag _diff;
                if (!group.TryGetValue(relativePath, out _diff))
                {
                    _diff = new DiffFlag
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
                    //System.Threading.Thread.Sleep(10);
                }
                else if (IsDiff(_diff, sourceFileInfo))
                {
                    if (_diff.relativePath == null) { _diff.relativePath = relativePath; }
                    if (CopyFile(sourceFile, getNewFile(targetPath, relativePath, sourceFileInfo.LastWriteTimeUtc)))
                    {
                        _fileDiffs.Add(_diff);
                    }
                    //System.Threading.Thread.Sleep(10);
                }
            }

            foreach (var relativePath in targetFiles)
            {
                var sourceFile = Path.Combine(sourcePath, relativePath); //"E:/www","/index.html" => "/index.html"
                if (!File.Exists(sourceFile))
                {
                    //Console.WriteLine("REMOVE:"+ sourceFile);
                    group.Remove(relativePath); //| delete item in group @ catelog
                }
            }

            return _fileDiffs;
        }

        private string GetFilePathRelativeTo(string path, string basePath)
        {
            return ClsExts.GetRelativePath(basePath, path, true);
        }

        public bool IsDiff(DiffFlag diff, System.IO.FileInfo fiSource)
        {
            //| 636951426706140000 : 636951426706141703
            if (diff.length != fiSource.Length || (diff.modifyTime.Ticks /10000) != (fiSource.LastWriteTimeUtc.Ticks /10000))
            //if (diff.length != fiSource.Length || diff.modifyTime.ToString("yyyyMMddHHmmssfff") != fiSource.LastWriteTimeUtc.ToString("yyyyMMddHHmmssfff"))
            {
                diff.Change = EnChangeType.Modified;
                diff.length = fiSource.Length;
                diff.modifyTime = fiSource.LastWriteTimeUtc;
                return true;
            }
            else
            {
                return false;
            }
        }

        private string getNewFile(string targetPath, string relativePath, DateTime? dtmUtc)
        {
            string _foler = System.IO.Path.Combine(targetPath, Path.GetDirectoryName(relativePath));
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
                if (!System.IO.File.Exists(target)){ System.IO.File.Copy(source, target); System.Threading.Thread.Sleep(10); }
                return true;
            }
            catch (Exception err){ Console.WriteLine(err.Message); return false; }
        }

    }
}

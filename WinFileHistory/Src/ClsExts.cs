using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFileHistory
{
    public static class ClsExts
    {
        public static string ToGB(this long length, int digits = 0)
        {
            return (length / 1024 / 1024 / 1024F).ToString("F"+digits) + " GB";
        }

        public static bool IsExclude(this List<string> excludes, string path)
        {
            foreach (string exc in excludes)
            {
                if ((exc.StartsWith("//") || exc.IndexOf(":") >= 0) && path.StartsWith(exc, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
                else if (path.IndexOf(exc, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// IMK: 计算相对路径
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns></returns>
        /// <example>GetRelativePath("c:/www/book1/index.html","c:/www/");</example>
        public static string GetRelativePath(string path1, string path2, bool ignoreCase = false)
        {
            string[] path1Array = path1.Replace("\\", "/").Split('/');
            string[] path2Array = path2.Replace("\\", "/").Split('/');

            int s = path1Array.Length >= path2Array.Length ? path2Array.Length : path1Array.Length;
            //两个目录最底层的共用目录索引
            int closestRootIndex = -1;
            for (int i = 0; i < s; i++)
            {
                //if (path1Array[i] == path2Array[i])
                if (string.Equals(path1Array[i], path2Array[i], ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
                {
                    closestRootIndex = i;
                }
                else
                {
                    break;
                }
            }
            //由path1计算 ‘../’部分
            string path1Depth = "";
            if (closestRootIndex >= 0) //IMK: have same part
            {
                for (int i = 0; i < path1Array.Length; i++)
                {
                    if (i > closestRootIndex + 1)
                    {
                        path1Depth += "../";
                    }
                }
            }
            //由path2计算 ‘../’后面的目录
            string path2Depth = "";
            for (int i = closestRootIndex + 1; i < path2Array.Length; i++)
            {
                path2Depth += "/" + path2Array[i];
            }
            path2Depth = path2Depth.Substring(1);

            return path1Depth + path2Depth;
        }
    }
}

/**
 * AUTHOR IMKCode.MARK
 * cqdyhcn@gmail.com
 * **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

/// <summary>
/// JSON序列化和反序列化辅助类 for .net 4.0
/// 引用 System.Web.Extensions
/// </summary>
public static class JsonHelper
{
    /// <summary>
    /// 将对像转换为 JSON 字符串
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ToJson(this object obj)
    {
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            jss.MaxJsonLength = 1024 * 1024 * 20; //| 20M
            return jss.Serialize(obj);
        
    }

    /// <summary>
    /// 将 JSON 这符串转换为对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    public static T ToObject<T>(this string json)
    {
        try
        {
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            jss.MaxJsonLength = 1024 * 1024 * 20; //| 20M
            return jss.Deserialize<T>(json);
        }
        catch { return default(T); }
    }
    public static Object ToObject(string json)
    {
        try
        {
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            return jss.DeserializeObject(json);
        }
        catch { return null; }
    }

    public static void SaveObject(this object obj, string file)
    {
        if (obj == null) { return; }
        using (FileStream fs = new FileStream(file, FileMode.Create))
        {
            using (System.IO.Compression.GZipStream sw = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Compress))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(sw, obj);
                sw.Close();
            }
            fs.Close();
        }
    }

    public static T ReadObject<T>(this string file)
    {
        using (FileStream fs = new FileStream(file, FileMode.Open))
        {
            using (System.IO.Compression.GZipStream sw = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Decompress))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                T obj = (T)formatter.Deserialize(sw);
                sw.Close();
                return obj;
            }
            //fs.Close();
        }
    }

    public static void SaveJDB(this object obj, string file)
    {
        if (obj == null) { return; }
        using (FileStream fs = new FileStream(file, FileMode.Create))
        {
            using (System.IO.Compression.GZipStream sw = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Compress))
            {
                string _json = obj.ToJson();
                byte[] _buf = System.Text.Encoding.UTF8.GetBytes(_json);
                sw.Write(_buf, 0, _buf.Length);
                _buf = null;
                sw.Close();
            }
            fs.Close();
        }
    }

    public static T ReadJDB<T>(this string file)
    {
        using (FileStream fs = new FileStream(file, FileMode.Open))
        {
            using (System.IO.Compression.GZipStream sr = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Decompress))
            {
                using (System.IO.MemoryStream ms = new MemoryStream())
                {
                    int _size = 2048;
                    byte[] buf = new byte[_size];
                    do{_size = sr.Read(buf, 0, buf.Length); ms.Write(buf, 0, _size); } while (_size > 0);
                    return System.Text.Encoding.UTF8.GetString(ms.ToArray()).ToObject<T>();
                }
            }
        }
    }


}
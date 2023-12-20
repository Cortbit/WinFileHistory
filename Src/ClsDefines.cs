using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WinFileHistory
{
    #region 枚举对象
    /// <summary>
    /// IMK: 代理 Enum 项 使用 Description 属性显示 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct EnumItem<T> where T : Enum
    {
        private static Type _att = typeof(DescriptionAttribute);

        public T item;
        public int Value { get { return (int)(object)item; } }

        public static implicit operator EnumItem<T>(T eval)
        {
            return new EnumItem<T>(eval);
        }

        public static implicit operator T(EnumItem<T> eitem)
        {
            return eitem.item;
        }

        public EnumItem(T evalue)
        {
            this.item = evalue;
        }

        public override string ToString()
        {
            var _attrs = item.GetType().GetField(item.ToString()).GetCustomAttributes(_att, false);
            if (_attrs.Length > 0)
            {
                return ((DescriptionAttribute)_attrs[0]).Description;
            }
            return item.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) || item.Equals(obj);
        }

        public override int GetHashCode()
        {
            return item.GetHashCode();
        }
    }

    /// <summary>
    /// IMK: 计划执行周期时间(分钟)
    /// </summary>
    public enum EnScheduleTimes : int
    {
        [Description("每 10 分钟")]
        Minutes_10 = 10,
        [Description("每 15 分钟")]
        Minutes_15 = 15,
        [Description("每 20 分钟")]
        Minutes_20 = 20,
        [Description("每 30 分钟")]
        Minutes_30 = 30,
        [Description("每小时（默认）")]
        Hour_1 = 60,
        [Description("每 3 小时")]
        Hour_3 = 180,
        [Description("每 6 小时")]
        Hour_6 = 360,
        [Description("每 12 小时")]
        Hour_12 = 720,
        [Description("每天")]
        Day_1 = 1440
    }

    /// <summary>
    /// IMK: 历史文件保留时长(月)
    /// </summary>
    public enum EnFileKeepTimes : int
    {
        [Description("直到空间不足")]
        ForSpace = 0,
        [Description("1 个月")]
        Monthes_1 = 1,
        [Description("3 个月")]
        Monthes_3 = 3,
        [Description("6 个月")]
        Monthes_6 = 6,
        [Description("9 个月")]
        Monthes_9 = 9,
        [Description("1 年")]
        Years_1 = 12,
        [Description("2 年")]
        Years_2 = 24,
        [Description("永远(默认)")]
        Never = -1,
    }

    public enum EnChangeType
    {
        None,
        Modified,
        Added,
        Deleted
    }

    #endregion

    #region 对象定义

    [Serializable]
    public class DiffFlag
    {
        public string relativePath;
        public EnChangeType Change;
        public long length;
        public DateTime modifyTime;

        public DiffFlag()
        {
            Change = EnChangeType.None;
        }
    }

    public class BackupResult : System.IDisposable
    {
        private int m_status;
        private string m_msg;
        public List<string> diffs = new List<string>();

        public int Status { get => m_status; set => m_status = value; }
        public string Msg { get => m_msg; set => m_msg = value; }

        public BackupResult setError(int status, string msg)
        {
            this.m_status = status;
            this.m_msg = msg ?? "failed";
            return this;
        }
        public BackupResult setError(string msg)
        {
            setError(-1, msg);
            return this;
        }

        public BackupResult addError(string msg)
        {
            this.m_msg += string.Format("{0}\t{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg);
            return this;
        }
        public BackupResult setSuccess(string msg)
        {
            this.m_status = 1;
            this.m_msg = msg ?? "success";
            return this;
        }

        public void Dispose()
        {
            diffs.Clear();
        }
    }

    #endregion

    public delegate void TaskItemStartHandler(string source);
    public delegate void TaskItemCompletedHandler(string source, IEnumerable<DiffFlag> diffs);
    public delegate void TaskHandler(object sender, object args);

    public class ClsDefines
    {
        public static readonly EnumItem<EnScheduleTimes>[] SC_ScheduleItmes = new EnumItem<EnScheduleTimes>[]
        {
            EnScheduleTimes.Minutes_10,
            EnScheduleTimes.Minutes_15,
            EnScheduleTimes.Minutes_20,
            EnScheduleTimes.Minutes_30,
            EnScheduleTimes.Hour_1,
            EnScheduleTimes.Hour_3,
            EnScheduleTimes.Hour_6,
            EnScheduleTimes.Hour_12,
            EnScheduleTimes.Day_1,
        };


        public static readonly EnumItem<EnFileKeepTimes>[] SC_FileKeepTimes = new EnumItem<EnFileKeepTimes>[]
        {
            EnFileKeepTimes.ForSpace,
            EnFileKeepTimes.Monthes_1,
            EnFileKeepTimes.Monthes_3,
            EnFileKeepTimes.Monthes_6,
            EnFileKeepTimes.Monthes_9,
            EnFileKeepTimes.Years_1,
            EnFileKeepTimes.Years_2,
            EnFileKeepTimes.Never,
        };

    }

}

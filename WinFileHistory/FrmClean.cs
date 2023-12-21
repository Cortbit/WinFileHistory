using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFileHistory
{
    public partial class FrmClean : Form
    {
        public int ExpireMonths
        {
            get
            {
                if (cbxKeepTimes.SelectedItem != null)
                {
                    object _item = cbxKeepTimes.SelectedItem;
                    if (_item is EnumItem<EnFileCleanTimes>)
                    {
                        EnFileCleanTimes _value = ((EnumItem<EnFileCleanTimes>)_item).item;
                        return (int)_value;
                    }
                }
                return -1;
            }
            set
            {
                EnFileCleanTimes _item;
                if (Enum.TryParse<EnFileCleanTimes>(value.ToString(), out _item))
                {
                    cbxKeepTimes.SelectedItem = _item;
                }
            }
        }

        public FrmClean()
        {
            InitializeComponent();

            cbxKeepTimes.DataSource = ClsDefines.SC_FileCleanTimes;
            cbxKeepTimes.SelectedItem = EnFileCleanTimes.Years_1;
        }
    }
}

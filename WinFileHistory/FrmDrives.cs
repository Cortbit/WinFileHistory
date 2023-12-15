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
    public partial class FrmDrives : Form
    {
        public System.IO.DriveInfo SelectDrive { get; set; }

        public FrmDrives()
        {
            InitializeComponent();
        }

        private void FrmDrives_Load(object sender, EventArgs e)
        {
            this.localInitLayout();
        }

        private void localInitLayout()
        {
            var drives = System.IO.DriveInfo.GetDrives();
            lstDrives.Items.Clear();
            foreach (var drive in drives)
            {
                ListViewItem lv = new ListViewItem();
                lv.Tag = drive;
                lv.Text = drive.DriveType + " " + drive.Name;
                lv.SubItems.Add(drive.AvailableFreeSpace.ToGB());
                lv.SubItems.Add(drive.TotalSize.ToGB());
                if (drive == SelectDrive) { lv.Selected = true; }
                lstDrives.Items.Add(lv);
            }
        }

        private void lstDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDrives.SelectedItems.Count > 0)
            {
                this.SelectDrive = (System.IO.DriveInfo)lstDrives.SelectedItems[0].Tag;
            }
        }
    }
}

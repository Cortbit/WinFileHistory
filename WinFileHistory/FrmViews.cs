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
    public partial class FrmViews : Form
    {
        ClsConfig cfg;
        System.Text.RegularExpressions.Regex rxOrgName = new System.Text.RegularExpressions.Regex(@"(.*)(\s+\(\d{4}_\d{2}_\d{2}\s+\d{2}_\d{2}_\d{2}\s+UTC\))(\.?[^$]*)"); //| "test (2019_10_10 08_28_02 UTC).html" => "test.html"

        public FrmViews()
        {
            InitializeComponent();

            cfg = ClsConfig.Instance;
            this.Icon = IMKCode.API.IconHelper.ExtractIcon(0);
        }

        private void FrmViews_Load(object sender, EventArgs e)
        {
            initView();
        }

        private void initView()
        {
            if (Program.StartArguments != null)
            {
                for (int i=0; i< Program.StartArguments.Length; i++)
                {
                    if (Program.StartArguments[i] == Program.scr_view && Program.StartArguments.Length > i+1)
                    {
                        startView(Program.StartArguments[i + 1]);
                    }
                }
            }
        }

        private void startView(string file)
        {
            cbxSource.Text = file;
            if (file == null || cfg.Target == null) { return; }
            string _url = cfg.Target.GetTargetFolder(file);
            string _folder = System.IO.Path.GetDirectoryName(_url);
            string _filter = string.Concat(
                System.IO.Path.GetFileNameWithoutExtension(_url),
                "*",
                System.IO.Path.GetExtension(_url)
                );

            this.Text = System.IO.Path.GetFileName(file) + " - 文件历史记录";

            if (System.IO.Directory.Exists(_folder))
            {
                var verFiles = new System.IO.DirectoryInfo(_folder).EnumerateFiles(_filter, System.IO.SearchOption.AllDirectories);
                foreach (var vf in verFiles)
                {
                    System.Text.RegularExpressions.Match mt = rxOrgName.Match(vf.Name);
                    if (mt.Success && mt.Groups.Count == 4)
                    {
                        string _orgName = mt.Groups[1].Value + mt.Groups[3].Value;
                        ListViewItem _li = new ListViewItem(_orgName);
                        _li.SubItems.Add(vf.LastWriteTime.ToString("yyyy-MM-dd HH:mm"));
                        _li.SubItems.Add(mt.Groups[3].Value);
                        _li.SubItems.Add(vf.Length.ToXB());
                        _li.Tag = vf;
                        lstView.Items.Add(_li);
                    }
                }
            }

            //foreach (string source in cfg.UserFolder)
            //{
            //    if (_url.StartsWith(source +"/"))
            //    {
            //        var group = cfg.Target.GetCatelog().GetGroup(source);
            //        var relativePath = GetFilePathRelativeTo(file, source);
            //        DiffFlag _diff;
            //        if (group.TryGetValue(relativePath, out _diff))
            //        {
            //            label1.Text = cfg.Target.GetTargetFolder(_url) +"\r\n"+ relativePath +"\r\n"+ _diff.modifyTime;
            //        }
            //    }
            //}
        }

        private string GetFilePathRelativeTo(string path, string basePath)
        {
            return ClsExts.GetRelativePath(basePath, path, true);
        }

        private void cmnuViewPreview_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                if (lstView.SelectedItems[0].Tag is System.IO.FileInfo)
                {
                    ExplorerTo(((System.IO.FileInfo)lstView.SelectedItems[0].Tag).FullName);
                }
            }
        }

        /// <summary>
        /// IMK: 打开资源管理器到...
        /// </summary>
        /// <param name="filePath"></param>
        public static void ExplorerTo(string filePath)
        {
            System.Diagnostics.Process.Start(System.Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "/explorer.exe", "/e,/select,\"" + filePath + "\"");
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            cmnuRestoreTo_Click(sender, e);
        }

        private void cmnuRestoreTo_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                if (lstView.SelectedItems[0].Tag is System.IO.FileInfo)
                {
                    System.IO.FileInfo _item = (System.IO.FileInfo)lstView.SelectedItems[0].Tag;
                    string _file;
                    bool _overwrite = false;
                    if (getRestoreFile(_item.FullName, out _file))
                    {
                        if (System.IO.File.Exists(_file))
                        {
                            System.IO.FileInfo _target = new System.IO.FileInfo(_file);

                            if (MessageBox.Show("目标已包含一个名为”"+ System.IO.Path.GetFileName(_file) +"“的文件\r\n"
                                + "目标文件大小："+ _target.Length + compSize(_target.Length, _item.Length)+ "\r\n"
                                + "目标修改日期：" + _target.LastWriteTime + compDate(_target.LastWriteTime, _item.LastWriteTime) + "\r\n"
                                + "备份文件大小：" + _item.Length + compSize(_item.Length, _target.Length) + "\r\n"
                                + "备份修改日期：" + _item.LastWriteTime + compDate(_item.LastWriteTime, _target.LastWriteTime) +"\r\n"
                                + "请确认是否覆盖目标文件？",
                                "替换目标文件", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _overwrite = true;
                            }
                            else
                            {
                                return;
                            }
                        }
                        try { _item.CopyTo(_file, _overwrite); }
                        catch (Exception err) { MessageBox.Show(err.Message, "还原失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    }
                }
            }
        }

        private string compSize(long size1, long size2)
        {
            return (size1 == size2) ? " (大小相同)"
                : (size1 > size2) ? " (大)"
                : (size1 < size2) ? " (小)"
                : "(-)";
        }
        private string compDate(DateTime date1, DateTime date2)
        {
            long _tick1 = date1.Ticks / 10000; //| 比较到 ms
            long _tick2 = date2.Ticks / 10000;
            return (_tick1 == _tick2) ? " (日期相同)"
                : (_tick1 > _tick2) ? " (新)"
                : (_tick1 < _tick2) ? " (旧)"
                : "(-)";
        }

        private void cmnuRestoreAs_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                if (lstView.SelectedItems[0].Tag is System.IO.FileInfo)
                {
                    System.IO.FileInfo _item = (System.IO.FileInfo)lstView.SelectedItems[0].Tag;
                    SaveFileDialog diag = new SaveFileDialog();
                    diag.Filter = "还原文件|*" + _item.Extension +"";
                    diag.DefaultExt = _item.Extension;
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        _item.CopyTo(diag.FileName);
                    }
                }
            }
        }

        private bool getRestoreFile(string file, out string target)
        {
            string _url = file.Replace("\\", "/");
            foreach (string source in cfg.UserFolder)
            {
                string _fld = cfg.Target.GetTargetFolder(source);
                if (_url.StartsWith(_fld + "/"))
                {
                    target = _url.Replace(_fld, source);
                    System.Text.RegularExpressions.Match mt = rxOrgName.Match(target);
                    if (mt.Success && mt.Groups.Count == 4)
                    {
                        target = mt.Groups[1].Value + mt.Groups[3].Value;
                        return true;
                    }
                }
            }
            target = null;
            return false;
        }

    }
}

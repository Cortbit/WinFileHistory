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
    public partial class FrmConfig : Form
    {
        private bool from_inited;
        protected ClsConfig cfg;
        private ClsTaskClient tc;
        private float[] m_scalers;
        Control[] m_ctrls;

        public FrmConfig()
        {
            cfg = ClsConfig.Instance;
            tc = new ClsTaskClient();

            InitializeComponent();

            this.Icon = IMKCode.API.IconHelper.ExtractIcon(0);

            m_ctrls = new Control[] { grpSource, grpExclude, grpFileType, grpTarget };
            m_scalers = new float[m_ctrls.Length];
        }

        private void setScaler()
        {
            int _width = this.ClientSize.Width - this.Padding.Left - this.Padding.Right;
            if (_width <= 0) { return; }
            for (int i = 0; i < m_ctrls.Length; i++)
            {
                m_scalers[i] = 1F * m_ctrls[i].Width / _width;
            }
        }
        private void resetScaler()
        {
            int _width = this.ClientSize.Width - this.Padding.Left - this.Padding.Right;
            for (int i = 0; i < m_ctrls.Length; i++)
            {
                m_ctrls[i].Width = (int)(1F * _width * m_scalers[i]);
            }
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            this.localInitLayout();
            this.refrshList(false);
        }

        private void localInitLayout()
        {
            cbxScheduleTimes.DataSource = ClsDefines.SC_ScheduleItmes;
            cbxScheduleTimes.SelectedItem = cfg.DPFrequency;// EnScheduleTimes.Hour_1;

            cbxKeepTimes.DataSource = ClsDefines.SC_FileKeepTimes;
            cbxKeepTimes.SelectedItem = cfg.Retention;// EnFileKeepTimes.Never;

            rbtnFileTypeAll.Checked = true;

            this.from_inited = true;

            //| 接收后台服务消息
            tc.OnReceive += (cmd) => { 
                writeLog(cmd);
                if (cmd == ClsTaskRuning.SC_CMD_SYNC_WORK_STARTING)
                {
                    this.Invoke((Action)delegate{lblLastRunTime.Text = "备份中...";});
                }
                else if (cmd == ClsTaskRuning.SC_CMD_SYNC_WORK_COMPLETED)
                {
                    this.Invoke((Action)delegate { cfg.Target.RefreshCatelog(); lblLastRunTime.Text = "备份结束"; refrshList(false); });
                }
            };
            tc.OnConnect += (ciso, cosi) => { this.Invoke((Action)delegate { btnRunBackupOnce.ForeColor = Color.DarkBlue; }); };
            tc.OnDisconnect += (ciso, cosi) => { this.Invoke((Action)delegate { btnRunBackupOnce.ForeColor = SystemColors.ControlText; }); };
            tc.initClient();

            if (IMKCode.ServiceHelper.IsAdministrator && IMKCode.ServiceHelper.ExistService(ClsService.SC_SERVICE_NAME))
            {
                lblServiceStatus.Text = "Service";
            }

            this.setScaler();
        }

        private void OnSplitterMoved(object sender, SplitterEventArgs e)
        {
            setScaler();
        }

        private void FrmConfig_SizeChanged(object sender, EventArgs e)
        {
            resetScaler();
        }

        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="syncService">同步配置到后台服务</param>
        private void refrshList(bool syncService)
        {
            lbxSource.DataSource = cfg.UserFolder.ToArray();
            lbxExclude.DataSource = cfg.FolderExclude.ToArray();
            if (cfg.FileType.FilterStatus == 0)
            {
                lbxFileTypes.Enabled = false;
            }
            else
            {
                lbxFileTypes.Enabled = true;
                if (cfg.FileType.FilterStatus == 1)
                {
                    lbxFileTypes.DataSource = cfg.FileType.ChoosedTypes;
                    lbxFileTypes.Refresh();
                }
                else if (cfg.FileType.FilterStatus == 2)
                {
                    lbxFileTypes.DataSource = cfg.FileType.ExcludeTypes; 
                    lbxFileTypes.Refresh();
                }
            }

            if (cfg.Target != null)
            {
                lblTargetDevice.Text = cfg.Target.Drive;
                if (System.IO.Directory.Exists(cfg.Target.Drive))
                {
                    System.IO.DriveInfo _di = new System.IO.DriveInfo(cfg.Target.Drive);
                    lblDiskSize.Text = string.Format("可用空间：{0}, 总空间：{1}", _di.TotalFreeSpace.ToGB(), _di.TotalSize.ToGB());
                }
                
                //lblHistorySize.Text = cfg.Target.GetTotalSize().ToGB(2);
                cfg.Target.GetTotalSizeAsync(n => this.Invoke((Action)delegate { lblHistorySize.Text = n.ToGB(2); }));
                
                DateTime? _lastDoneTime = cfg.Target.GetCatelog().lastDoneTime;
                if (_lastDoneTime != null)
                {
                    lblLastRunTime.Text = _lastDoneTime.Value.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    lblLastRunTime.Text = "未进行备份...";
                }
            }
            else
            {
                lblTargetDevice.Text = "IMK: 请选择驱动器";
            }

            if (syncService)
            {
                if (tc != null && tc.IsConnected)
                {
                    tc.SendRefreshConfig();
                }
            }

        }

        private void lbtnSourceAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                string _addPath = diag.SelectedPath.Replace("\\", "/");
                if (!cfg.UserFolder.Contains(_addPath, StringComparer.CurrentCultureIgnoreCase))
                {
                    cfg.UserFolder.Add(_addPath);
                    cfg.save();
                }

                this.refrshList(true);
            }

        }

        private void lbtnSourceDel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cfg.UserFolder.Remove(lbxSource.SelectedItem.ToString()); 
            cfg.save();
            this.refrshList(true);
        }

        private void lbtnExcludeAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                string _excPath = diag.SelectedPath.Replace("\\", "/");
                if (!cfg.FolderExclude.Contains(_excPath, StringComparer.CurrentCultureIgnoreCase))
                {
                    cfg.FolderExclude.Add(_excPath);
                    cfg.save();
                }

                this.refrshList(true);
            }
        }

        private void lbtnExcludeDel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cfg.FolderExclude.Remove(lbxExclude.SelectedItem.ToString()); 
            cfg.save();
            this.refrshList(true);
        }

        private void lbtnExcludeAddKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string _excludeKey;
            if (FrmPrompt.Prompt("", "", "", out _excludeKey, 0))
            {
                _excludeKey = _excludeKey.Replace("\\", "/");
                if (!cfg.FolderExclude.Contains(_excludeKey, StringComparer.CurrentCultureIgnoreCase))
                {
                    cfg.FolderExclude.Add(_excludeKey);
                    cfg.save();
                }

                this.refrshList(true);
            }
        }

        private void lbtnFileTypeAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string _extName;
            if (FrmPrompt.Prompt(cfg.FileType.FilterStatus == 1 ? "要备份的文件类型" : cfg.FileType.FilterStatus == 2 ? "不备份的文件类型": "", "", "文件后辍名", out _extName, 0))
            {
                if (cfg.FileType.FilterStatus == 1)
                {
                    if (!cfg.FileType.ChoosedTypes.Contains(_extName, StringComparer.CurrentCultureIgnoreCase))
                    {
                        cfg.FileType.ChoosedTypes.Add(_extName);
                    }
                }
                else if (cfg.FileType.FilterStatus == 2)
                {
                    if (!cfg.FileType.ExcludeTypes.Contains(_extName, StringComparer.CurrentCultureIgnoreCase))
                    {
                        cfg.FileType.ExcludeTypes.Add(_extName);
                    }
                }
                cfg.save();
                this.refrshList(true);
            }
        }

        private void lbtnFileTypeDel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string _extName = lbxFileTypes.SelectedItem.ToString();
            if (cfg.FileType.FilterStatus == 1)
            {
                cfg.FileType.ChoosedTypes.Remove(_extName);
                cfg.save();
                this.refrshList(true);
            }
            else if (cfg.FileType.FilterStatus == 2)
            {
                cfg.FileType.ExcludeTypes.Remove(_extName);
                cfg.save();
                this.refrshList(true);
            }
        }

        private void rbtnFileTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            cfg.FileType.FilterStatus = 0; cfg.save();
            pelFileTypesBtns.Enabled = false;
            this.refrshList(true);
        }

        private void rbtnFileTypeChoose_CheckedChanged(object sender, EventArgs e)
        {
            cfg.FileType.FilterStatus = 1; cfg.save();
            pelFileTypesBtns.Enabled = true;
            this.refrshList(true);
        }

        private void rbtnFileTypeExclude_CheckedChanged(object sender, EventArgs e)
        {
            cfg.FileType.FilterStatus = 2; cfg.save();
            pelFileTypesBtns.Enabled = true;
            this.refrshList(true);
        }

        private void lbtnTargetDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDrives diagDrives = new FrmDrives();
            diagDrives.Icon = this.Icon;
            if (diagDrives.ShowDialog() == DialogResult.OK)
            {
                TargetConfig target = new TargetConfig(diagDrives.SelectDrive);
                cfg.SetTarget(target);
                cfg.save();
                this.refrshList(true);
            }
            
        }

        private void cbxScheduleTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.from_inited)
            {
                object _item = cbxScheduleTimes.SelectedItem;
                if (_item is EnumItem<EnScheduleTimes>)
                {
                    EnScheduleTimes _value = ((EnumItem<EnScheduleTimes>)_item).item;
                    if (_value != cfg.DPFrequency)
                    {
                        cfg.DPFrequency = _value;
                        cfg.save();
                        this.refrshList(true);
                    }
                }
            }
        }

        private void cbxKeepTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.from_inited)
            {
                object _item = cbxKeepTimes.SelectedItem;
                if (_item is EnumItem<EnFileKeepTimes>)
                {
                    EnFileKeepTimes _value = ((EnumItem<EnFileKeepTimes>)_item).item;
                    if (_value != cfg.Retention)
                    {
                        cfg.Retention = _value;
                        cfg.save();
                        this.refrshList(true);
                    }
                }
            }
        }

        private void lbtnRunClean_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tc.IsConnected)
            {
                tc.SendManualClean();
            }
            else
            {
                //| TODO: 未完成...
            }
        }

        DateTime _now_manual;
        private void btnRunBackupOnce_Click(object sender, EventArgs e)
        {
            _now_manual = DateTime.Now;
            if (tc.IsConnected)
            {
                tc.SendManualBackup();
            }
            else
            {
                lblLastRunTime.Text = "手动备份...";
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    using (ClsTaskRuning rr = new ClsTaskRuning())
                    {
                        rr.OnTaskItemStart += (source) => { writeLog("开始备份: " + source); };
                        rr.OnTaskItemCompleted += (source, diffs) => { writeLog("备份 " + source +" 完成("+ diffs.Count() +" 项)"); };
                        rr.OnAllTaskCompleted += (ss, args)=>
                        {
                            if (args is BackupResult)
                            {
                                var _dtm = DateTime.Now.Subtract(_now_manual);
                                BackupResult result = (BackupResult)args;
                                writeLog("files: " + result.diffs.Count + " times: " + _dtm.TotalSeconds + " s");
                            }
                        };
                        rr.manualStart();
                    }
                });
            }
            this.refrshList(false);
        }


        private void writeLog(string msg)
        {
            string _logLine = string.Format("{0}\t{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
            //if (isPauseLog) { return; }
            if (txtLogs.InvokeRequired)
            {
                txtLogs.Invoke((Action)delegate
                {
                    txtLogs.AppendText(_logLine);
                });
            }
            else
            {
                txtLogs.AppendText(_logLine);
            }
        }

        private void cmnuServiceInstall_Click(object sender, EventArgs e)
        {
            if (IMKCode.ServiceHelper.IsAdministrator)
            {
                IMKCode.ServiceHelper.RunInstall();
            }
            else
            {
                MessageBox.Show("请以管理员身份运行，再执行安装和卸载操作！", "安装权限不足", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmnuServiceUninstall_Click(object sender, EventArgs e)
        {
            if (IMKCode.ServiceHelper.IsAdministrator)
            {
                IMKCode.ServiceHelper.RunUninstall();
            }
            else
            {
                MessageBox.Show("请以管理员身份运行，再执行安装和卸载操作！", "卸载权限", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmnuServicStart_Click(object sender, EventArgs e)
        {
            if (IMKCode.ServiceHelper.IsAdministrator)
            {
                using (System.ServiceProcess.ServiceController control = new System.ServiceProcess.ServiceController(ClsService.SC_SERVICE_NAME))
                {
                    if (control.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                    {
                        control.Start();
                    }
                }
            }
            else
            {
                writeLog("IMK: 启用服务需管理员权限.");
            }

        }

        private void cmnuServicStop_Click(object sender, EventArgs e)
        {
            if (IMKCode.ServiceHelper.IsAdministrator)
            {
                using (System.ServiceProcess.ServiceController control = new System.ServiceProcess.ServiceController(ClsService.SC_SERVICE_NAME))
                {
                    if (control.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                    {
                        control.Stop();
                    }
                }
            }
            else
            {
                writeLog("IMK: 停止服务需管理员权限.");
            }
        }

        private void cmnuServiceCommTest_Click(object sender, EventArgs e)
        {
            if (tc != null)
            {
                if (tc.IsConnected)
                {
                    writeLog("send: test");
                    tc.addSendTask("test");
                }
                else
                {
                    writeLog("服务未连接...");
                }
            }
            else
            {
                writeLog("客户端未打开...");
            }
        }

    }
}

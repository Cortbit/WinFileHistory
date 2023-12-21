
namespace WinFileHistory
{
    partial class FrmConfig
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.lbtnSourceDel = new System.Windows.Forms.LinkLabel();
            this.lbxSource = new System.Windows.Forms.ListBox();
            this.lbtnSourceAdd = new System.Windows.Forms.LinkLabel();
            this.grpExclude = new System.Windows.Forms.GroupBox();
            this.lbtnExcludeDel = new System.Windows.Forms.LinkLabel();
            this.lbxExclude = new System.Windows.Forms.ListBox();
            this.lbtnExcludeAddKey = new System.Windows.Forms.LinkLabel();
            this.lbtnExcludeAdd = new System.Windows.Forms.LinkLabel();
            this.grpFileType = new System.Windows.Forms.GroupBox();
            this.pelFileTypesBtns = new System.Windows.Forms.Panel();
            this.lbtnFileTypeAdd = new System.Windows.Forms.LinkLabel();
            this.lbtnFileTypeDel = new System.Windows.Forms.LinkLabel();
            this.pelFileTypes = new System.Windows.Forms.Panel();
            this.rbtnFileTypeExclude = new System.Windows.Forms.RadioButton();
            this.rbtnFileTypeAll = new System.Windows.Forms.RadioButton();
            this.rbtnFileTypeChoose = new System.Windows.Forms.RadioButton();
            this.lbxFileTypes = new System.Windows.Forms.ListBox();
            this.grpTarget = new System.Windows.Forms.GroupBox();
            this.btnRunBackupOnce = new System.Windows.Forms.Button();
            this.lbtnRunClean = new System.Windows.Forms.LinkLabel();
            this.lblLastRunTimeText = new System.Windows.Forms.Label();
            this.lblDiskSizeText = new System.Windows.Forms.Label();
            this.lblHistorySizeText = new System.Windows.Forms.Label();
            this.lblLastRunTime = new System.Windows.Forms.Label();
            this.grpLogs = new System.Windows.Forms.GroupBox();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.grpKeepTimes = new System.Windows.Forms.GroupBox();
            this.cbxKeepTimes = new System.Windows.Forms.ComboBox();
            this.lblDiskSize = new System.Windows.Forms.Label();
            this.grpSchedule = new System.Windows.Forms.GroupBox();
            this.cbxScheduleTimes = new System.Windows.Forms.ComboBox();
            this.lblHistorySize = new System.Windows.Forms.Label();
            this.lblTargetDevice = new System.Windows.Forms.Label();
            this.lbtnTargetDevice = new System.Windows.Forms.LinkLabel();
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.cmnuService = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuServicStart = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuServicStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuServiceCommTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuServiceInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuServiceUninstall = new System.Windows.Forms.ToolStripMenuItem();
            this.splSource = new System.Windows.Forms.Splitter();
            this.splExclude = new System.Windows.Forms.Splitter();
            this.splFileTypes = new System.Windows.Forms.Splitter();
            this.splTarget = new System.Windows.Forms.Splitter();
            this.cmnuFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuFileMenuReg = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuFileMenuUnReg = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.grpSource.SuspendLayout();
            this.grpExclude.SuspendLayout();
            this.grpFileType.SuspendLayout();
            this.pelFileTypesBtns.SuspendLayout();
            this.pelFileTypes.SuspendLayout();
            this.grpTarget.SuspendLayout();
            this.grpLogs.SuspendLayout();
            this.grpKeepTimes.SuspendLayout();
            this.grpSchedule.SuspendLayout();
            this.cmnuService.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.lbtnSourceDel);
            this.grpSource.Controls.Add(this.lbxSource);
            this.grpSource.Controls.Add(this.lbtnSourceAdd);
            this.grpSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpSource.Location = new System.Drawing.Point(8, 8);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(239, 585);
            this.grpSource.TabIndex = 0;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "备份这些文件夹";
            // 
            // lbtnSourceDel
            // 
            this.lbtnSourceDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtnSourceDel.Location = new System.Drawing.Point(197, 17);
            this.lbtnSourceDel.Name = "lbtnSourceDel";
            this.lbtnSourceDel.Size = new System.Drawing.Size(36, 16);
            this.lbtnSourceDel.TabIndex = 2;
            this.lbtnSourceDel.TabStop = true;
            this.lbtnSourceDel.Text = "删除";
            this.lbtnSourceDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbtnSourceDel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnSourceDel_LinkClicked);
            // 
            // lbxSource
            // 
            this.lbxSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxSource.BackColor = System.Drawing.SystemColors.Control;
            this.lbxSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxSource.FormattingEnabled = true;
            this.lbxSource.ItemHeight = 12;
            this.lbxSource.Location = new System.Drawing.Point(6, 37);
            this.lbxSource.Name = "lbxSource";
            this.lbxSource.Size = new System.Drawing.Size(227, 542);
            this.lbxSource.TabIndex = 1;
            // 
            // lbtnSourceAdd
            // 
            this.lbtnSourceAdd.Location = new System.Drawing.Point(6, 17);
            this.lbtnSourceAdd.Name = "lbtnSourceAdd";
            this.lbtnSourceAdd.Size = new System.Drawing.Size(87, 16);
            this.lbtnSourceAdd.TabIndex = 0;
            this.lbtnSourceAdd.TabStop = true;
            this.lbtnSourceAdd.Text = "添加文件夹";
            this.lbtnSourceAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbtnSourceAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnSourceAdd_LinkClicked);
            // 
            // grpExclude
            // 
            this.grpExclude.Controls.Add(this.lbtnExcludeDel);
            this.grpExclude.Controls.Add(this.lbxExclude);
            this.grpExclude.Controls.Add(this.lbtnExcludeAddKey);
            this.grpExclude.Controls.Add(this.lbtnExcludeAdd);
            this.grpExclude.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpExclude.Location = new System.Drawing.Point(252, 8);
            this.grpExclude.Name = "grpExclude";
            this.grpExclude.Size = new System.Drawing.Size(239, 585);
            this.grpExclude.TabIndex = 0;
            this.grpExclude.TabStop = false;
            this.grpExclude.Text = "排除这些文件夹";
            // 
            // lbtnExcludeDel
            // 
            this.lbtnExcludeDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtnExcludeDel.Location = new System.Drawing.Point(197, 18);
            this.lbtnExcludeDel.Name = "lbtnExcludeDel";
            this.lbtnExcludeDel.Size = new System.Drawing.Size(36, 16);
            this.lbtnExcludeDel.TabIndex = 2;
            this.lbtnExcludeDel.TabStop = true;
            this.lbtnExcludeDel.Text = "删除";
            this.lbtnExcludeDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbtnExcludeDel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnExcludeDel_LinkClicked);
            // 
            // lbxExclude
            // 
            this.lbxExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxExclude.BackColor = System.Drawing.SystemColors.Control;
            this.lbxExclude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxExclude.FormattingEnabled = true;
            this.lbxExclude.ItemHeight = 12;
            this.lbxExclude.Location = new System.Drawing.Point(6, 37);
            this.lbxExclude.Name = "lbxExclude";
            this.lbxExclude.Size = new System.Drawing.Size(227, 542);
            this.lbxExclude.TabIndex = 1;
            // 
            // lbtnExcludeAddKey
            // 
            this.lbtnExcludeAddKey.Location = new System.Drawing.Point(99, 17);
            this.lbtnExcludeAddKey.Name = "lbtnExcludeAddKey";
            this.lbtnExcludeAddKey.Size = new System.Drawing.Size(87, 16);
            this.lbtnExcludeAddKey.TabIndex = 0;
            this.lbtnExcludeAddKey.TabStop = true;
            this.lbtnExcludeAddKey.Text = "添加名称";
            this.lbtnExcludeAddKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbtnExcludeAddKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnExcludeAddKey_LinkClicked);
            // 
            // lbtnExcludeAdd
            // 
            this.lbtnExcludeAdd.Location = new System.Drawing.Point(6, 17);
            this.lbtnExcludeAdd.Name = "lbtnExcludeAdd";
            this.lbtnExcludeAdd.Size = new System.Drawing.Size(87, 16);
            this.lbtnExcludeAdd.TabIndex = 0;
            this.lbtnExcludeAdd.TabStop = true;
            this.lbtnExcludeAdd.Text = "添加文件夹";
            this.lbtnExcludeAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbtnExcludeAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnExcludeAdd_LinkClicked);
            // 
            // grpFileType
            // 
            this.grpFileType.Controls.Add(this.pelFileTypesBtns);
            this.grpFileType.Controls.Add(this.pelFileTypes);
            this.grpFileType.Controls.Add(this.lbxFileTypes);
            this.grpFileType.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpFileType.Location = new System.Drawing.Point(496, 8);
            this.grpFileType.Name = "grpFileType";
            this.grpFileType.Size = new System.Drawing.Size(239, 585);
            this.grpFileType.TabIndex = 0;
            this.grpFileType.TabStop = false;
            this.grpFileType.Text = "文件类型过滤";
            // 
            // pelFileTypesBtns
            // 
            this.pelFileTypesBtns.Controls.Add(this.lbtnFileTypeAdd);
            this.pelFileTypesBtns.Controls.Add(this.lbtnFileTypeDel);
            this.pelFileTypesBtns.Location = new System.Drawing.Point(6, 37);
            this.pelFileTypesBtns.Name = "pelFileTypesBtns";
            this.pelFileTypesBtns.Size = new System.Drawing.Size(227, 23);
            this.pelFileTypesBtns.TabIndex = 3;
            // 
            // lbtnFileTypeAdd
            // 
            this.lbtnFileTypeAdd.Location = new System.Drawing.Point(3, 3);
            this.lbtnFileTypeAdd.Name = "lbtnFileTypeAdd";
            this.lbtnFileTypeAdd.Size = new System.Drawing.Size(87, 16);
            this.lbtnFileTypeAdd.TabIndex = 0;
            this.lbtnFileTypeAdd.TabStop = true;
            this.lbtnFileTypeAdd.Text = "添加后辍";
            this.lbtnFileTypeAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbtnFileTypeAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnFileTypeAdd_LinkClicked);
            // 
            // lbtnFileTypeDel
            // 
            this.lbtnFileTypeDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtnFileTypeDel.Location = new System.Drawing.Point(188, 3);
            this.lbtnFileTypeDel.Name = "lbtnFileTypeDel";
            this.lbtnFileTypeDel.Size = new System.Drawing.Size(36, 16);
            this.lbtnFileTypeDel.TabIndex = 2;
            this.lbtnFileTypeDel.TabStop = true;
            this.lbtnFileTypeDel.Text = "删除";
            this.lbtnFileTypeDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbtnFileTypeDel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnFileTypeDel_LinkClicked);
            // 
            // pelFileTypes
            // 
            this.pelFileTypes.Controls.Add(this.rbtnFileTypeExclude);
            this.pelFileTypes.Controls.Add(this.rbtnFileTypeAll);
            this.pelFileTypes.Controls.Add(this.rbtnFileTypeChoose);
            this.pelFileTypes.Location = new System.Drawing.Point(6, 13);
            this.pelFileTypes.Name = "pelFileTypes";
            this.pelFileTypes.Size = new System.Drawing.Size(227, 23);
            this.pelFileTypes.TabIndex = 2;
            // 
            // rbtnFileTypeExclude
            // 
            this.rbtnFileTypeExclude.AutoSize = true;
            this.rbtnFileTypeExclude.Location = new System.Drawing.Point(129, 4);
            this.rbtnFileTypeExclude.Name = "rbtnFileTypeExclude";
            this.rbtnFileTypeExclude.Size = new System.Drawing.Size(59, 16);
            this.rbtnFileTypeExclude.TabIndex = 0;
            this.rbtnFileTypeExclude.TabStop = true;
            this.rbtnFileTypeExclude.Text = "排除法";
            this.rbtnFileTypeExclude.UseVisualStyleBackColor = true;
            this.rbtnFileTypeExclude.CheckedChanged += new System.EventHandler(this.rbtnFileTypeExclude_CheckedChanged);
            // 
            // rbtnFileTypeAll
            // 
            this.rbtnFileTypeAll.AutoSize = true;
            this.rbtnFileTypeAll.Location = new System.Drawing.Point(7, 4);
            this.rbtnFileTypeAll.Name = "rbtnFileTypeAll";
            this.rbtnFileTypeAll.Size = new System.Drawing.Size(47, 16);
            this.rbtnFileTypeAll.TabIndex = 0;
            this.rbtnFileTypeAll.TabStop = true;
            this.rbtnFileTypeAll.Text = "所有";
            this.rbtnFileTypeAll.UseVisualStyleBackColor = true;
            this.rbtnFileTypeAll.CheckedChanged += new System.EventHandler(this.rbtnFileTypeAll_CheckedChanged);
            // 
            // rbtnFileTypeChoose
            // 
            this.rbtnFileTypeChoose.AutoSize = true;
            this.rbtnFileTypeChoose.Location = new System.Drawing.Point(62, 4);
            this.rbtnFileTypeChoose.Name = "rbtnFileTypeChoose";
            this.rbtnFileTypeChoose.Size = new System.Drawing.Size(59, 16);
            this.rbtnFileTypeChoose.TabIndex = 0;
            this.rbtnFileTypeChoose.TabStop = true;
            this.rbtnFileTypeChoose.Text = "筛选法";
            this.rbtnFileTypeChoose.UseVisualStyleBackColor = true;
            this.rbtnFileTypeChoose.CheckedChanged += new System.EventHandler(this.rbtnFileTypeChoose_CheckedChanged);
            // 
            // lbxFileTypes
            // 
            this.lbxFileTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxFileTypes.BackColor = System.Drawing.SystemColors.Control;
            this.lbxFileTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxFileTypes.FormattingEnabled = true;
            this.lbxFileTypes.ItemHeight = 12;
            this.lbxFileTypes.Location = new System.Drawing.Point(6, 61);
            this.lbxFileTypes.Name = "lbxFileTypes";
            this.lbxFileTypes.Size = new System.Drawing.Size(227, 518);
            this.lbxFileTypes.TabIndex = 1;
            // 
            // grpTarget
            // 
            this.grpTarget.Controls.Add(this.btnRunBackupOnce);
            this.grpTarget.Controls.Add(this.lbtnRunClean);
            this.grpTarget.Controls.Add(this.lblLastRunTimeText);
            this.grpTarget.Controls.Add(this.lblDiskSizeText);
            this.grpTarget.Controls.Add(this.lblHistorySizeText);
            this.grpTarget.Controls.Add(this.lblLastRunTime);
            this.grpTarget.Controls.Add(this.grpLogs);
            this.grpTarget.Controls.Add(this.grpKeepTimes);
            this.grpTarget.Controls.Add(this.lblDiskSize);
            this.grpTarget.Controls.Add(this.grpSchedule);
            this.grpTarget.Controls.Add(this.lblHistorySize);
            this.grpTarget.Controls.Add(this.lblTargetDevice);
            this.grpTarget.Controls.Add(this.lbtnTargetDevice);
            this.grpTarget.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpTarget.Location = new System.Drawing.Point(740, 8);
            this.grpTarget.Name = "grpTarget";
            this.grpTarget.Size = new System.Drawing.Size(239, 585);
            this.grpTarget.TabIndex = 1;
            this.grpTarget.TabStop = false;
            this.grpTarget.Text = "保存位置";
            // 
            // btnRunBackupOnce
            // 
            this.btnRunBackupOnce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunBackupOnce.Location = new System.Drawing.Point(158, 194);
            this.btnRunBackupOnce.Name = "btnRunBackupOnce";
            this.btnRunBackupOnce.Size = new System.Drawing.Size(75, 23);
            this.btnRunBackupOnce.TabIndex = 4;
            this.btnRunBackupOnce.Text = "立即备份";
            this.btnRunBackupOnce.UseVisualStyleBackColor = true;
            this.btnRunBackupOnce.Click += new System.EventHandler(this.btnRunBackupOnce_Click);
            // 
            // lbtnRunClean
            // 
            this.lbtnRunClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtnRunClean.Location = new System.Drawing.Point(170, 62);
            this.lbtnRunClean.Name = "lbtnRunClean";
            this.lbtnRunClean.Size = new System.Drawing.Size(63, 16);
            this.lbtnRunClean.TabIndex = 2;
            this.lbtnRunClean.TabStop = true;
            this.lbtnRunClean.Text = "清理版本";
            this.lbtnRunClean.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbtnRunClean.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnRunClean_LinkClicked);
            // 
            // lblLastRunTimeText
            // 
            this.lblLastRunTimeText.AutoSize = true;
            this.lblLastRunTimeText.Location = new System.Drawing.Point(6, 154);
            this.lblLastRunTimeText.Name = "lblLastRunTimeText";
            this.lblLastRunTimeText.Size = new System.Drawing.Size(77, 12);
            this.lblLastRunTimeText.TabIndex = 3;
            this.lblLastRunTimeText.Text = "上次备份时间";
            // 
            // lblDiskSizeText
            // 
            this.lblDiskSizeText.AutoSize = true;
            this.lblDiskSizeText.Location = new System.Drawing.Point(6, 110);
            this.lblDiskSizeText.Name = "lblDiskSizeText";
            this.lblDiskSizeText.Size = new System.Drawing.Size(53, 12);
            this.lblDiskSizeText.TabIndex = 3;
            this.lblDiskSizeText.Text = "磁盘空间";
            // 
            // lblHistorySizeText
            // 
            this.lblHistorySizeText.AutoSize = true;
            this.lblHistorySizeText.Location = new System.Drawing.Point(6, 64);
            this.lblHistorySizeText.Name = "lblHistorySizeText";
            this.lblHistorySizeText.Size = new System.Drawing.Size(53, 12);
            this.lblHistorySizeText.TabIndex = 3;
            this.lblHistorySizeText.Text = "备份大小";
            // 
            // lblLastRunTime
            // 
            this.lblLastRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastRunTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLastRunTime.Location = new System.Drawing.Point(8, 168);
            this.lblLastRunTime.Name = "lblLastRunTime";
            this.lblLastRunTime.Size = new System.Drawing.Size(225, 23);
            this.lblLastRunTime.TabIndex = 1;
            this.lblLastRunTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpLogs
            // 
            this.grpLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogs.Controls.Add(this.txtLogs);
            this.grpLogs.Location = new System.Drawing.Point(8, 341);
            this.grpLogs.Name = "grpLogs";
            this.grpLogs.Size = new System.Drawing.Size(226, 238);
            this.grpLogs.TabIndex = 2;
            this.grpLogs.TabStop = false;
            this.grpLogs.Text = "事件日志";
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogs.Location = new System.Drawing.Point(7, 21);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(213, 210);
            this.txtLogs.TabIndex = 0;
            this.txtLogs.WordWrap = false;
            // 
            // grpKeepTimes
            // 
            this.grpKeepTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKeepTimes.Controls.Add(this.cbxKeepTimes);
            this.grpKeepTimes.Location = new System.Drawing.Point(8, 282);
            this.grpKeepTimes.Name = "grpKeepTimes";
            this.grpKeepTimes.Size = new System.Drawing.Size(226, 53);
            this.grpKeepTimes.TabIndex = 2;
            this.grpKeepTimes.TabStop = false;
            this.grpKeepTimes.Text = "保留我的文件";
            // 
            // cbxKeepTimes
            // 
            this.cbxKeepTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxKeepTimes.FormattingEnabled = true;
            this.cbxKeepTimes.Location = new System.Drawing.Point(7, 21);
            this.cbxKeepTimes.Name = "cbxKeepTimes";
            this.cbxKeepTimes.Size = new System.Drawing.Size(213, 20);
            this.cbxKeepTimes.TabIndex = 0;
            this.cbxKeepTimes.SelectedIndexChanged += new System.EventHandler(this.cbxKeepTimes_SelectedIndexChanged);
            // 
            // lblDiskSize
            // 
            this.lblDiskSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiskSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiskSize.Location = new System.Drawing.Point(8, 124);
            this.lblDiskSize.Name = "lblDiskSize";
            this.lblDiskSize.Size = new System.Drawing.Size(225, 23);
            this.lblDiskSize.TabIndex = 1;
            this.lblDiskSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpSchedule
            // 
            this.grpSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSchedule.Controls.Add(this.cbxScheduleTimes);
            this.grpSchedule.Location = new System.Drawing.Point(8, 223);
            this.grpSchedule.Name = "grpSchedule";
            this.grpSchedule.Size = new System.Drawing.Size(226, 53);
            this.grpSchedule.TabIndex = 2;
            this.grpSchedule.TabStop = false;
            this.grpSchedule.Text = "备份我的文件";
            // 
            // cbxScheduleTimes
            // 
            this.cbxScheduleTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxScheduleTimes.FormattingEnabled = true;
            this.cbxScheduleTimes.Location = new System.Drawing.Point(7, 21);
            this.cbxScheduleTimes.Name = "cbxScheduleTimes";
            this.cbxScheduleTimes.Size = new System.Drawing.Size(213, 20);
            this.cbxScheduleTimes.TabIndex = 0;
            this.cbxScheduleTimes.SelectedIndexChanged += new System.EventHandler(this.cbxScheduleTimes_SelectedIndexChanged);
            // 
            // lblHistorySize
            // 
            this.lblHistorySize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHistorySize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHistorySize.Location = new System.Drawing.Point(8, 78);
            this.lblHistorySize.Name = "lblHistorySize";
            this.lblHistorySize.Size = new System.Drawing.Size(225, 23);
            this.lblHistorySize.TabIndex = 1;
            this.lblHistorySize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTargetDevice
            // 
            this.lblTargetDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetDevice.Location = new System.Drawing.Point(8, 37);
            this.lblTargetDevice.Name = "lblTargetDevice";
            this.lblTargetDevice.Size = new System.Drawing.Size(225, 23);
            this.lblTargetDevice.TabIndex = 1;
            this.lblTargetDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtnTargetDevice
            // 
            this.lbtnTargetDevice.Location = new System.Drawing.Point(6, 17);
            this.lbtnTargetDevice.Name = "lbtnTargetDevice";
            this.lbtnTargetDevice.Size = new System.Drawing.Size(87, 16);
            this.lbtnTargetDevice.TabIndex = 0;
            this.lbtnTargetDevice.TabStop = true;
            this.lbtnTargetDevice.Text = "选择驱动器";
            this.lbtnTargetDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbtnTargetDevice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnTargetDevice_LinkClicked);
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceStatus.ContextMenuStrip = this.cmnuService;
            this.lblServiceStatus.Location = new System.Drawing.Point(935, 7);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(45, 16);
            this.lblServiceStatus.TabIndex = 2;
            this.lblServiceStatus.Text = "--";
            this.lblServiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmnuService
            // 
            this.cmnuService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuFileMenu,
            this.toolStripMenuItem3,
            this.cmnuServicStart,
            this.cmnuServicStop,
            this.toolStripMenuItem1,
            this.cmnuServiceCommTest,
            this.toolStripMenuItem2,
            this.cmnuServiceInstall,
            this.cmnuServiceUninstall});
            this.cmnuService.Name = "cmnuService";
            this.cmnuService.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmnuService.Size = new System.Drawing.Size(181, 176);
            // 
            // cmnuServicStart
            // 
            this.cmnuServicStart.Name = "cmnuServicStart";
            this.cmnuServicStart.Size = new System.Drawing.Size(180, 22);
            this.cmnuServicStart.Text = "启动服务(&S)";
            this.cmnuServicStart.Click += new System.EventHandler(this.cmnuServicStart_Click);
            // 
            // cmnuServicStop
            // 
            this.cmnuServicStop.Name = "cmnuServicStop";
            this.cmnuServicStop.Size = new System.Drawing.Size(180, 22);
            this.cmnuServicStop.Text = "停止服务(&E)";
            this.cmnuServicStop.Click += new System.EventHandler(this.cmnuServicStop_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // cmnuServiceCommTest
            // 
            this.cmnuServiceCommTest.Name = "cmnuServiceCommTest";
            this.cmnuServiceCommTest.Size = new System.Drawing.Size(180, 22);
            this.cmnuServiceCommTest.Text = "通信测试(&T)";
            this.cmnuServiceCommTest.Click += new System.EventHandler(this.cmnuServiceCommTest_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // cmnuServiceInstall
            // 
            this.cmnuServiceInstall.Name = "cmnuServiceInstall";
            this.cmnuServiceInstall.Size = new System.Drawing.Size(180, 22);
            this.cmnuServiceInstall.Text = "安装服务";
            this.cmnuServiceInstall.Click += new System.EventHandler(this.cmnuServiceInstall_Click);
            // 
            // cmnuServiceUninstall
            // 
            this.cmnuServiceUninstall.Name = "cmnuServiceUninstall";
            this.cmnuServiceUninstall.Size = new System.Drawing.Size(180, 22);
            this.cmnuServiceUninstall.Text = "卸载服务";
            this.cmnuServiceUninstall.Click += new System.EventHandler(this.cmnuServiceUninstall_Click);
            // 
            // splSource
            // 
            this.splSource.Location = new System.Drawing.Point(247, 8);
            this.splSource.Name = "splSource";
            this.splSource.Size = new System.Drawing.Size(5, 585);
            this.splSource.TabIndex = 3;
            this.splSource.TabStop = false;
            this.splSource.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.OnSplitterMoved);
            // 
            // splExclude
            // 
            this.splExclude.Location = new System.Drawing.Point(491, 8);
            this.splExclude.Name = "splExclude";
            this.splExclude.Size = new System.Drawing.Size(5, 585);
            this.splExclude.TabIndex = 4;
            this.splExclude.TabStop = false;
            this.splExclude.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.OnSplitterMoved);
            // 
            // splFileTypes
            // 
            this.splFileTypes.Location = new System.Drawing.Point(735, 8);
            this.splFileTypes.Name = "splFileTypes";
            this.splFileTypes.Size = new System.Drawing.Size(5, 585);
            this.splFileTypes.TabIndex = 5;
            this.splFileTypes.TabStop = false;
            this.splFileTypes.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.OnSplitterMoved);
            // 
            // splTarget
            // 
            this.splTarget.Location = new System.Drawing.Point(979, 8);
            this.splTarget.Name = "splTarget";
            this.splTarget.Size = new System.Drawing.Size(5, 585);
            this.splTarget.TabIndex = 6;
            this.splTarget.TabStop = false;
            this.splTarget.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.OnSplitterMoved);
            // 
            // cmnuFileMenu
            // 
            this.cmnuFileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuFileMenuReg,
            this.cmnuFileMenuUnReg});
            this.cmnuFileMenu.Name = "cmnuFileMenu";
            this.cmnuFileMenu.Size = new System.Drawing.Size(180, 22);
            this.cmnuFileMenu.Text = "文件菜单";
            // 
            // cmnuFileMenuReg
            // 
            this.cmnuFileMenuReg.Name = "cmnuFileMenuReg";
            this.cmnuFileMenuReg.Size = new System.Drawing.Size(180, 22);
            this.cmnuFileMenuReg.Text = "注册";
            this.cmnuFileMenuReg.Click += new System.EventHandler(this.cmnuFileMenuReg_Click);
            // 
            // cmnuFileMenuUnReg
            // 
            this.cmnuFileMenuUnReg.Name = "cmnuFileMenuUnReg";
            this.cmnuFileMenuUnReg.Size = new System.Drawing.Size(180, 22);
            this.cmnuFileMenuUnReg.Text = "移除";
            this.cmnuFileMenuUnReg.Click += new System.EventHandler(this.cmnuFileMenuUnReg_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 601);
            this.Controls.Add(this.lblServiceStatus);
            this.Controls.Add(this.splTarget);
            this.Controls.Add(this.grpTarget);
            this.Controls.Add(this.splFileTypes);
            this.Controls.Add(this.grpFileType);
            this.Controls.Add(this.splExclude);
            this.Controls.Add(this.grpExclude);
            this.Controls.Add(this.splSource);
            this.Controls.Add(this.grpSource);
            this.Name = "FrmConfig";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "File History Config - IMKCode";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.SizeChanged += new System.EventHandler(this.FrmConfig_SizeChanged);
            this.grpSource.ResumeLayout(false);
            this.grpExclude.ResumeLayout(false);
            this.grpFileType.ResumeLayout(false);
            this.pelFileTypesBtns.ResumeLayout(false);
            this.pelFileTypes.ResumeLayout(false);
            this.pelFileTypes.PerformLayout();
            this.grpTarget.ResumeLayout(false);
            this.grpTarget.PerformLayout();
            this.grpLogs.ResumeLayout(false);
            this.grpLogs.PerformLayout();
            this.grpKeepTimes.ResumeLayout(false);
            this.grpSchedule.ResumeLayout(false);
            this.cmnuService.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.ListBox lbxSource;
        private System.Windows.Forms.LinkLabel lbtnSourceAdd;
        private System.Windows.Forms.GroupBox grpExclude;
        private System.Windows.Forms.ListBox lbxExclude;
        private System.Windows.Forms.LinkLabel lbtnExcludeAdd;
        private System.Windows.Forms.GroupBox grpFileType;
        private System.Windows.Forms.Panel pelFileTypes;
        private System.Windows.Forms.RadioButton rbtnFileTypeExclude;
        private System.Windows.Forms.RadioButton rbtnFileTypeChoose;
        private System.Windows.Forms.ListBox lbxFileTypes;
        private System.Windows.Forms.LinkLabel lbtnFileTypeAdd;
        private System.Windows.Forms.LinkLabel lbtnExcludeAddKey;
        private System.Windows.Forms.GroupBox grpTarget;
        private System.Windows.Forms.LinkLabel lbtnTargetDevice;
        private System.Windows.Forms.Label lblTargetDevice;
        private System.Windows.Forms.Label lblDiskSizeText;
        private System.Windows.Forms.Label lblHistorySizeText;
        private System.Windows.Forms.GroupBox grpKeepTimes;
        private System.Windows.Forms.ComboBox cbxKeepTimes;
        private System.Windows.Forms.Label lblDiskSize;
        private System.Windows.Forms.GroupBox grpSchedule;
        private System.Windows.Forms.ComboBox cbxScheduleTimes;
        private System.Windows.Forms.Label lblHistorySize;
        private System.Windows.Forms.Label lblLastRunTimeText;
        private System.Windows.Forms.Label lblLastRunTime;
        private System.Windows.Forms.Button btnRunBackupOnce;
        private System.Windows.Forms.GroupBox grpLogs;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.RadioButton rbtnFileTypeAll;
        private System.Windows.Forms.LinkLabel lbtnSourceDel;
        private System.Windows.Forms.LinkLabel lbtnExcludeDel;
        private System.Windows.Forms.LinkLabel lbtnFileTypeDel;
        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.ContextMenuStrip cmnuService;
        private System.Windows.Forms.ToolStripMenuItem cmnuServiceInstall;
        private System.Windows.Forms.ToolStripMenuItem cmnuServiceUninstall;
        private System.Windows.Forms.ToolStripMenuItem cmnuServicStart;
        private System.Windows.Forms.ToolStripMenuItem cmnuServicStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmnuServiceCommTest;
        private System.Windows.Forms.Panel pelFileTypesBtns;
        private System.Windows.Forms.LinkLabel lbtnRunClean;
        private System.Windows.Forms.Splitter splSource;
        private System.Windows.Forms.Splitter splExclude;
        private System.Windows.Forms.Splitter splFileTypes;
        private System.Windows.Forms.Splitter splTarget;
        private System.Windows.Forms.ToolStripMenuItem cmnuFileMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnuFileMenuReg;
        private System.Windows.Forms.ToolStripMenuItem cmnuFileMenuUnReg;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}



namespace WinFileHistory
{
    partial class FrmDrives
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstDrives = new System.Windows.Forms.ListView();
            this.drive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.asize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbtnAddNetworkPath = new System.Windows.Forms.LinkLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDrives
            // 
            this.lstDrives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDrives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.drive,
            this.asize,
            this.tsize});
            this.lstDrives.FullRowSelect = true;
            this.lstDrives.HideSelection = false;
            this.lstDrives.Location = new System.Drawing.Point(13, 13);
            this.lstDrives.Name = "lstDrives";
            this.lstDrives.Size = new System.Drawing.Size(439, 123);
            this.lstDrives.TabIndex = 0;
            this.lstDrives.UseCompatibleStateImageBehavior = false;
            this.lstDrives.View = System.Windows.Forms.View.Details;
            this.lstDrives.SelectedIndexChanged += new System.EventHandler(this.lstDrives_SelectedIndexChanged);
            // 
            // drive
            // 
            this.drive.Text = "可用驱动器";
            this.drive.Width = 150;
            // 
            // asize
            // 
            this.asize.Text = "可用空间";
            this.asize.Width = 140;
            // 
            // tsize
            // 
            this.tsize.Text = "总空间";
            this.tsize.Width = 140;
            // 
            // lbtnAddNetworkPath
            // 
            this.lbtnAddNetworkPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtnAddNetworkPath.AutoSize = true;
            this.lbtnAddNetworkPath.Location = new System.Drawing.Point(375, 139);
            this.lbtnAddNetworkPath.Name = "lbtnAddNetworkPath";
            this.lbtnAddNetworkPath.Size = new System.Drawing.Size(77, 12);
            this.lbtnAddNetworkPath.TabIndex = 1;
            this.lbtnAddNetworkPath.TabStop = true;
            this.lbtnAddNetworkPath.Text = "添加网络位置";
            this.lbtnAddNetworkPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnAddNetworkPath_LinkClicked);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(292, 161);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(377, 161);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmDrives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 191);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbtnAddNetworkPath);
            this.Controls.Add(this.lstDrives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDrives";
            this.Text = "选择驱动器";
            this.Load += new System.EventHandler(this.FrmDrives_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstDrives;
        private System.Windows.Forms.ColumnHeader drive;
        private System.Windows.Forms.ColumnHeader asize;
        private System.Windows.Forms.ColumnHeader tsize;
        private System.Windows.Forms.LinkLabel lbtnAddNetworkPath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
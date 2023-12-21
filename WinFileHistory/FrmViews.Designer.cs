
namespace WinFileHistory
{
    partial class FrmViews
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
            this.components = new System.ComponentModel.Container();
            this.pelHead = new System.Windows.Forms.Panel();
            this.pelFoot = new System.Windows.Forms.Panel();
            this.cbxSource = new System.Windows.Forms.ComboBox();
            this.lstView = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pelBody = new System.Windows.Forms.Panel();
            this.pelLeft = new System.Windows.Forms.Panel();
            this.pelRight = new System.Windows.Forms.Panel();
            this.cmnuView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuViewPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRestore = new System.Windows.Forms.Button();
            this.cmnuRestore = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuRestoreTo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRestoreAs = new System.Windows.Forms.ToolStripMenuItem();
            this.pelHead.SuspendLayout();
            this.pelFoot.SuspendLayout();
            this.pelBody.SuspendLayout();
            this.cmnuView.SuspendLayout();
            this.cmnuRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // pelHead
            // 
            this.pelHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pelHead.Controls.Add(this.cbxSource);
            this.pelHead.Location = new System.Drawing.Point(13, 13);
            this.pelHead.Name = "pelHead";
            this.pelHead.Size = new System.Drawing.Size(775, 28);
            this.pelHead.TabIndex = 0;
            // 
            // pelFoot
            // 
            this.pelFoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pelFoot.Controls.Add(this.btnRestore);
            this.pelFoot.Location = new System.Drawing.Point(13, 391);
            this.pelFoot.Name = "pelFoot";
            this.pelFoot.Size = new System.Drawing.Size(775, 47);
            this.pelFoot.TabIndex = 0;
            // 
            // cbxSource
            // 
            this.cbxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSource.FormattingEnabled = true;
            this.cbxSource.Location = new System.Drawing.Point(87, 4);
            this.cbxSource.Name = "cbxSource";
            this.cbxSource.Size = new System.Drawing.Size(572, 20);
            this.cbxSource.TabIndex = 0;
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colMDate,
            this.colType,
            this.colSize});
            this.lstView.ContextMenuStrip = this.cmnuView;
            this.lstView.FullRowSelect = true;
            this.lstView.HideSelection = false;
            this.lstView.Location = new System.Drawing.Point(3, 3);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(701, 327);
            this.lstView.TabIndex = 0;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "名称";
            this.colName.Width = 300;
            // 
            // colMDate
            // 
            this.colMDate.Text = "修改日期";
            this.colMDate.Width = 150;
            // 
            // colType
            // 
            this.colType.Text = "类型";
            this.colType.Width = 120;
            // 
            // colSize
            // 
            this.colSize.Text = "大小";
            this.colSize.Width = 100;
            // 
            // pelBody
            // 
            this.pelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pelBody.Controls.Add(this.lstView);
            this.pelBody.Location = new System.Drawing.Point(46, 47);
            this.pelBody.Name = "pelBody";
            this.pelBody.Size = new System.Drawing.Size(709, 335);
            this.pelBody.TabIndex = 1;
            // 
            // pelLeft
            // 
            this.pelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pelLeft.Location = new System.Drawing.Point(-2, 47);
            this.pelLeft.Name = "pelLeft";
            this.pelLeft.Size = new System.Drawing.Size(42, 335);
            this.pelLeft.TabIndex = 2;
            // 
            // pelRight
            // 
            this.pelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pelRight.Location = new System.Drawing.Point(760, 47);
            this.pelRight.Name = "pelRight";
            this.pelRight.Size = new System.Drawing.Size(42, 335);
            this.pelRight.TabIndex = 2;
            // 
            // cmnuView
            // 
            this.cmnuView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuViewPreview});
            this.cmnuView.Name = "cmnuView";
            this.cmnuView.Size = new System.Drawing.Size(101, 26);
            // 
            // cmnuViewPreview
            // 
            this.cmnuViewPreview.Name = "cmnuViewPreview";
            this.cmnuViewPreview.Size = new System.Drawing.Size(100, 22);
            this.cmnuViewPreview.Text = "预览";
            this.cmnuViewPreview.Click += new System.EventHandler(this.cmnuViewPreview_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRestore.ContextMenuStrip = this.cmnuRestore;
            this.btnRestore.Location = new System.Drawing.Point(351, 12);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 0;
            this.btnRestore.Text = "还原";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // cmnuRestore
            // 
            this.cmnuRestore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuRestoreTo,
            this.cmnuRestoreAs});
            this.cmnuRestore.Name = "cmnuRestore";
            this.cmnuRestore.Size = new System.Drawing.Size(113, 48);
            // 
            // cmnuRestoreTo
            // 
            this.cmnuRestoreTo.Name = "cmnuRestoreTo";
            this.cmnuRestoreTo.Size = new System.Drawing.Size(180, 22);
            this.cmnuRestoreTo.Text = "还原";
            this.cmnuRestoreTo.Click += new System.EventHandler(this.cmnuRestoreTo_Click);
            // 
            // cmnuRestoreAs
            // 
            this.cmnuRestoreAs.Name = "cmnuRestoreAs";
            this.cmnuRestoreAs.Size = new System.Drawing.Size(180, 22);
            this.cmnuRestoreAs.Text = "还原为";
            this.cmnuRestoreAs.Click += new System.EventHandler(this.cmnuRestoreAs_Click);
            // 
            // FrmViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pelRight);
            this.Controls.Add(this.pelLeft);
            this.Controls.Add(this.pelBody);
            this.Controls.Add(this.pelFoot);
            this.Controls.Add(this.pelHead);
            this.Name = "FrmViews";
            this.Text = "FrmViews";
            this.Load += new System.EventHandler(this.FrmViews_Load);
            this.pelHead.ResumeLayout(false);
            this.pelFoot.ResumeLayout(false);
            this.pelBody.ResumeLayout(false);
            this.cmnuView.ResumeLayout(false);
            this.cmnuRestore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pelHead;
        private System.Windows.Forms.Panel pelFoot;
        private System.Windows.Forms.ComboBox cbxSource;
        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colMDate;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.Panel pelBody;
        private System.Windows.Forms.Panel pelLeft;
        private System.Windows.Forms.Panel pelRight;
        private System.Windows.Forms.ContextMenuStrip cmnuView;
        private System.Windows.Forms.ToolStripMenuItem cmnuViewPreview;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ContextMenuStrip cmnuRestore;
        private System.Windows.Forms.ToolStripMenuItem cmnuRestoreTo;
        private System.Windows.Forms.ToolStripMenuItem cmnuRestoreAs;
    }
}
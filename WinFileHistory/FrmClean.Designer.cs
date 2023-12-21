
namespace WinFileHistory
{
    partial class FrmClean
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDelTimes = new System.Windows.Forms.Label();
            this.cbxKeepTimes = new System.Windows.Forms.ComboBox();
            this.btnDoClean = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(61, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(273, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "删除旧版本的文件";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(61, 32);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(273, 56);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "清理次删除比选定期限早的文件版本，但最新的版本的文件除外。对于新排除的文件夹，不作删除。";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDelTimes
            // 
            this.lblDelTimes.AutoSize = true;
            this.lblDelTimes.Location = new System.Drawing.Point(63, 92);
            this.lblDelTimes.Name = "lblDelTimes";
            this.lblDelTimes.Size = new System.Drawing.Size(65, 12);
            this.lblDelTimes.TabIndex = 1;
            this.lblDelTimes.Text = "删除文件：";
            // 
            // cbxKeepTimes
            // 
            this.cbxKeepTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxKeepTimes.FormattingEnabled = true;
            this.cbxKeepTimes.Location = new System.Drawing.Point(65, 107);
            this.cbxKeepTimes.Name = "cbxKeepTimes";
            this.cbxKeepTimes.Size = new System.Drawing.Size(269, 20);
            this.cbxKeepTimes.TabIndex = 2;
            // 
            // btnDoClean
            // 
            this.btnDoClean.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDoClean.Location = new System.Drawing.Point(176, 146);
            this.btnDoClean.Name = "btnDoClean";
            this.btnDoClean.Size = new System.Drawing.Size(75, 23);
            this.btnDoClean.TabIndex = 3;
            this.btnDoClean.Text = "清理(&C)";
            this.btnDoClean.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(259, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmClean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 183);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDoClean);
            this.Controls.Add(this.cbxKeepTimes);
            this.Controls.Add(this.lblDelTimes);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClean";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文件历史记录清理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDelTimes;
        private System.Windows.Forms.ComboBox cbxKeepTimes;
        private System.Windows.Forms.Button btnDoClean;
        private System.Windows.Forms.Button btnCancel;
    }
}
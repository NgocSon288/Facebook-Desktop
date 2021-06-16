
namespace Facebook.Components.Messenger
{
    partial class ShareFilesItemUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFileName = new System.Windows.Forms.Label();
            this.picIcon = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFileName.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(14, 5);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(49, 15);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "label1";
            this.lblFileName.Click += new System.EventHandler(this.picIcon_Click);
            this.lblFileName.MouseEnter += new System.EventHandler(this.ShareFilesItemUC_MouseEnter);
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.SystemColors.Control;
            this.picIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.picIcon.IconColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picIcon.IconSize = 15;
            this.picIcon.Location = new System.Drawing.Point(267, 8);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(15, 15);
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.picIcon_Click);
            this.picIcon.MouseEnter += new System.EventHandler(this.ShareFilesItemUC_MouseEnter);
            // 
            // ShareFilesItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblFileName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ShareFilesItemUC";
            this.Size = new System.Drawing.Size(298, 30);
            this.Click += new System.EventHandler(this.picIcon_Click);
            this.MouseEnter += new System.EventHandler(this.ShareFilesItemUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ShareFilesItemUC_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileName;
        private FontAwesome.Sharp.IconPictureBox picIcon;
    }
}

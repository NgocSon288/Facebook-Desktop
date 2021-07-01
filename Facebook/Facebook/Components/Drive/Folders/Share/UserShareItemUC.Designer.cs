
namespace Facebook.Components.Drive.Folders.Share
{
    partial class UserShareItemUC
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
            this.pnlWrap = new System.Windows.Forms.Panel();
            this.rdbShared = new Bunifu.Framework.UI.BunifuCheckbox();
            this.lblName = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.pnlWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.rdbShared);
            this.pnlWrap.Controls.Add(this.lblName);
            this.pnlWrap.Controls.Add(this.picAvatar);
            this.pnlWrap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrap.Location = new System.Drawing.Point(2, 2);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(344, 46);
            this.pnlWrap.TabIndex = 0;
            this.pnlWrap.Click += new System.EventHandler(this.picAvatar_Click);
            this.pnlWrap.MouseEnter += new System.EventHandler(this.pnlWrap_MouseEnter);
            this.pnlWrap.MouseLeave += new System.EventHandler(this.pnlWrap_MouseLeave);
            // 
            // rdbShared
            // 
            this.rdbShared.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.rdbShared.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.rdbShared.Checked = true;
            this.rdbShared.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.rdbShared.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbShared.ForeColor = System.Drawing.Color.White;
            this.rdbShared.Location = new System.Drawing.Point(307, 18);
            this.rdbShared.Margin = new System.Windows.Forms.Padding(6);
            this.rdbShared.Name = "rdbShared";
            this.rdbShared.Size = new System.Drawing.Size(20, 20);
            this.rdbShared.TabIndex = 7;
            this.rdbShared.OnChange += new System.EventHandler(this.rdbStatus_OnChange);
            this.rdbShared.Click += new System.EventHandler(this.picAvatar_Click);
            this.rdbShared.MouseEnter += new System.EventHandler(this.pnlWrap_MouseEnter);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(51, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.picAvatar_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.pnlWrap_MouseEnter);
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(10, 5);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(36, 36);
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            this.picAvatar.MouseEnter += new System.EventHandler(this.pnlWrap_MouseEnter);
            // 
            // UserShareItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserShareItemUC";
            this.Size = new System.Drawing.Size(348, 50);
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
        private Bunifu.Framework.UI.BunifuCheckbox rdbShared;
    }
}

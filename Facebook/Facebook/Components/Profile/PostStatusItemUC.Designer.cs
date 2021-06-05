
namespace Facebook.Components.Profile
{
    partial class PostStatusItemUC
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
            this.picBg = new System.Windows.Forms.PictureBox();
            this.picIcon = new FontAwesome.Sharp.IconPictureBox();
            this.lblParagraph = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rdbStatus = new Bunifu.Framework.UI.BunifuCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.picBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picBg
            // 
            this.picBg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBg.Location = new System.Drawing.Point(5, 5);
            this.picBg.Margin = new System.Windows.Forms.Padding(0);
            this.picBg.Name = "picBg";
            this.picBg.Size = new System.Drawing.Size(65, 68);
            this.picBg.TabIndex = 0;
            this.picBg.TabStop = false;
            this.picBg.Click += new System.EventHandler(this.picBg_Click);
            this.picBg.MouseHover += new System.EventHandler(this.PostStatusItemUC_MouseEnter);
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.SystemColors.Control;
            this.picIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconChar = FontAwesome.Sharp.IconChar.None;
            this.picIcon.IconColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picIcon.IconSize = 25;
            this.picIcon.Location = new System.Drawing.Point(25, 26);
            this.picIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(25, 26);
            this.picIcon.TabIndex = 2;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.picBg_Click);
            this.picIcon.MouseHover += new System.EventHandler(this.PostStatusItemUC_MouseEnter);
            // 
            // lblParagraph
            // 
            this.lblParagraph.AutoSize = true;
            this.lblParagraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblParagraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParagraph.Location = new System.Drawing.Point(86, 38);
            this.lblParagraph.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParagraph.Name = "lblParagraph";
            this.lblParagraph.Size = new System.Drawing.Size(265, 20);
            this.lblParagraph.TabIndex = 4;
            this.lblParagraph.Text = "Mọi  người trên hoặc ngoài facebook";
            this.lblParagraph.Click += new System.EventHandler(this.picBg_Click);
            this.lblParagraph.MouseHover += new System.EventHandler(this.PostStatusItemUC_MouseEnter);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(86, 17);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(95, 24);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Công khai";
            this.lblTitle.Click += new System.EventHandler(this.picBg_Click);
            this.lblTitle.MouseHover += new System.EventHandler(this.PostStatusItemUC_MouseEnter);
            // 
            // rdbStatus
            // 
            this.rdbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.rdbStatus.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.rdbStatus.Checked = true;
            this.rdbStatus.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.rdbStatus.ForeColor = System.Drawing.Color.White;
            this.rdbStatus.Location = new System.Drawing.Point(469, 32);
            this.rdbStatus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rdbStatus.Name = "rdbStatus";
            this.rdbStatus.Size = new System.Drawing.Size(20, 20);
            this.rdbStatus.TabIndex = 6;
            this.rdbStatus.Click += new System.EventHandler(this.picBg_Click);
            this.rdbStatus.MouseHover += new System.EventHandler(this.PostStatusItemUC_MouseEnter);
            // 
            // PostStatusItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.rdbStatus);
            this.Controls.Add(this.lblParagraph);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.picBg);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "PostStatusItemUC";
            this.Size = new System.Drawing.Size(623, 85);
            this.Click += new System.EventHandler(this.picBg_Click);
            this.MouseEnter += new System.EventHandler(this.PostStatusItemUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.PostStatusItemUC_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBg;
        private FontAwesome.Sharp.IconPictureBox picIcon;
        private System.Windows.Forms.Label lblParagraph;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuCheckbox rdbStatus;
    }
}

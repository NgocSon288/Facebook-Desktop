
namespace Facebook.Components.Messenger
{
    partial class MessengerFriendItemUC
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
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDesctiption = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(10, 10);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(60, 60);
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            this.picAvatar.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(80, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.picAvatar_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            // 
            // lblDesctiption
            // 
            this.lblDesctiption.AutoSize = true;
            this.lblDesctiption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDesctiption.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesctiption.Location = new System.Drawing.Point(82, 41);
            this.lblDesctiption.Name = "lblDesctiption";
            this.lblDesctiption.Size = new System.Drawing.Size(203, 15);
            this.lblDesctiption.TabIndex = 2;
            this.lblDesctiption.Text = "Các bạn hiện đã được kết nối";
            this.lblDesctiption.Click += new System.EventHandler(this.picAvatar_Click);
            this.lblDesctiption.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            // 
            // MessengerFriendItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDesctiption);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picAvatar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MessengerFriendItemUC";
            this.Size = new System.Drawing.Size(297, 80);
            this.Click += new System.EventHandler(this.picAvatar_Click);
            this.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MessengerFriendItemUC_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picAvatar;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblDesctiption;
    }
}

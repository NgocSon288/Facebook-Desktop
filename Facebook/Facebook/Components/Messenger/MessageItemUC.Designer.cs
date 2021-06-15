
namespace Facebook.Components.Messenger
{
    partial class MessageItemUC
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
            this.picFriendAvatarLeft = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.picFriendAvatarRight = new System.Windows.Forms.PictureBox();
            this.picIconSent = new FontAwesome.Sharp.IconPictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picFriendAvatarLeft)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFriendAvatarRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconSent)).BeginInit();
            this.SuspendLayout();
            // 
            // picFriendAvatarLeft
            // 
            this.picFriendAvatarLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picFriendAvatarLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFriendAvatarLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picFriendAvatarLeft.Location = new System.Drawing.Point(5, 85);
            this.picFriendAvatarLeft.Margin = new System.Windows.Forms.Padding(0);
            this.picFriendAvatarLeft.Name = "picFriendAvatarLeft";
            this.picFriendAvatarLeft.Size = new System.Drawing.Size(25, 25);
            this.picFriendAvatarLeft.TabIndex = 0;
            this.picFriendAvatarLeft.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.Controls.Add(this.picIconSent);
            this.pnlRight.Controls.Add(this.picFriendAvatarRight);
            this.pnlRight.Location = new System.Drawing.Point(379, 94);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(15, 15);
            this.pnlRight.TabIndex = 0;
            // 
            // picFriendAvatarRight
            // 
            this.picFriendAvatarRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFriendAvatarRight.Location = new System.Drawing.Point(0, 0);
            this.picFriendAvatarRight.Margin = new System.Windows.Forms.Padding(0);
            this.picFriendAvatarRight.Name = "picFriendAvatarRight";
            this.picFriendAvatarRight.Size = new System.Drawing.Size(15, 15);
            this.picFriendAvatarRight.TabIndex = 0;
            this.picFriendAvatarRight.TabStop = false;
            // 
            // picIconSent
            // 
            this.picIconSent.BackColor = System.Drawing.SystemColors.Control;
            this.picIconSent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.picIconSent.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.picIconSent.IconColor = System.Drawing.Color.RoyalBlue;
            this.picIconSent.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picIconSent.IconSize = 15;
            this.picIconSent.Location = new System.Drawing.Point(0, 0);
            this.picIconSent.Margin = new System.Windows.Forms.Padding(0);
            this.picIconSent.Name = "picIconSent";
            this.picIconSent.Size = new System.Drawing.Size(15, 15);
            this.picIconSent.TabIndex = 1;
            this.picIconSent.TabStop = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Location = new System.Drawing.Point(39, 3);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(330, 106);
            this.pnlContent.TabIndex = 1;
            // 
            // MessageItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.picFriendAvatarLeft);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "MessageItemUC";
            this.Size = new System.Drawing.Size(397, 110);
            ((System.ComponentModel.ISupportInitialize)(this.picFriendAvatarLeft)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFriendAvatarRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconSent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picFriendAvatarLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PictureBox picFriendAvatarRight;
        private FontAwesome.Sharp.IconPictureBox picIconSent;
        private System.Windows.Forms.Panel pnlContent;
    }
}

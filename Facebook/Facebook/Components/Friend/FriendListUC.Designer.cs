
namespace Facebook.Components.Friend
{
    partial class FriendListUC
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
            this.flpList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRequestedFriend = new System.Windows.Forms.Panel();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.flpList.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpList
            // 
            this.flpList.AutoScroll = true;
            this.flpList.Controls.Add(this.pnlRequestedFriend);
            this.flpList.Controls.Add(this.pnlUser);
            this.flpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpList.Location = new System.Drawing.Point(0, 0);
            this.flpList.Margin = new System.Windows.Forms.Padding(0);
            this.flpList.Name = "flpList";
            this.flpList.Size = new System.Drawing.Size(250, 664);
            this.flpList.TabIndex = 0;
            // 
            // pnlRequestedFriend
            // 
            this.pnlRequestedFriend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlRequestedFriend.Location = new System.Drawing.Point(0, 0);
            this.pnlRequestedFriend.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRequestedFriend.Name = "pnlRequestedFriend";
            this.pnlRequestedFriend.Size = new System.Drawing.Size(250, 300);
            this.pnlRequestedFriend.TabIndex = 0;
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlUser.Location = new System.Drawing.Point(0, 300);
            this.pnlUser.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(250, 364);
            this.pnlUser.TabIndex = 1;
            // 
            // FriendListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.flpList);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendListUC";
            this.Size = new System.Drawing.Size(250, 664);
            this.flpList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpList;
        private System.Windows.Forms.Panel pnlRequestedFriend;
        private System.Windows.Forms.Panel pnlUser;
    }
}

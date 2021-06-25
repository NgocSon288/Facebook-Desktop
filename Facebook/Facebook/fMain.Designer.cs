
namespace Facebook
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new FontAwesome.Sharp.IconButton();
            this.btnAccount = new FontAwesome.Sharp.IconButton();
            this.btnMessenger = new FontAwesome.Sharp.IconButton();
            this.btnFriends = new FontAwesome.Sharp.IconButton();
            this.btnProfile = new FontAwesome.Sharp.IconButton();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1000, 800);
            this.panelContent.TabIndex = 3;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnAccount);
            this.panelMenu.Controls.Add(this.btnMessenger);
            this.panelMenu.Controls.Add(this.btnFriends);
            this.panelMenu.Controls.Add(this.btnProfile);
            this.panelMenu.Controls.Add(this.imgLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 800);
            this.panelMenu.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.IconChar = FontAwesome.Sharp.IconChar.ObjectUngroup;
            this.btnLogout.IconColor = System.Drawing.Color.White;
            this.btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 749);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 40, 0);
            this.btnLogout.Size = new System.Drawing.Size(200, 51);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.TabStop = false;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAccount.ForeColor = System.Drawing.Color.White;
            this.btnAccount.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpenText;
            this.btnAccount.IconColor = System.Drawing.Color.White;
            this.btnAccount.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.Location = new System.Drawing.Point(0, 223);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Padding = new System.Windows.Forms.Padding(10, 0, 40, 0);
            this.btnAccount.Size = new System.Drawing.Size(200, 51);
            this.btnAccount.TabIndex = 4;
            this.btnAccount.TabStop = false;
            this.btnAccount.Text = "Drive";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnMessenger
            // 
            this.btnMessenger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMessenger.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMessenger.FlatAppearance.BorderSize = 0;
            this.btnMessenger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.btnMessenger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnMessenger.ForeColor = System.Drawing.Color.White;
            this.btnMessenger.IconChar = FontAwesome.Sharp.IconChar.Music;
            this.btnMessenger.IconColor = System.Drawing.Color.White;
            this.btnMessenger.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMessenger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMessenger.Location = new System.Drawing.Point(0, 172);
            this.btnMessenger.Margin = new System.Windows.Forms.Padding(0);
            this.btnMessenger.Name = "btnMessenger";
            this.btnMessenger.Padding = new System.Windows.Forms.Padding(10, 0, 40, 0);
            this.btnMessenger.Size = new System.Drawing.Size(200, 51);
            this.btnMessenger.TabIndex = 3;
            this.btnMessenger.TabStop = false;
            this.btnMessenger.Text = "Messenger";
            this.btnMessenger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMessenger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMessenger.UseVisualStyleBackColor = false;
            this.btnMessenger.Click += new System.EventHandler(this.btnMessenger_Click);
            // 
            // btnFriends
            // 
            this.btnFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFriends.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFriends.FlatAppearance.BorderSize = 0;
            this.btnFriends.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.btnFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnFriends.ForeColor = System.Drawing.Color.White;
            this.btnFriends.IconChar = FontAwesome.Sharp.IconChar.Mosque;
            this.btnFriends.IconColor = System.Drawing.Color.White;
            this.btnFriends.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFriends.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFriends.Location = new System.Drawing.Point(0, 121);
            this.btnFriends.Margin = new System.Windows.Forms.Padding(0);
            this.btnFriends.Name = "btnFriends";
            this.btnFriends.Padding = new System.Windows.Forms.Padding(10, 0, 40, 0);
            this.btnFriends.Size = new System.Drawing.Size(200, 51);
            this.btnFriends.TabIndex = 2;
            this.btnFriends.TabStop = false;
            this.btnFriends.Text = "Bạn bè";
            this.btnFriends.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFriends.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFriends.UseVisualStyleBackColor = false;
            this.btnFriends.Click += new System.EventHandler(this.btnFriends_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.IconChar = FontAwesome.Sharp.IconChar.NetworkWired;
            this.btnProfile.IconColor = System.Drawing.Color.White;
            this.btnProfile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(0, 70);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(0);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(10, 0, 40, 0);
            this.btnProfile.Size = new System.Drawing.Size(200, 51);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.TabStop = false;
            this.btnProfile.Text = "Cá nhân";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // imgLogo
            // 
            this.imgLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgLogo.BackgroundImage")));
            this.imgLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.imgLogo.Location = new System.Drawing.Point(0, 0);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(200, 70);
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
            this.imgLogo.Click += new System.EventHandler(this.imgLogo_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnAccount;
        private FontAwesome.Sharp.IconButton btnMessenger;
        private FontAwesome.Sharp.IconButton btnFriends;
        private FontAwesome.Sharp.IconButton btnProfile;
        private System.Windows.Forms.PictureBox imgLogo;
        private FontAwesome.Sharp.IconButton btnLogout;
    }
}


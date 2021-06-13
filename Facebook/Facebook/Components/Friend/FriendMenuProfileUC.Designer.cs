
namespace Facebook.Components.Friend
{
    partial class FriendMenuProfileUC
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
            this.components = new System.ComponentModel.Container();
            this.pnlWrap = new System.Windows.Forms.Panel();
            this.btnProfile = new FontAwesome.Sharp.IconButton();
            this.btnAddFriend = new FontAwesome.Sharp.IconButton();
            this.pnlBorderIntro = new System.Windows.Forms.Panel();
            this.pnlWrapIntro = new System.Windows.Forms.Panel();
            this.lblIntro = new System.Windows.Forms.Label();
            this.beBtnAdd = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.beBtnProfile = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlWrap.SuspendLayout();
            this.pnlWrapIntro.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.btnProfile);
            this.pnlWrap.Controls.Add(this.btnAddFriend);
            this.pnlWrap.Controls.Add(this.pnlBorderIntro);
            this.pnlWrap.Controls.Add(this.pnlWrapIntro);
            this.pnlWrap.Location = new System.Drawing.Point(8, 13);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(713, 74);
            this.pnlWrap.TabIndex = 4;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(136)))), ((int)(((byte)(255)))));
            this.btnProfile.FlatAppearance.BorderSize = 2;
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnProfile.IconColor = System.Drawing.Color.White;
            this.btnProfile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(549, 16);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(0);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(128, 44);
            this.btnProfile.TabIndex = 6;
            this.btnProfile.Text = "Xem thêm";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFriend.FlatAppearance.BorderSize = 0;
            this.btnAddFriend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.btnAddFriend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnAddFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAddFriend.ForeColor = System.Drawing.Color.White;
            this.btnAddFriend.IconChar = FontAwesome.Sharp.IconChar.UserTimes;
            this.btnAddFriend.IconColor = System.Drawing.Color.White;
            this.btnAddFriend.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddFriend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFriend.Location = new System.Drawing.Point(373, 16);
            this.btnAddFriend.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(154, 44);
            this.btnAddFriend.TabIndex = 5;
            this.btnAddFriend.Text = "Thêm bạn bè";
            this.btnAddFriend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFriend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddFriend.UseVisualStyleBackColor = false;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // pnlBorderIntro
            // 
            this.pnlBorderIntro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlBorderIntro.Location = new System.Drawing.Point(130, 63);
            this.pnlBorderIntro.Name = "pnlBorderIntro";
            this.pnlBorderIntro.Size = new System.Drawing.Size(225, 11);
            this.pnlBorderIntro.TabIndex = 4;
            // 
            // pnlWrapIntro
            // 
            this.pnlWrapIntro.Controls.Add(this.lblIntro);
            this.pnlWrapIntro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrapIntro.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlWrapIntro.Location = new System.Drawing.Point(130, 1);
            this.pnlWrapIntro.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapIntro.Name = "pnlWrapIntro";
            this.pnlWrapIntro.Size = new System.Drawing.Size(225, 60);
            this.pnlWrapIntro.TabIndex = 3;
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblIntro.Font = new System.Drawing.Font("Consolas", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.Location = new System.Drawing.Point(48, 21);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(110, 22);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "Giới thiệu";
            // 
            // beBtnAdd
            // 
            this.beBtnAdd.ElipseRadius = 20;
            this.beBtnAdd.TargetControl = this.btnAddFriend;
            // 
            // beBtnProfile
            // 
            this.beBtnProfile.ElipseRadius = 20;
            this.beBtnProfile.TargetControl = this.btnProfile;
            // 
            // FriendMenuProfileUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendMenuProfileUC";
            this.Size = new System.Drawing.Size(732, 100);
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrapIntro.ResumeLayout(false);
            this.pnlWrapIntro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.Panel pnlBorderIntro;
        private System.Windows.Forms.Panel pnlWrapIntro;
        private System.Windows.Forms.Label lblIntro;
        private Bunifu.Framework.UI.BunifuElipse beBtnAdd;
        private Bunifu.Framework.UI.BunifuElipse beBtnProfile;
        private FontAwesome.Sharp.IconButton btnProfile;
        private FontAwesome.Sharp.IconButton btnAddFriend;
    }
}

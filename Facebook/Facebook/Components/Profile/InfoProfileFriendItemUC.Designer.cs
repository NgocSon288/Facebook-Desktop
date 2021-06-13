
namespace Facebook.Components.Profile
{
    partial class InfoProfileFriendItemUC
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
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFriendCommon = new System.Windows.Forms.Label();
            this.btnBlock = new FontAwesome.Sharp.IconButton();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(15, 15);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(70, 70);
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            this.picAvatar.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(99, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 22);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.picAvatar_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            // 
            // lblFriendCommon
            // 
            this.lblFriendCommon.AutoSize = true;
            this.lblFriendCommon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFriendCommon.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFriendCommon.Location = new System.Drawing.Point(102, 51);
            this.lblFriendCommon.Name = "lblFriendCommon";
            this.lblFriendCommon.Size = new System.Drawing.Size(56, 18);
            this.lblFriendCommon.TabIndex = 2;
            this.lblFriendCommon.Text = "label1";
            this.lblFriendCommon.Click += new System.EventHandler(this.picAvatar_Click);
            this.lblFriendCommon.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            // 
            // btnBlock
            // 
            this.btnBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBlock.FlatAppearance.BorderSize = 0;
            this.btnBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlock.ForeColor = System.Drawing.Color.White;
            this.btnBlock.IconChar = FontAwesome.Sharp.IconChar.UserAltSlash;
            this.btnBlock.IconColor = System.Drawing.Color.White;
            this.btnBlock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBlock.IconSize = 36;
            this.btnBlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBlock.Location = new System.Drawing.Point(402, 68);
            this.btnBlock.Margin = new System.Windows.Forms.Padding(0);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(25, 25);
            this.btnBlock.TabIndex = 6;
            this.btnBlock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBlock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tt.SetToolTip(this.btnBlock, "Chặn người này");
            this.btnBlock.UseVisualStyleBackColor = false;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            this.btnBlock.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            this.btnBlock.MouseLeave += new System.EventHandler(this.btnBlock_MouseLeave);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.UserTimes;
            this.btnDelete.IconColor = System.Drawing.Color.White;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 36;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(436, 68);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tt.SetToolTip(this.btnDelete, "Hủy kết bạn với người này");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnBlock_MouseLeave);
            // 
            // tt
            // 
            this.tt.AutomaticDelay = 0;
            // 
            // InfoProfileFriendItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.lblFriendCommon);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picAvatar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InfoProfileFriendItemUC";
            this.Size = new System.Drawing.Size(469, 100);
            this.Click += new System.EventHandler(this.picAvatar_Click);
            this.MouseEnter += new System.EventHandler(this.picAvatar_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.InfoProfileFriendItemUC_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFriendCommon;
        private FontAwesome.Sharp.IconButton btnBlock;
        private FontAwesome.Sharp.IconButton btnDelete;
        private System.Windows.Forms.ToolTip tt;
    }
}

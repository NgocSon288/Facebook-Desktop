
namespace Facebook.Components.Profile
{
    partial class PostItemUC
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
            this.pnlHead = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.picPostStatusIcon = new FontAwesome.Sharp.IconPictureBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPostStatusIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlHead.Controls.Add(this.btnMenu);
            this.pnlHead.Controls.Add(this.pnlMenu);
            this.pnlHead.Controls.Add(this.picPostStatusIcon);
            this.pnlHead.Controls.Add(this.lblTime);
            this.pnlHead.Controls.Add(this.lblName);
            this.pnlHead.Controls.Add(this.picAvatar);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(464, 70);
            this.pnlHead.TabIndex = 0;
            this.pnlHead.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Location = new System.Drawing.Point(417, 12);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(20, 20);
            this.btnMenu.TabIndex = 69;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Red;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnDelete);
            this.pnlMenu.Controls.Add(this.btnEdit);
            this.pnlMenu.Location = new System.Drawing.Point(322, 9);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(92, 44);
            this.pnlMenu.TabIndex = 68;
            this.pnlMenu.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
            this.btnDelete.IconColor = System.Drawing.Color.Black;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.Location = new System.Drawing.Point(46, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 39);
            this.btnDelete.TabIndex = 68;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnEdit.IconColor = System.Drawing.Color.Black;
            this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEdit.Location = new System.Drawing.Point(6, 2);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(40, 40);
            this.btnEdit.TabIndex = 65;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // picPostStatusIcon
            // 
            this.picPostStatusIcon.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picPostStatusIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPostStatusIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picPostStatusIcon.IconChar = FontAwesome.Sharp.IconChar.NetworkWired;
            this.picPostStatusIcon.IconColor = System.Drawing.SystemColors.ControlText;
            this.picPostStatusIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picPostStatusIcon.IconSize = 23;
            this.picPostStatusIcon.Location = new System.Drawing.Point(205, 33);
            this.picPostStatusIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picPostStatusIcon.Name = "picPostStatusIcon";
            this.picPostStatusIcon.Size = new System.Drawing.Size(23, 23);
            this.picPostStatusIcon.TabIndex = 66;
            this.picPostStatusIcon.TabStop = false;
            this.picPostStatusIcon.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTime.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(74, 38);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(70, 15);
            this.lblTime.TabIndex = 64;
            this.lblTime.Text = "Công khai";
            this.lblTime.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(72, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(10, 10);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(50, 50);
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // pnlDescription
            // 
            this.pnlDescription.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlDescription.Controls.Add(this.lblDescription);
            this.pnlDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDescription.Location = new System.Drawing.Point(0, 70);
            this.pnlDescription.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(464, 81);
            this.pnlDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.lblDescription.Size = new System.Drawing.Size(464, 85);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "acebook Desktop nên chưa có hình ảnhHi các bạn acebook Desktop nên chưa có hình ả" +
    "nhHi các bạnacebook Desktop nên chưa có hình ảnhHi các bạn";
            this.lblDescription.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.picImage.Location = new System.Drawing.Point(0, 151);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(464, 152);
            this.picImage.TabIndex = 3;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // pnlComment
            // 
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComment.Location = new System.Drawing.Point(0, 303);
            this.pnlComment.Margin = new System.Windows.Forms.Padding(0);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(464, 120);
            this.pnlComment.TabIndex = 4;
            this.pnlComment.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // PostItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.pnlComment);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.pnlDescription);
            this.Controls.Add(this.pnlHead);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PostItemUC";
            this.Size = new System.Drawing.Size(464, 423);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPostStatusIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTime;
        private FontAwesome.Sharp.IconButton btnEdit;
        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel pnlComment;
        private FontAwesome.Sharp.IconPictureBox picPostStatusIcon;
        private System.Windows.Forms.Panel pnlMenu;
        private FontAwesome.Sharp.IconButton btnDelete;
        private System.Windows.Forms.PictureBox btnMenu;
    }
}

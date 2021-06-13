
namespace Facebook.Components.Friend
{
    partial class FriendRequestedItemUC
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
            this.lblName = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AccessibleDescription = "";
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(75, 8);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.FriendRequestedItemUC_MouseEnter);
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(6, 7);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(50, 50);
            this.picAvatar.TabIndex = 2;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.lblName_Click);
            this.picAvatar.MouseEnter += new System.EventHandler(this.FriendRequestedItemUC_MouseEnter);
            // 
            // btnAccept
            // 
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(72, 33);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(78, 32);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Xác nhận";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(153, 33);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 32);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FriendRequestedItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendRequestedItemUC";
            this.Size = new System.Drawing.Size(236, 70);
            this.Click += new System.EventHandler(this.lblName_Click);
            this.MouseEnter += new System.EventHandler(this.FriendRequestedItemUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FriendRequestedItemUC_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDelete;
    }
}

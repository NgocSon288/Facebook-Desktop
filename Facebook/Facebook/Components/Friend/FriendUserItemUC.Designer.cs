
namespace Facebook.Components.Friend
{
    partial class FriendUserItemUC
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
            this.btnBlock = new System.Windows.Forms.Button();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBlock
            // 
            this.btnBlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBlock.FlatAppearance.BorderSize = 0;
            this.btnBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlock.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlock.Location = new System.Drawing.Point(153, 33);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(78, 32);
            this.btnBlock.TabIndex = 8;
            this.btnBlock.Text = "Chặn";
            this.btnBlock.UseVisualStyleBackColor = true;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendRequest.FlatAppearance.BorderSize = 0;
            this.btnSendRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendRequest.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendRequest.Location = new System.Drawing.Point(72, 33);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(78, 32);
            this.btnSendRequest.TabIndex = 7;
            this.btnSendRequest.Text = "Kết bạn";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(6, 7);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(50, 50);
            this.picAvatar.TabIndex = 6;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.lblName_Click);
            this.picAvatar.MouseEnter += new System.EventHandler(this.FriendRequestedItemUC_MouseEnter);
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
            this.lblName.TabIndex = 5;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.FriendRequestedItemUC_MouseEnter);
            // 
            // FriendUserItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendUserItemUC";
            this.Size = new System.Drawing.Size(236, 70);
            this.Click += new System.EventHandler(this.lblName_Click);
            this.MouseEnter += new System.EventHandler(this.FriendRequestedItemUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FriendRequestedItemUC_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
    }
}

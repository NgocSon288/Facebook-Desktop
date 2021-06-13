
namespace Facebook.Components.Friend
{
    partial class FriendUserListUC
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(7, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(160, 22);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Có thể bạn biết";
            // 
            // flpItems
            // 
            this.flpItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.flpItems.Location = new System.Drawing.Point(0, 36);
            this.flpItems.Margin = new System.Windows.Forms.Padding(0);
            this.flpItems.Name = "flpItems";
            this.flpItems.Size = new System.Drawing.Size(250, 156);
            this.flpItems.TabIndex = 2;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.Location = new System.Drawing.Point(6, 205);
            this.pnlSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(243, 8);
            this.pnlSeparator.TabIndex = 4;
            // 
            // FriendUserListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.flpItems);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendUserListUC";
            this.Size = new System.Drawing.Size(250, 213);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpItems;
        private System.Windows.Forms.Panel pnlSeparator;
    }
}

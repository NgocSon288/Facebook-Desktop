
namespace Facebook.Components.Friend
{
    partial class FriendSearchBoxUC
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.iconSearch = new FontAwesome.Sharp.IconPictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlSeparator1 = new System.Windows.Forms.Panel();
            this.pnlSeparator2 = new System.Windows.Forms.Panel();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(5, 79);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(127, 34);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Bạn  bè";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.iconSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(3, 8);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(230, 45);
            this.pnlSearch.TabIndex = 2;
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconSearch.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearch.IconSize = 27;
            this.iconSearch.Location = new System.Drawing.Point(0, 0);
            this.iconSearch.Margin = new System.Windows.Forms.Padding(0);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Padding = new System.Windows.Forms.Padding(5, 11, 0, 0);
            this.iconSearch.Size = new System.Drawing.Size(27, 40);
            this.iconSearch.TabIndex = 65;
            this.iconSearch.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSearch.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(149)))), ((int)(((byte)(167)))));
            this.txtSearch.Location = new System.Drawing.Point(33, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(186, 41);
            this.txtSearch.TabIndex = 64;
            this.txtSearch.Text = "Tìm trên Facebook";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtMyCommentDescription_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pnlSeparator1
            // 
            this.pnlSeparator1.Location = new System.Drawing.Point(13, 68);
            this.pnlSeparator1.Name = "pnlSeparator1";
            this.pnlSeparator1.Size = new System.Drawing.Size(220, 8);
            this.pnlSeparator1.TabIndex = 3;
            // 
            // pnlSeparator2
            // 
            this.pnlSeparator2.Location = new System.Drawing.Point(13, 116);
            this.pnlSeparator2.Name = "pnlSeparator2";
            this.pnlSeparator2.Size = new System.Drawing.Size(220, 8);
            this.pnlSeparator2.TabIndex = 4;
            // 
            // FriendSearchBoxUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.pnlSeparator2);
            this.Controls.Add(this.pnlSeparator1);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendSearchBoxUC";
            this.Size = new System.Drawing.Size(236, 130);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSeparator1;
        private System.Windows.Forms.Panel pnlSeparator2;
        private System.Windows.Forms.TextBox txtSearch;
        private FontAwesome.Sharp.IconPictureBox iconSearch;
    }
}


namespace Facebook.Components.Drive.Folders.Share
{
    partial class fUserShare
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
            this.pnlHead = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlWrapSearch = new System.Windows.Forms.Panel();
            this.iconSearch = new FontAwesome.Sharp.IconPictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlHead.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlWrapSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.lblTitle);
            this.pnlHead.Location = new System.Drawing.Point(6, 4);
            this.pnlHead.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(339, 45);
            this.pnlHead.TabIndex = 0;
            this.pnlHead.Click += new System.EventHandler(this.pnlContent_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.pnlWrapSearch);
            this.pnlSearch.Location = new System.Drawing.Point(6, 55);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(339, 45);
            this.pnlSearch.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Location = new System.Drawing.Point(6, 106);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(339, 390);
            this.pnlContent.TabIndex = 1;
            this.pnlContent.Click += new System.EventHandler(this.pnlContent_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(50, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách Share";
            this.lblTitle.Click += new System.EventHandler(this.pnlContent_Click);
            // 
            // pnlWrapSearch
            // 
            this.pnlWrapSearch.Controls.Add(this.iconSearch);
            this.pnlWrapSearch.Controls.Add(this.txtSearch);
            this.pnlWrapSearch.Location = new System.Drawing.Point(2, 3);
            this.pnlWrapSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapSearch.Name = "pnlWrapSearch";
            this.pnlWrapSearch.Size = new System.Drawing.Size(344, 39);
            this.pnlWrapSearch.TabIndex = 3;
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconSearch.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearch.IconSize = 27;
            this.iconSearch.Location = new System.Drawing.Point(0, -2);
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
            this.txtSearch.Location = new System.Drawing.Point(33, 8);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(290, 41);
            this.txtSearch.TabIndex = 64;
            this.txtSearch.Text = "Tên bạn bè...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // fUserShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 500);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fUserShare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fUserShare";
            this.TopMost = true;
            this.Click += new System.EventHandler(this.pnlContent_Click);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlWrapSearch.ResumeLayout(false);
            this.pnlWrapSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlWrapSearch;
        private FontAwesome.Sharp.IconPictureBox iconSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}

namespace Facebook.FormUC
{
    partial class fFriend
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.picEmptyPeople = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblEmptyPeople = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.flpContent.SuspendLayout();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmptyPeople)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(970, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 21;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(937, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 22;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Text = "--";
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // flpContent
            // 
            this.flpContent.AutoScroll = true;
            this.flpContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flpContent.Controls.Add(this.pnlHead);
            this.flpContent.Controls.Add(this.pnlMenu);
            this.flpContent.Controls.Add(this.pnlMainContent);
            this.flpContent.Location = new System.Drawing.Point(250, 30);
            this.flpContent.Margin = new System.Windows.Forms.Padding(0);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(750, 765);
            this.flpContent.TabIndex = 23;
            // 
            // pnlHead
            // 
            this.pnlHead.AutoScroll = true;
            this.pnlHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnlHead.Controls.Add(this.picEmptyPeople);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(732, 394);
            this.pnlHead.TabIndex = 5;
            // 
            // picEmptyPeople
            // 
            this.picEmptyPeople.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEmptyPeople.Location = new System.Drawing.Point(183, 141);
            this.picEmptyPeople.Name = "picEmptyPeople";
            this.picEmptyPeople.Size = new System.Drawing.Size(393, 250);
            this.picEmptyPeople.TabIndex = 0;
            this.picEmptyPeople.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlMenu.Controls.Add(this.lblEmptyPeople);
            this.pnlMenu.Location = new System.Drawing.Point(0, 394);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(732, 100);
            this.pnlMenu.TabIndex = 6;
            // 
            // lblEmptyPeople
            // 
            this.lblEmptyPeople.AutoSize = true;
            this.lblEmptyPeople.Font = new System.Drawing.Font("Consolas", 13.875F, System.Drawing.FontStyle.Bold);
            this.lblEmptyPeople.Location = new System.Drawing.Point(97, 21);
            this.lblEmptyPeople.Name = "lblEmptyPeople";
            this.lblEmptyPeople.Size = new System.Drawing.Size(590, 22);
            this.lblEmptyPeople.TabIndex = 1;
            this.lblEmptyPeople.Text = "Chọn tên của người mà bạn muốn xem trước thông tin cá nhân";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.Red;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 494);
            this.pnlMainContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(732, 206);
            this.pnlMainContent.TabIndex = 7;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlLeft.Location = new System.Drawing.Point(12, 30);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(236, 768);
            this.pnlLeft.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1000, 800);
            this.panelContent.TabIndex = 24;
            // 
            // fFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.flpContent);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.panelContent);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "fFriend";
            this.Size = new System.Drawing.Size(1000, 800);
            this.flpContent.ResumeLayout(false);
            this.pnlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEmptyPeople)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox picEmptyPeople;
        private System.Windows.Forms.Label lblEmptyPeople;
    }
}

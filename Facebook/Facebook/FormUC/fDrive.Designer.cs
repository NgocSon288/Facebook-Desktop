
namespace Facebook.FormUC
{
    partial class fDrive
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
            this.pnlWrap = new System.Windows.Forms.Panel();
            this.pnlWrapContent = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pnlSeparator2 = new System.Windows.Forms.Panel();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.pnlSeparator1 = new System.Windows.Forms.Panel();
            this.pnlSeparator3 = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlWrap.SuspendLayout();
            this.pnlWrapContent.SuspendLayout();
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
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.pnlWrapContent);
            this.pnlWrap.Controls.Add(this.pnlSeparator2);
            this.pnlWrap.Controls.Add(this.pnlHead);
            this.pnlWrap.Controls.Add(this.pnlSeparator1);
            this.pnlWrap.Location = new System.Drawing.Point(0, 31);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(1000, 771);
            this.pnlWrap.TabIndex = 23;
            // 
            // pnlWrapContent
            // 
            this.pnlWrapContent.AllowDrop = true;
            this.pnlWrapContent.Controls.Add(this.pnlContent);
            this.pnlWrapContent.Controls.Add(this.pnlSeparator3);
            this.pnlWrapContent.Controls.Add(this.pnlControls);
            this.pnlWrapContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWrapContent.Location = new System.Drawing.Point(0, 60);
            this.pnlWrapContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapContent.Name = "pnlWrapContent";
            this.pnlWrapContent.Size = new System.Drawing.Size(1000, 711);
            this.pnlWrapContent.TabIndex = 5;
            this.pnlWrapContent.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlContent_DragDrop);
            this.pnlWrapContent.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlContent_DragEnter);
            this.pnlWrapContent.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlContent_DragOver);
            this.pnlWrapContent.DragLeave += new System.EventHandler(this.pnlContent_DragLeave);
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1000, 60);
            this.pnlControls.TabIndex = 1;
            // 
            // pnlSeparator2
            // 
            this.pnlSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator2.Location = new System.Drawing.Point(0, 57);
            this.pnlSeparator2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSeparator2.Name = "pnlSeparator2";
            this.pnlSeparator2.Size = new System.Drawing.Size(1000, 3);
            this.pnlSeparator2.TabIndex = 4;
            // 
            // pnlHead
            // 
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 3);
            this.pnlHead.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1000, 54);
            this.pnlHead.TabIndex = 3;
            this.pnlHead.Click += new System.EventHandler(this.pnlHead_Click);
            // 
            // pnlSeparator1
            // 
            this.pnlSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator1.Location = new System.Drawing.Point(0, 0);
            this.pnlSeparator1.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSeparator1.Name = "pnlSeparator1";
            this.pnlSeparator1.Size = new System.Drawing.Size(1000, 3);
            this.pnlSeparator1.TabIndex = 2;
            // 
            // pnlSeparator3
            // 
            this.pnlSeparator3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator3.Location = new System.Drawing.Point(0, 60);
            this.pnlSeparator3.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSeparator3.Name = "pnlSeparator3";
            this.pnlSeparator3.Size = new System.Drawing.Size(1000, 2);
            this.pnlSeparator3.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 62);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1000, 649);
            this.pnlContent.TabIndex = 3;
            // 
            // fDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.pnlWrap);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimize);
            this.Name = "fDrive";
            this.Size = new System.Drawing.Size(1000, 800);
            this.Click += new System.EventHandler(this.fDrive_Click);
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrapContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.Panel pnlSeparator1;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel pnlSeparator2;
        private System.Windows.Forms.Panel pnlWrapContent;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlSeparator3;
    }
}

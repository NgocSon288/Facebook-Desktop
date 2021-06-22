
namespace Facebook.FormUC
{
    partial class fMessenger
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.pnlWrap = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlMiddleCenter = new System.Windows.Forms.Panel();
            this.pnlMiddleBottom = new System.Windows.Forms.Panel();
            this.pnlMiddleTop = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.timerMQ = new System.Windows.Forms.Timer(this.components);
            this.pnlWrap.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(1940, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 58);
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
            this.btnMinimize.Location = new System.Drawing.Point(1874, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(60, 58);
            this.btnMinimize.TabIndex = 22;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Text = "--";
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.pnlRight);
            this.pnlWrap.Controls.Add(this.pnlMiddle);
            this.pnlWrap.Controls.Add(this.pnlLeft);
            this.pnlWrap.Location = new System.Drawing.Point(0, 65);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(2000, 1473);
            this.pnlWrap.TabIndex = 23;
            // 
            // pnlRight
            // 
            this.pnlRight.Location = new System.Drawing.Point(1404, 2);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(596, 1471);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pnlMiddleCenter);
            this.pnlMiddle.Controls.Add(this.pnlMiddleBottom);
            this.pnlMiddle.Controls.Add(this.pnlMiddleTop);
            this.pnlMiddle.Location = new System.Drawing.Point(602, 2);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(800, 1471);
            this.pnlMiddle.TabIndex = 1;
            // 
            // pnlMiddleCenter
            // 
            this.pnlMiddleCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddleCenter.Location = new System.Drawing.Point(0, 115);
            this.pnlMiddleCenter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddleCenter.Name = "pnlMiddleCenter";
            this.pnlMiddleCenter.Size = new System.Drawing.Size(800, 1241);
            this.pnlMiddleCenter.TabIndex = 2;
            // 
            // pnlMiddleBottom
            // 
            this.pnlMiddleBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMiddleBottom.Location = new System.Drawing.Point(0, 1356);
            this.pnlMiddleBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddleBottom.Name = "pnlMiddleBottom";
            this.pnlMiddleBottom.Size = new System.Drawing.Size(800, 115);
            this.pnlMiddleBottom.TabIndex = 1;
            // 
            // pnlMiddleTop
            // 
            this.pnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddleTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMiddleTop.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddleTop.Name = "pnlMiddleTop";
            this.pnlMiddleTop.Size = new System.Drawing.Size(800, 115);
            this.pnlMiddleTop.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Location = new System.Drawing.Point(0, 2);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(600, 1471);
            this.pnlLeft.TabIndex = 0;
            // 
            // timerMQ
            // 
            this.timerMQ.Interval = 1500;
            this.timerMQ.Tick += new System.EventHandler(this.timerMQ_Tick);
            // 
            // fMessenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.pnlWrap);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimize);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "fMessenger";
            this.Size = new System.Drawing.Size(2000, 1538);
            this.pnlWrap.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMiddleTop;
        private System.Windows.Forms.Panel pnlMiddleBottom;
        private System.Windows.Forms.Panel pnlMiddleCenter;
        private System.Windows.Forms.Timer timerMQ;
    }
}

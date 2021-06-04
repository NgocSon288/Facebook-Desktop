
namespace Facebook.Components.Profile
{
    partial class InfoProfileSectionUC
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
            this.btnTitle = new FontAwesome.Sharp.IconButton();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExpand = new FontAwesome.Sharp.IconButton();
            this.pnlHeadTitle = new System.Windows.Forms.Panel();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.pnlHeadTitle.SuspendLayout();
            this.pnlAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTitle
            // 
            this.btnTitle.BackColor = System.Drawing.Color.Transparent;
            this.btnTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTitle.FlatAppearance.BorderSize = 0;
            this.btnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTitle.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(107)))));
            this.btnTitle.IconChar = FontAwesome.Sharp.IconChar.Music;
            this.btnTitle.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(107)))));
            this.btnTitle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTitle.IconSize = 36;
            this.btnTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTitle.Location = new System.Drawing.Point(0, 0);
            this.btnTitle.Margin = new System.Windows.Forms.Padding(0);
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.Size = new System.Drawing.Size(205, 37);
            this.btnTitle.TabIndex = 40;
            this.btnTitle.TabStop = false;
            this.btnTitle.Text = "Bài hát";
            this.btnTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTitle.UseVisualStyleBackColor = false;
            this.btnTitle.Click += new System.EventHandler(this.btnTitle_Click);
            this.btnTitle.MouseEnter += new System.EventHandler(this.pnlHeadTitle_MouseEnter);
            this.btnTitle.MouseLeave += new System.EventHandler(this.pnlHeadTitle_MouseLeave);
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeparator.Location = new System.Drawing.Point(0, 317);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(471, 3);
            this.pnlSeparator.TabIndex = 41;
            // 
            // flpContent
            // 
            this.flpContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.flpContent.Location = new System.Drawing.Point(0, 34);
            this.flpContent.Margin = new System.Windows.Forms.Padding(0);
            this.flpContent.Name = "flpContent";
            this.flpContent.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flpContent.Size = new System.Drawing.Size(471, 238);
            this.flpContent.TabIndex = 42;
            // 
            // btnExpand
            // 
            this.btnExpand.BackColor = System.Drawing.Color.Transparent;
            this.btnExpand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpand.FlatAppearance.BorderSize = 0;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(107)))));
            this.btnExpand.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            this.btnExpand.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(107)))));
            this.btnExpand.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExpand.IconSize = 36;
            this.btnExpand.Location = new System.Drawing.Point(420, 0);
            this.btnExpand.Margin = new System.Windows.Forms.Padding(0);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(51, 37);
            this.btnExpand.TabIndex = 43;
            this.btnExpand.TabStop = false;
            this.btnExpand.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnTitle_Click);
            this.btnExpand.MouseEnter += new System.EventHandler(this.pnlHeadTitle_MouseEnter);
            this.btnExpand.MouseLeave += new System.EventHandler(this.pnlHeadTitle_MouseLeave);
            // 
            // pnlHeadTitle
            // 
            this.pnlHeadTitle.Controls.Add(this.btnExpand);
            this.pnlHeadTitle.Controls.Add(this.btnTitle);
            this.pnlHeadTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlHeadTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeadTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlHeadTitle.Name = "pnlHeadTitle";
            this.pnlHeadTitle.Size = new System.Drawing.Size(471, 31);
            this.pnlHeadTitle.TabIndex = 43;
            this.pnlHeadTitle.Click += new System.EventHandler(this.btnTitle_Click);
            this.pnlHeadTitle.MouseEnter += new System.EventHandler(this.pnlHeadTitle_MouseEnter);
            this.pnlHeadTitle.MouseLeave += new System.EventHandler(this.pnlHeadTitle_MouseLeave);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(52)))), ((int)(((byte)(212)))));
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAdd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(52)))), ((int)(((byte)(212)))));
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 44;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // pnlAdd
            // 
            this.pnlAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.pnlAdd.Controls.Add(this.lblAdd);
            this.pnlAdd.Controls.Add(this.btnAdd);
            this.pnlAdd.Location = new System.Drawing.Point(43, 275);
            this.pnlAdd.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(280, 39);
            this.pnlAdd.TabIndex = 44;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(52)))), ((int)(((byte)(212)))));
            this.lblAdd.Location = new System.Drawing.Point(41, 8);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(72, 20);
            this.lblAdd.TabIndex = 45;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "Thêm...";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // InfoProfileSectionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.pnlHeadTitle);
            this.Controls.Add(this.flpContent);
            this.Controls.Add(this.pnlSeparator);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "InfoProfileSectionUC";
            this.Size = new System.Drawing.Size(471, 320);
            this.pnlHeadTitle.ResumeLayout(false);
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnTitle;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private FontAwesome.Sharp.IconButton btnExpand;
        private System.Windows.Forms.Panel pnlHeadTitle;
        private FontAwesome.Sharp.IconButton btnAdd;
        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.LinkLabel lblAdd;
    }
}

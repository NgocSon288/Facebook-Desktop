
namespace Facebook.Components.Messenger
{
    partial class MessageItemImageItemUC
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
            this.cmsFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlWrap = new System.Windows.Forms.Panel();
            this.cmsFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsFile
            // 
            this.cmsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsSaveImage});
            this.cmsFile.Name = "cmsFile";
            this.cmsFile.Size = new System.Drawing.Size(123, 26);
            // 
            // cmsSaveImage
            // 
            this.cmsSaveImage.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsSaveImage.Name = "cmsSaveImage";
            this.cmsSaveImage.Size = new System.Drawing.Size(122, 22);
            this.cmsSaveImage.Text = "Lưu hình";
            this.cmsSaveImage.Click += new System.EventHandler(this.cmsSaveImage_Click);
            // 
            // pnlWrap
            // 
            this.pnlWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWrap.Location = new System.Drawing.Point(0, 0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(140, 140);
            this.pnlWrap.TabIndex = 1;
            this.pnlWrap.MouseEnter += new System.EventHandler(this.pnlWrap_MouseEnter);
            // 
            // MessageItemImageItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cmsFile;
            this.Controls.Add(this.pnlWrap);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "MessageItemImageItemUC";
            this.Size = new System.Drawing.Size(140, 140);
            this.Click += new System.EventHandler(this.MessageItemImageItemUC_Click);
            this.MouseLeave += new System.EventHandler(this.MessageItemImageItemUC_MouseLeave);
            this.cmsFile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsFile;
        private System.Windows.Forms.ToolStripMenuItem cmsSaveImage;
        private System.Windows.Forms.Panel pnlWrap;
    }
}

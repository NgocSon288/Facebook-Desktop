﻿
namespace Facebook.Components.Drive
{
    partial class DriveContentUC
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
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFolders = new System.Windows.Forms.Panel();
            this.lblFolders = new System.Windows.Forms.Label();
            this.pnlFiles = new System.Windows.Forms.Panel();
            this.lblFiles = new System.Windows.Forms.Label();
            this.pnlEmpty = new System.Windows.Forms.Panel();
            this.flpContent.SuspendLayout();
            this.pnlFolders.SuspendLayout();
            this.pnlFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpContent
            // 
            this.flpContent.AutoScroll = true;
            this.flpContent.AutoSize = true;
            this.flpContent.Controls.Add(this.pnlFolders);
            this.flpContent.Controls.Add(this.pnlFiles);
            this.flpContent.Controls.Add(this.pnlEmpty);
            this.flpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContent.Location = new System.Drawing.Point(0, 0);
            this.flpContent.Margin = new System.Windows.Forms.Padding(0);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(1009, 651);
            this.flpContent.TabIndex = 0;
            this.flpContent.Click += new System.EventHandler(this.flpContent_Click);
            // 
            // pnlFolders
            // 
            this.pnlFolders.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlFolders.Controls.Add(this.lblFolders);
            this.pnlFolders.Location = new System.Drawing.Point(0, 0);
            this.pnlFolders.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFolders.Name = "pnlFolders";
            this.pnlFolders.Size = new System.Drawing.Size(992, 187);
            this.pnlFolders.TabIndex = 0;
            this.pnlFolders.Click += new System.EventHandler(this.flpContent_Click);
            // 
            // lblFolders
            // 
            this.lblFolders.AutoSize = true;
            this.lblFolders.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolders.Location = new System.Drawing.Point(5, 6);
            this.lblFolders.Name = "lblFolders";
            this.lblFolders.Size = new System.Drawing.Size(94, 24);
            this.lblFolders.TabIndex = 1;
            this.lblFolders.Text = "Folders";
            this.lblFolders.Click += new System.EventHandler(this.flpContent_Click);
            // 
            // pnlFiles
            // 
            this.pnlFiles.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlFiles.Controls.Add(this.lblFiles);
            this.pnlFiles.Location = new System.Drawing.Point(0, 187);
            this.pnlFiles.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFiles.Name = "pnlFiles";
            this.pnlFiles.Size = new System.Drawing.Size(992, 204);
            this.pnlFiles.TabIndex = 1;
            this.pnlFiles.Click += new System.EventHandler(this.flpContent_Click);
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiles.Location = new System.Drawing.Point(5, 6);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(70, 24);
            this.lblFiles.TabIndex = 0;
            this.lblFiles.Text = "Files";
            this.lblFiles.Click += new System.EventHandler(this.flpContent_Click);
            // 
            // pnlEmpty
            // 
            this.pnlEmpty.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlEmpty.Location = new System.Drawing.Point(0, 391);
            this.pnlEmpty.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEmpty.Name = "pnlEmpty";
            this.pnlEmpty.Size = new System.Drawing.Size(992, 204);
            this.pnlEmpty.TabIndex = 2;
            this.pnlEmpty.Click += new System.EventHandler(this.flpContent_Click);
            // 
            // DriveContentUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpContent);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DriveContentUC";
            this.Size = new System.Drawing.Size(1009, 651);
            this.flpContent.ResumeLayout(false);
            this.pnlFolders.ResumeLayout(false);
            this.pnlFolders.PerformLayout();
            this.pnlFiles.ResumeLayout(false);
            this.pnlFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private System.Windows.Forms.Panel pnlFolders;
        private System.Windows.Forms.Panel pnlFiles;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblFolders;
        private System.Windows.Forms.Panel pnlEmpty;
    }
}

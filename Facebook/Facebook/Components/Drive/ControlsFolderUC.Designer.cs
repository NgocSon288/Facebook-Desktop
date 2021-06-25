
namespace Facebook.Components.Drive
{
    partial class ControlsFolderUC
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
            this.flpControls = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpControls
            // 
            this.flpControls.Location = new System.Drawing.Point(15, 10);
            this.flpControls.Margin = new System.Windows.Forms.Padding(0);
            this.flpControls.Name = "flpControls";
            this.flpControls.Size = new System.Drawing.Size(970, 40);
            this.flpControls.TabIndex = 1;
            this.flpControls.Click += new System.EventHandler(this.flpControls_Click);
            // 
            // ControlsFolderUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpControls);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlsFolderUC";
            this.Size = new System.Drawing.Size(1000, 60);
            this.Click += new System.EventHandler(this.flpControls_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpControls;
    }
}


namespace Facebook.Components.Drive
{
    partial class ControlsGlobalUC
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
            this.pnlOwn = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // flpControls
            // 
            this.flpControls.Location = new System.Drawing.Point(15, 10);
            this.flpControls.Margin = new System.Windows.Forms.Padding(0);
            this.flpControls.Name = "flpControls";
            this.flpControls.Size = new System.Drawing.Size(650, 40);
            this.flpControls.TabIndex = 0;
            this.flpControls.Click += new System.EventHandler(this.ControlsGlobalUC_Click);
            // 
            // pnlOwn
            // 
            this.pnlOwn.Location = new System.Drawing.Point(665, 10);
            this.pnlOwn.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOwn.Name = "pnlOwn";
            this.pnlOwn.Size = new System.Drawing.Size(319, 40);
            this.pnlOwn.TabIndex = 4;
            // 
            // ControlsGlobalUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pnlOwn);
            this.Controls.Add(this.flpControls);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlsGlobalUC";
            this.Size = new System.Drawing.Size(1000, 60);
            this.Click += new System.EventHandler(this.ControlsGlobalUC_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpControls;
        private System.Windows.Forms.Panel pnlOwn;
    }
}

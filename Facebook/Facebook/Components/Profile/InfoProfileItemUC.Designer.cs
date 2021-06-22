
namespace Facebook.Components.Profile
{
    partial class InfoProfileItemUC
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
            this.pnlBottomText = new System.Windows.Forms.Panel();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnEditOrUpdate = new FontAwesome.Sharp.IconButton();
            this.btnDeleteOrCancel = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // pnlBottomText
            // 
            this.pnlBottomText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(149)))), ((int)(((byte)(167)))));
            this.pnlBottomText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlBottomText.Location = new System.Drawing.Point(3, 23);
            this.pnlBottomText.Name = "pnlBottomText";
            this.pnlBottomText.Size = new System.Drawing.Size(356, 2);
            this.pnlBottomText.TabIndex = 60;
            this.pnlBottomText.MouseEnter += new System.EventHandler(this.InfoProfileItemUC_MouseEnter1);
            this.pnlBottomText.MouseLeave += new System.EventHandler(this.InfoProfileItemUC_MouseLeave);
            // 
            // txtText
            // 
            this.txtText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtText.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(149)))), ((int)(((byte)(167)))));
            this.txtText.Location = new System.Drawing.Point(10, 4);
            this.txtText.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(343, 41);
            this.txtText.TabIndex = 59;
            this.txtText.Text = "son";
            this.txtText.Enter += new System.EventHandler(this.txtText_MouseEnter);
            this.txtText.Leave += new System.EventHandler(this.txtText_MouseLeave);
            this.txtText.MouseEnter += new System.EventHandler(this.InfoProfileItemUC_MouseEnter1);
            this.txtText.MouseLeave += new System.EventHandler(this.InfoProfileItemUC_MouseLeave);
            // 
            // btnEditOrUpdate
            // 
            this.btnEditOrUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.btnEditOrUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditOrUpdate.FlatAppearance.BorderSize = 0;
            this.btnEditOrUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOrUpdate.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnEditOrUpdate.IconColor = System.Drawing.Color.Black;
            this.btnEditOrUpdate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditOrUpdate.IconSize = 36;
            this.btnEditOrUpdate.Location = new System.Drawing.Point(365, -3);
            this.btnEditOrUpdate.Name = "btnEditOrUpdate";
            this.btnEditOrUpdate.Size = new System.Drawing.Size(40, 40);
            this.btnEditOrUpdate.TabIndex = 61;
            this.btnEditOrUpdate.UseVisualStyleBackColor = false;
            this.btnEditOrUpdate.Click += new System.EventHandler(this.btnEditOrUpdate_Click);
            this.btnEditOrUpdate.MouseEnter += new System.EventHandler(this.InfoProfileItemUC_MouseEnter1);
            this.btnEditOrUpdate.MouseLeave += new System.EventHandler(this.InfoProfileItemUC_MouseLeave);
            // 
            // btnDeleteOrCancel
            // 
            this.btnDeleteOrCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.btnDeleteOrCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteOrCancel.FlatAppearance.BorderSize = 0;
            this.btnDeleteOrCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOrCancel.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnDeleteOrCancel.IconColor = System.Drawing.Color.Black;
            this.btnDeleteOrCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDeleteOrCancel.IconSize = 36;
            this.btnDeleteOrCancel.Location = new System.Drawing.Point(411, -3);
            this.btnDeleteOrCancel.Name = "btnDeleteOrCancel";
            this.btnDeleteOrCancel.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteOrCancel.TabIndex = 62;
            this.btnDeleteOrCancel.UseVisualStyleBackColor = false;
            this.btnDeleteOrCancel.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDeleteOrCancel.MouseEnter += new System.EventHandler(this.InfoProfileItemUC_MouseEnter1);
            this.btnDeleteOrCancel.MouseLeave += new System.EventHandler(this.InfoProfileItemUC_MouseLeave);
            // 
            // InfoProfileItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.btnDeleteOrCancel);
            this.Controls.Add(this.btnEditOrUpdate);
            this.Controls.Add(this.pnlBottomText);
            this.Controls.Add(this.txtText);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Name = "InfoProfileItemUC";
            this.Size = new System.Drawing.Size(461, 31);
            this.MouseEnter += new System.EventHandler(this.InfoProfileItemUC_MouseEnter1);
            this.MouseLeave += new System.EventHandler(this.InfoProfileItemUC_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottomText;
        private System.Windows.Forms.TextBox txtText;
        private FontAwesome.Sharp.IconButton btnEditOrUpdate;
        private FontAwesome.Sharp.IconButton btnDeleteOrCancel;
    }
}

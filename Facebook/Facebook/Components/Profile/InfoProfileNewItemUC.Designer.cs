
namespace Facebook.Components.Profile
{
    partial class InfoProfileNewItemUC
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
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.pnlBottomText = new System.Windows.Forms.Panel();
            this.txtText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnCancel.IconColor = System.Drawing.Color.Black;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.IconSize = 36;
            this.btnCancel.Location = new System.Drawing.Point(411, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(40, 40);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.InfoProfileItemUC_MouseEnter1);
            this.btnCancel.MouseLeave += new System.EventHandler(this.InfoProfileItemUC_MouseLeave);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnAdd.IconColor = System.Drawing.Color.Black;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 36;
            this.btnAdd.Location = new System.Drawing.Point(365, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 65;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.InfoProfileItemUC_MouseEnter1);
            this.btnAdd.MouseLeave += new System.EventHandler(this.InfoProfileItemUC_MouseLeave);
            // 
            // pnlBottomText
            // 
            this.pnlBottomText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(149)))), ((int)(((byte)(167)))));
            this.pnlBottomText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlBottomText.Location = new System.Drawing.Point(3, 32);
            this.pnlBottomText.Name = "pnlBottomText";
            this.pnlBottomText.Size = new System.Drawing.Size(356, 2);
            this.pnlBottomText.TabIndex = 64;
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
            this.txtText.Location = new System.Drawing.Point(10, 6);
            this.txtText.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(343, 41);
            this.txtText.TabIndex = 63;
            this.txtText.Text = "son";
            this.txtText.Enter += new System.EventHandler(this.txtText_MouseEnter);
            this.txtText.Leave += new System.EventHandler(this.txtText_MouseLeave);
            this.txtText.MouseEnter += new System.EventHandler(this.InfoProfileItemUC_MouseEnter1);
            this.txtText.MouseLeave += new System.EventHandler(this.InfoProfileItemUC_MouseLeave);
            // 
            // InfoProfileNewItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnlBottomText);
            this.Controls.Add(this.txtText);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InfoProfileNewItemUC";
            this.Size = new System.Drawing.Size(461, 40);
            this.MouseEnter += new System.EventHandler(this.InfoProfileItemUC_MouseEnter1);
            this.MouseLeave += new System.EventHandler(this.InfoProfileItemUC_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnAdd;
        private System.Windows.Forms.Panel pnlBottomText;
        private System.Windows.Forms.TextBox txtText;
    }
}


namespace Facebook.Components.Messenger
{
    partial class MessengerContentMessageUC
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
            this.btnAttach = new FontAwesome.Sharp.IconButton();
            this.btnSend = new FontAwesome.Sharp.IconButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttach.FlatAppearance.BorderSize = 0;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttach.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAttach.IconColor = System.Drawing.Color.Black;
            this.btnAttach.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAttach.Location = new System.Drawing.Point(3, 14);
            this.btnAttach.Margin = new System.Windows.Forms.Padding(0);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(36, 36);
            this.btnAttach.TabIndex = 0;
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.IconChar = FontAwesome.Sharp.IconChar.TelegramPlane;
            this.btnSend.IconColor = System.Drawing.Color.Black;
            this.btnSend.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSend.Location = new System.Drawing.Point(362, 14);
            this.btnSend.Margin = new System.Windows.Forms.Padding(0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(36, 36);
            this.btnSend.TabIndex = 1;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.txtDescription);
            this.pnlContent.Location = new System.Drawing.Point(42, 13);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(317, 35);
            this.pnlContent.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(8, 7);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 36);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "Aa";
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_MouseEnter);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // MessengerContentMessageUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnAttach);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MessengerContentMessageUC";
            this.Size = new System.Drawing.Size(400, 60);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnAttach;
        private FontAwesome.Sharp.IconButton btnSend;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TextBox txtDescription;
    }
}

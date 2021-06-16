using Facebook.Common;
using Facebook.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Messenger
{
    public partial class MessageItemTextUC : UserControl
    {
        private string description;

        public MessageItemTextUC(string description)
        {
            InitializeComponent();

            this.description = description;

            Load();
            UpdateHeight();
        }

        Label lblFocus;
        int margin = 10;

        #region Methods

        new private void Load()
        {
            txtDescription.Text = description;
            UIHelper.SetWidth(txtDescription, 582);
            UIHelper.SetSizeTextBox(txtDescription);

            var a = txtDescription.TextLength;
            var b = txtDescription.Width;

            this.Width = txtDescription.Width + 2 * margin;
            this.Height = txtDescription.Height + 2 * margin;
            txtDescription.Top = margin;
            txtDescription.Left = margin;
            if (description.Length < 10)
            {
                txtDescription.TextAlign = HorizontalAlignment.Center;
            }


            this.BackColor = Constants.THEME_COLOR;
            txtDescription.BackColor = Constants.THEME_COLOR;
            txtDescription.ForeColor = Constants.MAIN_FORE_COLOR;

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS_MESSAGE_TEXT);

            SetUnFocus();
        }

        public void SetThemeColor()
        {
            this.BackColor = Constants.THEME_COLOR;
            txtDescription.BackColor = Constants.THEME_COLOR;
        }

        private void SetUnFocus()
        {
            lblFocus = new Label()
            {
                AutoSize = true,
                Width = 0,
                Height = 0
            };

            this.Controls.Add(lblFocus);
        }

        private void UpdateHeight()
        {
            if (string.IsNullOrEmpty(description))
            {
                this.Height = 0;
            }
        }

        #endregion

        private void txtDescription_Click(object sender, EventArgs e)
        {
            this.ActiveControl = lblFocus;
        }
    }
}

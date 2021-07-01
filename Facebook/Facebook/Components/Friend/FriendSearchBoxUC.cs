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

namespace Facebook.Components.Friend
{
    public partial class FriendSearchBoxUC : UserControl
    {
        public delegate void Submit(string text);
        public event Submit OnSubmit;

        private bool isSubmit;

        public FriendSearchBoxUC()
        {
            InitializeComponent();

            Load();
            SetUpUI();
        }

        string TEXT_COMPARE = "Tìm trên Facebook";

        #region Methods

        new private void Load()
        {
            //UIHelper.SetBlur(this, (o, s) => this.ActiveControl = (Control)o, true);
        }

        private void SetUpUI()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlSearch.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;

            iconSearch.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            iconSearch.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            txtSearch.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            txtSearch.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;

            pnlSeparator1.BackColor = Constants.BORDER_BOX_COLOR;
            pnlSeparator1.Left = 0;
            pnlSeparator1.Top = lblTitle.Top - pnlSeparator1.Height;
            pnlSeparator1.Width = this.Width;
            pnlSeparator1.Height = 1;
            pnlSeparator2.BackColor = Constants.BORDER_BOX_COLOR;
            pnlSeparator2.Left = 0;
            pnlSeparator2.Top = this.Height - pnlSeparator2.Height;
            pnlSeparator2.Width = this.Width;
            pnlSeparator2.Height = 1;

            UIHelper.BorderRadius(pnlSearch, 90);
            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
        }

        #endregion

        #region Events

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            var txt = txtSearch.Text;

            if (string.Equals(txt, TEXT_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            var txt = txtSearch.Text;

            if (string.IsNullOrEmpty(txt.Trim()))
            {
                txtSearch.Text = TEXT_COMPARE;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                isSubmit = true;
                txtMyCommentDescription_TextChanged(null, null);
                this.ActiveControl = null;
            }
        }

        private void txtMyCommentDescription_TextChanged(object sender, EventArgs e)
        {
            if (isSubmit)
            {
                isSubmit = false;
                OnSubmit?.Invoke(txtSearch.Text);
            }
        }

        #endregion
    }
}

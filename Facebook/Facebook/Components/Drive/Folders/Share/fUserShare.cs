using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.DAO;
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

namespace Facebook.Components.Drive.Folders.Share
{
    public partial class fUserShare : Form
    {
        private UserShareListUC userShareListUC;

        public fUserShare()
        {
            InitializeComponent();

            Load();
        }

        int margin = 2;
        string TEXT_COMPARE = "Tên bạn bè...";

        #region Methods

        new private void Load()
        {
            userShareListUC = new UserShareListUC(AutofacFactory<IUserDAO>.Get(), AutofacFactory<IFolderDAO>.Get());
            pnlContent.Controls.Add(userShareListUC);

            pnlHead.Width = this.Width - 2 * margin;
            pnlHead.Top = margin;
            pnlHead.Left = margin;
            pnlHead.BackColor = Constants.MAIN_BACK_COLOR;

            lblTitle.Top = pnlHead.Height / 2 - lblTitle.Height / 2;
            lblTitle.Left = pnlHead.Width / 2 - lblTitle.Width / 2;
            lblTitle.BackColor = Constants.MAIN_BACK_COLOR;
            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;

            pnlSearch.Width = pnlHead.Width;
            pnlSearch.Left = pnlHead.Left;
            pnlSearch.Top = pnlHead.Bottom + margin;
            pnlSearch.BackColor = Constants.MAIN_BACK_COLOR;

            pnlContent.Width = pnlHead.Width;
            pnlContent.Height = this.Height - 4 * margin - pnlHead.Height - pnlSearch.Height;
            pnlContent.Top = pnlSearch.Bottom + margin;
            pnlContent.Left = pnlHead.Left;
            pnlContent.BackColor = Constants.MAIN_BACK_COLOR;

            this.BackColor = Constants.BORDER_BOX_COLOR;

            pnlWrapSearch.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            iconSearch.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            iconSearch.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            txtSearch.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            txtSearch.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            UIHelper.BorderRadius(pnlWrapSearch, pnlWrapSearch.Height);

        }

        #endregion

        private void pnlContent_Click(object sender, EventArgs e)
        {
            this.ActiveControl = lblTitle;
        }

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            userShareListUC.FilterFriend(txtSearch.Text);
        }
    }
}

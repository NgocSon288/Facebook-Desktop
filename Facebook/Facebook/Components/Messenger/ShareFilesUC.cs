using Facebook.Common;
using Facebook.Helper;
using FontAwesome.Sharp;
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
    public partial class ShareFilesUC : UserControl
    {
        private List<string> fileNames;
        private bool isExpanded;

        public ShareFilesUC(List<string> fileNames)
        {
            InitializeComponent();

            this.fileNames = fileNames;

            Load();
        }

        #region Methods

        new private void Load()
        {
            foreach (var item in fileNames)
            {
                var itemUC = new ShareFilesItemUC(item);

                flpContent.Controls.Add(itemUC);
            }

            ChangesStatus(true);
            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            picIcon.IconColor = Constants.MAIN_FORE_COLOR;
        }

        public void AddFile(List<string> files)
        {
            foreach (var item in fileNames)
            {
                var itemUC = new ShareFilesItemUC(item);

                flpContent.Controls.Add(itemUC);
            }

            UpdateHeight();
        }

        private void ChangesStatus(bool isInit = false)
        {
            if (!isInit)
            {
                isExpanded = !isExpanded;
            }
            picIcon.IconChar = isExpanded ? IconChar.AngleUp : IconChar.AngleDown;
            flpContent.Visible = isExpanded;

            UpdateHeight();
        }

        private void UpdateHeight()
        {
            if (!isExpanded)
            {
                this.Height = pnlTitle.Height;
            }
            else
            {
                var height = pnlTitle.Height;

                foreach (Control item in flpContent.Controls)
                {
                    height += item.Height;
                }

                this.Height = height;
            }
        }

        #endregion

        #region UI

        private void pnlTitle_Click(object sender, EventArgs e)
        {
            ChangesStatus();
        }

        private void pnlTitle_MouseEnter(object sender, EventArgs e)
        {
            pnlTitle.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblTitle.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            picIcon.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            UIHelper.BorderRadius(pnlTitle, Constants.BORDER_RADIUS);
        }

        private void pnlTitle_MouseLeave(object sender, EventArgs e)
        {
            pnlTitle.BackColor = Constants.MAIN_BACK_COLOR;
            lblTitle.BackColor = Constants.MAIN_BACK_COLOR;
            picIcon.BackColor = Constants.MAIN_BACK_COLOR;

            UIHelper.BorderRadius(pnlTitle, 0);
        }

        #endregion
    }
}

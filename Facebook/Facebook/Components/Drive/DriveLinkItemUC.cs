using Facebook.Common;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Drive
{
    public partial class DriveLinkItemUC : UserControl
    {
        public delegate void ChangedFolder();
        public event ChangedFolder OnChangedFolder;

        public Folder folder;
        private bool isRoot;

        public DriveLinkItemUC(Folder folder, bool isRoot = false)
        {
            InitializeComponent();

            this.folder = folder;
            this.isRoot = isRoot;

            Load();
        }

        int margin = 10;

        #region Methods

        new private void Load()
        {
            picIcon.IconColor = Constants.MAIN_FORE_COLOR;

            lblName.Text = folder.Name;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;

            if (isRoot)
            {
                picIcon.Visible = false;
                pnlWrap.Left = margin;
                pnlWrap.Width = lblName.Width + 6 * margin;
                lblName.Left = 3 * margin;

                this.Width = pnlWrap.Width + 2 * margin;
            }
            else
            {
                picIcon.Visible = true;
                picIcon.Left = margin;
                pnlWrap.Width = lblName.Width + 6 * margin;
                lblName.Left = 3 * margin;

                pnlWrap.Left = picIcon.Width + 2 * margin + 3;

                this.Width = picIcon.Width + pnlWrap.Width + 2 * margin;
            }
        }


        #endregion

        #region Events

        private void lblName_MouseEnter(object sender, EventArgs e)
        {
            pnlWrap.BackColor = Constants.FOLDER_ITEM_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void pnlWrap_MouseLeave(object sender, EventArgs e)
        {
            pnlWrap.BackColor = Constants.MAIN_BACK_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void pnlWrap_Click(object sender, EventArgs e)
        {
            OnChangedFolder?.Invoke();
        }

        #endregion
    }
}

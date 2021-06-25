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

namespace Facebook.Components.Drive
{
    public partial class ControlsItemUC : UserControl
    {
        public delegate void ClickControl();
        public event ClickControl OnClickControl;

        private IconChar icon;
        private string mess;

        public ControlsItemUC(IconChar icon, string mess)
        {
            InitializeComponent();

            this.icon = icon;
            this.mess = mess;

            Load();
        }

        #region Methods

        new private void Load()
        {
            picIcon.IconChar = icon;
            picIcon.IconColor = Constants.MAIN_FORE_COLOR;
            picIcon.Location = new Point(this.Width / 2 - picIcon.Width / 2 + 2, this.Width / 2 - picIcon.Width / 2 + 2);

            LoadControl(picIcon, false);

            tt.SetToolTip(picIcon, mess);
        }

        private void LoadControl(IconPictureBox icon, bool isAvtive = true)
        {
            icon.BackColor = isAvtive ? Constants.FOLDER_ITEM_ENTER_COLOR : Constants.MAIN_BACK_COLOR;
            this.BackColor = isAvtive ? Constants.FOLDER_ITEM_ENTER_COLOR : Constants.MAIN_BACK_COLOR;
            UIHelper.BorderRadius(this, this.Width);
        }



        #endregion

        #region Events

        private void picIcon_MouseEnter(object sender, EventArgs e)
        {
            LoadControl(picIcon, true);
        }

        private void ControlsItemUC_MouseLeave(object sender, EventArgs e)
        {
            LoadControl(picIcon, false);
        }

        private void picIcon_Click(object sender, EventArgs e)
        {
            LoadControl(picIcon, false);
            OnClickControl?.Invoke();
        }

        #endregion
    }
}

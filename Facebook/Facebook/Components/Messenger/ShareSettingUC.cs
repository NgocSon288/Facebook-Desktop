using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.DAO;
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
    public partial class ShareSettingUC : UserControl
    {
        public delegate void UpdateThemeColor();
        public event UpdateThemeColor OnUpdateThemeColor;

        private bool isExpanded;

        private ShareSettingThemeUC themeUC;

        public ShareSettingUC()
        {
            InitializeComponent();

            Load();
        }

        #region Methods

        new private void Load()
        {
            themeUC = new ShareSettingThemeUC(AutofacFactory<IMessageSettingDAO>.Get());
            themeUC.OnUpdateThemeColor += () => OnUpdateThemeColor?.Invoke();

            flpContent.Controls.Add(themeUC);

            ChangesStatus(true);
            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            picIcon.IconColor = Constants.MAIN_FORE_COLOR;
        }

        public void SetThemeColor()
        {
            themeUC.SetThemeColor();
        }

        private void ChangesStatus(bool isInit = false)
        {
            if (!isInit)
            {
                isExpanded = !isExpanded;
            }
            picIcon.IconChar = isExpanded ? IconChar.AngleUp : IconChar.AngleDown;
            flpContent.Visible = isExpanded;

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

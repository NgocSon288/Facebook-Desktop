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

namespace Facebook.Components.Messenger
{
    public partial class fShareBoxThemeColor : Form
    {
        public delegate void UpdateThemeColor(bool isChanged);
        public event UpdateThemeColor OnUpdateThemeColor;

        private MessageSetting messageSetting;

        public fShareBoxThemeColor(MessageSetting messageSetting)
        {
            InitializeComponent();

            this.messageSetting = messageSetting;

            Load();
        }

        #region Methods

        new private void Load()
        {
            var d = 0;
            ShareThemColorItemUC itemUC;

            foreach (var item in ThemeColor.Themes)
            {
                if (d == 0 && messageSetting == null)
                {
                    itemUC = new ShareThemColorItemUC(item, true);
                }
                else
                {
                    if (messageSetting != null && messageSetting.ThemeColor == item.Name)
                    {
                        itemUC = new ShareThemColorItemUC(item, true);
                    }
                    else
                    {
                        itemUC = new ShareThemColorItemUC(item);
                    }
                }

                d++;
                flpContent.Controls.Add(itemUC);
            }
            pnlHead.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            label1.Top = pnlHead.Height / 2 - label1.Height / 2;
            label1.Left = pnlHead.Width / 2 - label1.Width / 2;
            label1.ForeColor = Constants.MAIN_FORE_COLOR;

            btnSave.BackColor = Constants.MAIN_FORE_LINK2_COLOR;
            btnSave.ForeColor = Constants.MAIN_FORE_COLOR;

            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            flpContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            this.BackColor = Constants.BORDER_BOX_COLOR;

            UIHelper.BorderRadius(this, 5);
            UIHelper.BorderRadius(btnSave, 10);
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnUpdateThemeColor?.Invoke(true);
        }
    }
}

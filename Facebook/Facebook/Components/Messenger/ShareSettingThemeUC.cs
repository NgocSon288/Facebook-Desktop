using Facebook.Common;
using Facebook.ControlCustom.WrapperForm;
using Facebook.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Messenger
{
    public partial class ShareSettingThemeUC : UserControl
    {
        public delegate void UpdateThemeColor();
        public event UpdateThemeColor OnUpdateThemeColor;

        private readonly IMessageSettingDAO _messageSettingDAO;

        public ShareSettingThemeUC(IMessageSettingDAO messageSettingDAO)
        {
            InitializeComponent();

            this._messageSettingDAO = messageSettingDAO;

            Load();
        }

        #region Methods

        new private void Load()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;

            picIcon.IconColor = Constants.THEME_COLOR;


            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            lblTitle.BackColor = Constants.MAIN_BACK_COLOR;
        }


        #endregion

        private void ShareSettingThemeUC_Click(object sender, EventArgs e)
        {
            try
            {
                var ms = _messageSettingDAO.GetByMultipID(MessengerFriendItemUC.CurrentItem.user.ID, Constants.UserSession.ID);
                var themUC = new fShareBoxThemeColor(ms);
                var fparent = new fParentClickHidden(themUC);
                var isUpdate = false;


                themUC.OnUpdateThemeColor += (isChanged) =>
                {
                    isUpdate = isChanged;
                    fparent.FParentClickHidden_Click(null, null);
                };

                fparent.FormClosed += (s, o) =>
                {
                    if (isUpdate)
                    {
                        // Update  icon
                        picIcon.IconColor = ThemeColor.GetThemeByName(ShareThemColorItemUC.CurrentItemUC.theme.Name).Color;

                        OnUpdateThemeColor?.Invoke();
                    }
                };

                fparent.ShowDialog();
            }
            catch (Exception)
            {

            }
        }
    }
}

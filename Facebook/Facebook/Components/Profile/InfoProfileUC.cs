using Facebook.Common;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
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

namespace Facebook.Components.Profile
{
    public partial class InfoProfileUC : UserControl
    {
        public delegate void HeightChanged();
        public event HeightChanged OnHeightChanged;

        private readonly IProfileDAO _profileDAO;
        private User user;

        private Facebook.Model.Models.Profile profile;

        public InfoProfileUC(IProfileDAO profileDAO, User user = null)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            this._profileDAO = profileDAO;
            this.user = user == null ? Constants.UserSession : user;

            Load();
        }

        #region Methods

        new private void Load()
        {
            profile = _profileDAO.GetByID(user.ProfileID.Value);

            foreach (var item in profile.GetType().GetProperties())
            {
                if (item.Name == "ID")
                    continue;

                var name = item.Name;
                var value = item.GetValue(profile);
                var title = "";
                IconChar icon = IconChar.AccessibleIcon;

                switch (name)
                {
                    case nameof(profile.Work):
                        title = "Công việc";
                        icon = IconChar.AccessibleIcon;
                        break;
                    case nameof(profile.Education):
                        title = "Học vấn";
                        icon = IconChar.Accusoft;
                        break;
                    case nameof(profile.Address):
                        title = "Địa chỉ";
                        icon = IconChar.AcquisitionsIncorporated;
                        break;
                    case nameof(profile.PhoneNumber):
                        title = "Số điện thoại";
                        icon = IconChar.Ad;
                        break;
                    case nameof(profile.Email):
                        title = "Email";
                        icon = IconChar.AddressBook;
                        break;
                    case nameof(profile.Favorite):
                        title = "Sở thích";
                        icon = IconChar.AddressCard;
                        break;
                }

                var section = new InfoProfileSectionUC(name, title, value == null ? "" : value.ToString(), icon, this._profileDAO, user != Constants.UserSession);

                flpContent.Controls.Add(section);
            }

            // Tạo sự kiện cho các control bên trong flp khi Expanded, mặc định tất cả control là InfoProfileItemUC
            foreach (InfoProfileSectionUC item in flpContent.Controls)
            {
                item.OnExpanded += Item_OnExpanded;
            }

            UpdateHeight();
            SetColor();

            UIHelper.BorderRadius(pnlContent, Constants.BORDER_RADIUS);
            UIHelper.SetBlur(this, () => this.ActiveControl = null);
        }


        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            lblInfo.ForeColor = Constants.MAIN_FORE_COLOR;
            flpContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        /// <summary>
        /// Cập nhật lại height khi có bất ký thay đổi gì
        /// </summary>
        private void UpdateHeight()
        {
            // margin top, bottom
            var topFlp = flpContent.Top;
            var margin = 20;
            var heightLbl = lblInfo.Height;
            var heightThis = margin + heightLbl;

            foreach (Control item in flpContent.Controls)
            {
                heightThis += item.Height + item.Margin.Bottom;
            }

            this.Height = heightThis;
            pnlContent.Location = new Point(20, 20);
            pnlContent.Height = heightThis - margin;
            flpContent.Height = pnlContent.Height - topFlp;

            OnHeightChanged?.Invoke();
            UIHelper.BorderRadius(pnlContent, Constants.BORDER_RADIUS);
        }

        #endregion

        #region Events

        private void Item_OnExpanded()
        {
            UpdateHeight();
        }

        #endregion
    }
}

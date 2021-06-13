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

namespace Facebook.Components.Friend
{
    public partial class FriendMenuProfileUC : UserControl
    {
        public delegate void ClickAddFriend();
        public delegate void ClickAcceptOrDeleteFriend();
        public delegate void LinkToProfile();
        public event ClickAddFriend OnClickAddFriend;
        public event ClickAcceptOrDeleteFriend OnClickAcceptOrDeleteFriend;
        public event LinkToProfile OnLinkToProfile;

        private bool isRequested;
        private bool isFriend;

        public FriendMenuProfileUC(bool isRequested, bool isFriend)
        {
            InitializeComponent();

            this.isRequested = isRequested;
            this.isFriend = isFriend;

            Load();
        }

        int margin = 20;
        int marginContent = 10;
        int widthButton = 200;

        #region Methods

        new private void Load()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlWrap.Width = this.Width - margin * 2 - 15;
            pnlWrap.Height = this.Height - margin * 2;
            pnlWrap.Location = new Point(margin, margin);

            SetUI();
            SetColorEnter();
            SetButtonAddFriend();

            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void SetUI()
        {
            // Giới thiệu 
            SetButtonVirtual(pnlWrapIntro, lblIntro, pnlBorderIntro);

            pnlBorderIntro.Left = pnlWrapIntro.Left;

            // btn add friend
            btnAddFriend.BackColor = Constants.MAIN_FORE_LINK2_COLOR;
            btnAddFriend.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            btnAddFriend.FlatAppearance.BorderSize = 2;
            btnAddFriend.FlatAppearance.BorderColor = Constants.MAIN_FORE_LINK2_COLOR;

            // btn profile
            btnProfile.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnProfile.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            btnProfile.FlatAppearance.BorderColor = Constants.MAIN_FORE_LINK2_COLOR;
            btnProfile.FlatAppearance.BorderSize = 2;
        }

        private void SetButtonVirtual(Panel pnlWrap, Label lbl, Panel pnlBorder)
        {
            pnlWrap.Width = widthButton;
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlWrap.Height = pnlWrap.Height - 2 * marginContent;
            pnlWrap.Top = marginContent;
            lbl.Left = pnlWrap.Width / 2 - lbl.Width / 2;
            lbl.Top = pnlWrap.Height / 2 - lbl.Height / 2;
            lbl.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lbl.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlBorder.Width = pnlWrap.Width;
            pnlBorder.Height = marginContent;
            pnlBorder.Top = pnlWrap.Bottom;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
            pnlBorder.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void SetColorEnter(bool isActive = true)
        {
            pnlBorderIntro.BackColor = isActive ? Constants.MAIN_FORE_LINK_COLOR : Constants.MAIN_BACK_CONTENT_COLOR;
            lblIntro.ForeColor = isActive ? Constants.MAIN_FORE_LINK_COLOR : Constants.MAIN_FORE_SMALLTEXT_COLOR;
            pnlWrapIntro.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblIntro.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void SetButtonAddFriend()
        {
            if (!isFriend)
            {
                btnAddFriend.Text = !isRequested ? "Thêm bạn bè" : "Hủy lời mới";
                btnAddFriend.IconChar = !isRequested ? IconChar.UserPlus : IconChar.UserTimes;

            }
            else
            {
                if (btnAddFriend.Text == "Hủy kết bạn")
                {
                    isFriend = false;
                }

                btnAddFriend.Text = !isRequested ? "Thêm bạn bè" : "Hủy kết bạn";
                btnAddFriend.IconChar = !isRequested ? IconChar.UserPlus : IconChar.UserTimes;
            }
        }

        public void UpdateButtonSendOrCancelRequest(bool isSend)
        {
            isRequested = isSend;
            SetButtonAddFriend();
        }


        #endregion

        #region Events 

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            isRequested = !isRequested;

            // Trường hợp được gửi yêu cầu kết bạn
            if (isFriend)
            {
                OnClickAcceptOrDeleteFriend?.Invoke();
                SetButtonAddFriend();
                return;
            }

            SetButtonAddFriend();
            OnClickAddFriend?.Invoke();
        }

        #endregion

        private void btnProfile_Click(object sender, EventArgs e)
        {
            OnLinkToProfile?.Invoke();
        }
    }
}

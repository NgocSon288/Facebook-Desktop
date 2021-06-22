using Facebook.Common;
using Facebook.ControlCustom.Message;
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

namespace Facebook.Components.Friend
{
    public partial class FriendUserItemUC : UserControl
    {
        public delegate void ClickSection();
        public delegate void ClickSendOrCancelRequest(bool isSend);
        public delegate void ClickBlock(FriendUserItemUC itemDelete);
        public event ClickSection OnClickSection;
        public event ClickSendOrCancelRequest OnClickSendOrCancelRequest;
        public event ClickBlock OnClickBlock;

        public static FriendUserItemUC CurrentFriendUserItemUC;

        private User user;

        public FriendUserItemUC(User user)
        {
            InitializeComponent();

            this.user = user;

            Load();
            SetUpUI();
        }

        #region Methods

        new private void Load()
        {
            btnSendRequest.Text = FriendHelper.A_SendRequest_B(Constants.UserSession, user) ? "Hủy" : "Kết bạn";
        }

        private void SetUpUI()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, user);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblName.Text = user.Name;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;

            btnSendRequest.BackColor = Constants.MAIN_FORE_LINK2_COLOR;
            btnSendRequest.ForeColor = Constants.MAIN_FORE_COLOR;

            btnBlock.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            btnBlock.ForeColor = Constants.MAIN_FORE_COLOR;

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(btnSendRequest, 10);
            UIHelper.BorderRadius(btnBlock, 10);
        }

        #endregion

        #region Events

        private void FriendRequestedItemUC_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_ENTER_COLOR, user);
        }

        private void FriendRequestedItemUC_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, user);
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            CurrentFriendUserItemUC = this;

            OnClickSection?.Invoke();
        }

        public void UpdateSendOrCancel()
        {
            btnSendRequest.Text = btnSendRequest.Text == "Hủy" ? "Kết bạn" : "Hủy";
        }

        #endregion

        /// <summary>
        /// Click để kết bạn hoặc hủy kết bãn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            // Cập nhật text
            UpdateSendOrCancel();

            // Thông báo cho cha đã làm
            OnClickSendOrCancelRequest?.Invoke(btnSendRequest.Text == "Hủy");


        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.Show("Nếu bạn chặn thì các bạn sẽ không tìm thấy nhau trên Facebook", MessageBoxType.Question).Value == DialogResult.OK)
            {
                OnClickBlock?.Invoke(this);
            }
        }
    }
}

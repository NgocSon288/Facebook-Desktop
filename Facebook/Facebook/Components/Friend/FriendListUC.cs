using Facebook.Common;
using Facebook.DAO;
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
    public partial class FriendListUC : UserControl
    {
        public delegate void ClickUser(User user);
        public delegate void ClickSendOrCancelRequest(User user, bool isSend);
        public delegate void ClickBlockUser(User user);
        public delegate void ClickDeleteUser(User user);
        public delegate void ClickAcceptUser(User user);
        public event ClickUser OnClickUser;
        public event ClickSendOrCancelRequest OnClickSendOrCancelRequest;
        public event ClickBlockUser OnClickBlockUser;
        public event ClickDeleteUser OnClickDeleteUser;
        public event ClickAcceptUser OnClickAcceptUser;

        private IUserDAO _userDAO;

        private User user;
        private string textSearch;

        private List<User> users;
        private List<int> requestedFriend;
        private List<int> userList;

        private FriendUserListUC friendUserListUC;
        private FriendRequestedListUC requestListUC;

        /// <summary>
        /// Danh sach tất cả các friend
        /// Có một hàm filter nhận text vào vào refresh lại
        /// </summary>
        public FriendListUC(IUserDAO userDAO, User user, string textSearch = "")
        {
            InitializeComponent();

            this._userDAO = userDAO;
            this.user = user;
            this.textSearch = textSearch;

            Load();
            SetColor();
        }

        #region Methods

        new private void Load()
        {
            FilterUserSimple();

            ReloadWithoutUI(textSearch);
        }

        public void ReloadWithoutUI(string textSearch)
        {
            this.textSearch = textSearch;

            // Lọc theo keyword
            if (!string.IsNullOrEmpty(textSearch.Trim()))
            {
                var keyword = textSearch.Trim();
                users = users.Where(u => CompareStringHelper.Contanins(u.Name, keyword)).ToList();
            }

            // Các user gửi yêu cầu kết bạn cho user truyền vào
            requestedFriend = StringHelper.StringToIntList(user.RequestedFriend);

            // Danh sách các user 
            // Không nằm trong requestFriend
            userList = users.Select(u => u.ID).Except(requestedFriend).ToList();

            LoadRequest();

            LoadUserList();

            UpdateHeight();
        }

        /// <summary>
        /// Lọc ra các user không Block và không bị Block bởi user này
        /// Chưa kết bạn
        /// </summary>
        private void FilterUserSimple()
        {
            // danh sách tất cả các user
            users = _userDAO.GetAll();
            IEnumerable<User> temp = users.Where(u => u.ID != Constants.UserSession.ID);

            // lọc bỏ ra các user mà user này block
            var blockList = StringHelper.StringToIntList(user.BlockedFriend);

            temp = temp.Where(u => !blockList.Contains(u.ID));

            // lọc bỏ ra các user block người này
            var byBlockList = StringHelper.StringToIntList(user.ByBlockedFriend);
            temp = temp.Where(u => !byBlockList.Contains(u.ID));

            // lọc bỏ ra các user đã kết bạn rồi
            var friend = StringHelper.StringToIntList(user.Friend);
            temp = temp.Where(u => !friend.Contains(u.ID));

            users = temp.ToList();
        }

        private void LoadRequest()
        {
            pnlRequestedFriend.Controls.Clear();

            // lấy ra danh sách các user gửi kết bạn
            var us = requestedFriend.Join(
                users,
                r => r,
                u => u.ID,
                (r, u) => u
                ).ToList();

            requestListUC = new FriendRequestedListUC(us);
            requestListUC.OnClickUser += (u) => OnClickUser(u);
            requestListUC.OnClickDelete += RequestListUC_OnClickDelete;
            requestListUC.OnClickAccept += RequestListUC_OnClickAccept;

            pnlRequestedFriend.Controls.Add(requestListUC);
        }

        private void LoadUserList()
        {
            pnlUser.Controls.Clear();
            // lấy ra danh sách các user chưa kết bạn
            var us = userList.Join(
                users,
                r => r,
                u => u.ID,
                (r, u) => u
                ).ToList();

            friendUserListUC = new FriendUserListUC(us);
            friendUserListUC.OnClickUser += (u) => OnClickUser(u);
            friendUserListUC.OnClickSendOrCancelRequest += FriendUserListUC_OnClickSendOrCancelRequest;
            friendUserListUC.OnClickBlockUser += FriendUserListUC_OnClickBlockUser;

            pnlUser.Controls.Add(friendUserListUC);
        }

        private void UpdateHeight()
        {
            pnlRequestedFriend.Height = requestListUC.Height;
            pnlUser.Height = friendUserListUC.Height;
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlRequestedFriend.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlUser.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        public void DeleteItemRequestedFriendByUser(User user)
        {
            requestListUC.DeleteItemByUser(user);

            UpdateHeight();
        }

        #endregion

        #region Events

        private void FriendUserListUC_OnClickSendOrCancelRequest(User user, bool isSend)
        {
            // Thêm hoặc xóa id hiện tại vào user được nhấn
            FriendHelper.A_AddOrDelete_Request_B(user, Constants.UserSession.ID);

            OnClickSendOrCancelRequest?.Invoke(user, isSend);
        }

        private void RequestListUC_OnClickAccept(User user)
        {
            users.Remove(user);

            OnClickAcceptUser(user);

            UpdateHeight();
        }

        private void RequestListUC_OnClickDelete(User user)
        {
            users.Remove(user);

            OnClickDeleteUser(user);

            UpdateHeight();
        }

        private void FriendUserListUC_OnClickBlockUser(User user)
        {
            users.Remove(user);

            OnClickBlockUser(user);

            UpdateHeight();
        }


        #endregion
    }
}

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

namespace Facebook.Components.Profile
{
    public partial class InfoProfileFriendsUC : UserControl
    {
        public delegate void LinkToProfile(User user);
        public delegate void HeightChanged();
        public delegate void BlockUser();
        public delegate void DeleteFriend();
        public event LinkToProfile OnLinkToProfile;
        public event HeightChanged OnHeightChanged;
        public event BlockUser OnBlockUser;
        public event DeleteFriend OnDeleteFriend;

        private IUserDAO _userDAO;
        private User user;

        private List<User> friends;
        private bool isProfile;

        public InfoProfileFriendsUC(IUserDAO userDAO, User user, bool isProfile)
        {
            InitializeComponent();

            this._userDAO = userDAO;
            this.user = user;
            this.isProfile = isProfile;

            Load();
        }

        int margin = 20;

        #region Methods

        new private void Load()
        {
            var list = _userDAO.GetAll();
            var friendList = StringHelper.StringToIntList(user.Friend);
            friends = list.Join(friendList, u => u.ID, l => l, (u, l) => u).ToList();

            LoadFriends();
            UpdateHeight();
            SetUpUI();

            OnHeightChanged?.Invoke();
        }

        private void LoadFriends()
        {
            var count = friends.Count;

            if (count > 0)
            {
                for (int i = 0; i < (count - 1) / 2 + 1; i++)
                {
                    var us = friends[i];
                    var itemUC = new InfoProfileFriendItemUC(us, isProfile);
                    itemUC.Margin = new Padding(0, 0, 0, 20);
                    itemUC.OnLinkToProfile += () => OnLinkToProfile?.Invoke(us);
                    itemUC.OnBlockUser += () =>
                    {
                        // Xóa friend UserSession, Thêm BlockFriend us.ID
                        FriendHelper.A_DeleteFriend_B(Constants.UserSession, us.ID);
                        FriendHelper.A_AddBlockedFriend_B(Constants.UserSession, us.ID);

                        // Xóa friend us, Thêm ByBlockFriend UserSession
                        FriendHelper.A_DeleteFriend_B(us, Constants.UserSession.ID);
                        FriendHelper.A_AddByBlockedFriend_B(us, Constants.UserSession.ID);

                        _userDAO.SaveChanges();

                        // Gọi cha cập nhât lại UI
                        OnBlockUser?.Invoke();
                    };
                    itemUC.OnDeleteFriend += () =>
                    {
                        // Xóa friend UserSession
                        FriendHelper.A_DeleteFriend_B(Constants.UserSession, us.ID);

                        // Xóa friend us
                        FriendHelper.A_DeleteFriend_B(us, Constants.UserSession.ID);

                        _userDAO.SaveChanges();

                        // Gọi cha cập nhât lại UI
                        OnBlockUser?.Invoke();
                    };

                    flpContentLeft.Controls.Add(itemUC);
                }
            }

            if (count > 1)
            {
                for (int i = (count - 1) / 2 + 1; i < count; i++)
                {
                    var us = friends[i];
                    var itemUC = new InfoProfileFriendItemUC(us, isProfile);
                    itemUC.Margin = new Padding(0, 0, 0, 20);
                    itemUC.OnLinkToProfile += () => OnLinkToProfile?.Invoke(us);
                    itemUC.OnBlockUser += () =>
                    {
                        // Xóa friend UserSession, Thêm BlockFriend us.ID
                        FriendHelper.A_DeleteFriend_B(Constants.UserSession, us.ID);
                        FriendHelper.A_AddBlockedFriend_B(Constants.UserSession, us.ID);

                        // Xóa friend us, Thêm ByBlockFriend UserSession
                        FriendHelper.A_DeleteFriend_B(us, Constants.UserSession.ID);
                        FriendHelper.A_AddByBlockedFriend_B(us, Constants.UserSession.ID);

                        _userDAO.SaveChanges();

                        // Gọi cha cập nhât lại UI
                        OnBlockUser?.Invoke();
                    };
                    itemUC.OnDeleteFriend += () =>
                    {
                        // Xóa friend UserSession
                        FriendHelper.A_DeleteFriend_B(Constants.UserSession, us.ID);

                        // Xóa friend us
                        FriendHelper.A_DeleteFriend_B(us, Constants.UserSession.ID);

                        _userDAO.SaveChanges();

                        // Gọi cha cập nhât lại UI
                        OnBlockUser?.Invoke();
                    };

                    flpContentLeft.Controls.Add(itemUC);

                    flpContentRight.Controls.Add(itemUC);
                }
            }
        }

        private void UpdateHeight()
        {
            var height = 0;

            foreach (Control item in flpContentLeft.Controls)
            {
                height += item.Height + item.Margin.Top + item.Margin.Bottom;
            }

            if (height == 0)
            {
                var pic = new PictureBox();
                pic.Width = 300;
                pic.Height = 300;
                pic.Location = new Point(776, 150);
                pic.BackgroundImage = Image.FromFile("./../../Assets/Images/Profile/empty-friend.png");
                pic.BackgroundImageLayout = ImageLayout.Stretch;

                pnlWrap.Controls.Clear();
                var lbl = new Label()
                {
                    Text = "Chưa có bạn bè nào",
                    ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR,
                    BackColor = Constants.MAIN_BACK_COLOR,
                    AutoSize = true
                };
                lbl.Location = new Point(730, 440);

                pnlWrap.Controls.Add(pic);
                pnlWrap.Controls.Add(lbl);
            }

            if (friends.Count >= 7)
            {
                this.Height = height + 2 * margin + 60;
                pnlWrap.Height = height;
            }

        }

        private void SetUpUI()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;

            pnlWrap.BackColor = Constants.MAIN_BACK_COLOR;
            pnlWrap.Location = new Point(20, 0);
            pnlWrap.Height = this.Height - 2 * margin;
            pnlWrap.Width = this.Width - 2 * margin - 15;

            flpContentLeft.Width = pnlWrap.Width / 2 - 20;
            flpContentLeft.BackColor = Constants.MAIN_BACK_COLOR;
            flpContentRight.Width = pnlWrap.Width / 2 - 20;
            flpContentRight.BackColor = Constants.MAIN_BACK_COLOR;

            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        #endregion

        #region Events


        #endregion 
    }
}

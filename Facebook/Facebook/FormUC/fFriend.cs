using Facebook.Common;
using Facebook.Components.Friend;
using Facebook.Components.Profile;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
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

namespace Facebook.FormUC
{
    public partial class fFriend : UserControl
    {
        private readonly IUserDAO _userDAO;

        private User CurrentUser;

        private FriendListUC friendList;
        private FriendMenuProfileUC menu;

        private FriendSearchBoxUC friendSearchBoxUC;

        public fFriend(IUserDAO userDAO)
        {
            InitializeComponent();

            this._userDAO = userDAO;

            SetUpUI();
            Load();
        }

        #region Methods

        new private void Load()
        {
            picEmptyPeople.BackgroundImage = Image.FromFile("./../../Assets/Images/Friend/null-people.png");
            lblEmptyPeople.ForeColor = Constants.MAIN_FORE_COLOR;
            lblEmptyPeople.Top = 0;

            LoadSearch();
            LoadList();
            SetColor();
            UpdateHeight();
            // hiện tại gọi test
            LoadProfile();
        }

        private void LoadSearch()
        {
            friendSearchBoxUC = new FriendSearchBoxUC();
            friendSearchBoxUC.Location = new Point(0, 0);
            friendSearchBoxUC.OnSubmit += FriendSearchBoxUC_OnSubmit;

            pnlLeft.Controls.Add(friendSearchBoxUC);
        }

        private void LoadList(string textSearch = "")
        {
            if (pnlLeft.Controls.Contains(friendList))
            {
                pnlLeft.Controls.Remove(friendList);
            }

            friendList = new FriendListUC(AutofacFactory<IUserDAO>.Get(), Constants.UserSession, textSearch);
            friendList.OnClickUser += (u) => { CurrentUser = u; LoadProfile(); };
            friendList.OnClickSendOrCancelRequest += FriendList_OnClickSendOrCancelRequest;
            friendList.OnClickBlockUser += FriendList_OnClickBlockUser;
            friendList.OnClickDeleteUser += FriendList_OnClickDeleteUser;
            friendList.OnClickAcceptUser += FriendList_OnClickAcceptUser;

            friendList.Location = new Point(0, 240);
            pnlLeft.Controls.Add(friendList);
        }

        /// <summary>
        /// Khi click vào item trong list thì gọi lại hàm này
        /// Và nhận tham số
        /// </summary>
        private void LoadProfile()
        {

            if (CurrentUser == null)
            {
                pnlMainContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            }
            else
            {
                pnlMainContent.BackColor = Constants.MAIN_BACK_COLOR;
                pnlHead.Controls.Clear();
                pnlMenu.Controls.Clear();

                LoadHeaderProfile();

                LoadMenuProfile();

                LoadInfoProfile();
            }
        }

        private void LoadHeaderProfile()
        {
            pnlHead.Controls.Clear();

            var header = new FriendHeaderProfileUC(CurrentUser);
            header.Dock = DockStyle.Fill;

            pnlHead.Height = header.Height;
            pnlHead.Controls.Add(header);
        }

        /// <summary>
        /// Kiểm tra user hiện tại với user truyền vào đã gửi lời mới kết bạn chua
        /// </summary>
        private void LoadMenuProfile()
        {
            pnlMenu.Controls.Clear();

            // Kiểm tra đã gửi request chưa
            bool isRequested = FriendHelper.A_SendRequest_B(Constants.UserSession, CurrentUser);

            bool isFriend = FriendHelper.A_SendRequest_B(CurrentUser, Constants.UserSession);

            menu = new FriendMenuProfileUC(isRequested, isFriend);
            menu.Dock = DockStyle.Fill;
            menu.OnClickAddFriend += Menu_OnClickAddFriend; ;
            menu.OnLinkToProfile += () => LoadProfileByUser();
            menu.OnClickAcceptOrDeleteFriend += Menu_OnClickAcceptOrDeleteFriend;
            menu.OnClickIntro += LoadInfoProfile;
            menu.OnClickPosts += LoadPostsProfile;

            pnlMenu.Height = menu.Height;
            pnlMenu.Controls.Add(menu);
        }

        private void LoadInfoProfile()
        {
            pnlMainContent.Controls.Clear();

            var info = new InfoProfileUC(AutofacFactory<IProfileDAO>.Get(), CurrentUser);
            info.OnHeightChanged += () => { UpdateHeight(); };

            pnlMainContent.Height = info.Height;
            pnlMainContent.Controls.Add(info);

            info.Left = pnlMainContent.Width / 2 - info.Width / 2;

            UpdateHeight();
        }

        private void LoadPostsProfile()
        {
            pnlMainContent.Controls.Clear();

            var postListProfileUC = new PostListProfileUC(AutofacFactory<IPostDAO>.Get(), CurrentUser, PostListProfileUC.PAGE.PROFILE);
            postListProfileUC.OnHeightChanged += () => UpdateHeight();
            postListProfileUC.OnClickProfileFriend += LoadProfileByUser;
            postListProfileUC.Left = pnlMainContent.Width / 2 - postListProfileUC.Width / 2;

            pnlMainContent.Controls.Add(postListProfileUC);
            UpdateHeight();
        }

        private void UpdateHeight()
        {
            try
            {
                if (CurrentUser != null)
                {
                    pnlMainContent.Height = pnlMainContent.Controls[0].Height;
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Show profile friend
        /// </summary>
        /// <param name="user"></param>
        private void LoadProfileByUser(User user = null)
        {
            var fProfileFriend = new fProfileFriend(AutofacFactory<IUserDAO>.Get(), user!=null?user: CurrentUser, panelContent, PostListProfileUC.PAGE.PROFILE);

            UIHelper.ShowControl(fProfileFriend, panelContent);
        }

        private void SetColor()
        {
            flpContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlMainContent.BackColor = Constants.MAIN_BACK_COLOR;
            pnlLeft.BackColor = Constants.MAIN_BACK_COLOR;
            pnlHead.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlMenu.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            UIHelper.BorderRadius(flpContent, Constants.BORDER_RADIUS);
        }

        /// <summary>
        /// Empty nếu  có thể
        /// </summary>
        /// <param name="user"></param>
        private void EmptyPeople(User user)
        {
            if (user == CurrentUser)
            {
                pnlHead.Controls.Clear();
                pnlMenu.Controls.Clear();
                pnlMainContent.Controls.Clear();

                pnlHead.Controls.Add(picEmptyPeople);
                pnlHead.Controls.Add(lblEmptyPeople);

                lblEmptyPeople.Top = pnlHead.Height - lblEmptyPeople.Height - 143;
                pnlMainContent.Height = 0;

                pnlMainContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Thực hiện lọc
        /// </summary>
        /// <param name="text"></param>
        private void FriendSearchBoxUC_OnSubmit(string text)
        {
            LoadList(text);
        }

        /// <summary>
        /// Thông báo item trong list cập nhật lại 
        /// </summary>
        private void Menu_OnClickAddFriend()
        {
            FriendUserItemUC.CurrentFriendUserItemUC?.UpdateSendOrCancel();

            // Cập nhật DB void User CurrentUser
            FriendHelper.A_AddOrDelete_Request_B(CurrentUser, Constants.UserSession.ID);
            _userDAO.SaveChanges();

        }

        /// <summary>
        /// Kiểm tra nếu user trùng CurrentUser thì xóa profile hiện tại
        /// </summary>
        /// <param name="user"></param>
        private void FriendList_OnClickBlockUser(User user)
        {
            EmptyPeople(user);

            // cập nhật db
            // Xóa  friend cả 2  bên néu có
            FriendHelper.A_DeleteFriend_B(user, Constants.UserSession.ID);
            FriendHelper.A_DeleteFriend_B(Constants.UserSession, user.ID);

            // Xóa requestedFriend cả 2 bên nếu có
            FriendHelper.A_DeleteRequestedFriend_B(user, Constants.UserSession.ID);
            FriendHelper.A_DeleteRequestedFriend_B(Constants.UserSession, user.ID);

            // Thêm vào danh sách Block của UserSession
            FriendHelper.A_AddBlockedFriend_B(Constants.UserSession, user.ID);

            // Thêm vào danh sách ByBlock của CurrentUser
            FriendHelper.A_AddByBlockedFriend_B(user, Constants.UserSession.ID);

            _userDAO.SaveChanges();
        }

        private void FriendList_OnClickDeleteUser(User user)
        {
            EmptyPeople(user);

            // cập nhật db
            // Xóa id của user trong UserSession.RequestedFriend
            FriendHelper.A_DeleteRequestedFriend_B(Constants.UserSession, user.ID);

            _userDAO.SaveChanges();
        }

        private void FriendList_OnClickAcceptUser(User user)
        {
            if (user == CurrentUser)
            {
                // Gọi menu cập nhật nút thêm bạn bè
                menu.UpdateButtonSendOrCancelRequest(true);
            }

            // Cập nhật db, chỉ có accept vì nhấn một làn là xóa luôn
            // Hủy bỏ Request bên UserSession
            FriendHelper.A_DeleteRequestedFriend_B(Constants.UserSession, user.ID);

            // Thêm friend vào UserSession
            FriendHelper.A_AddFriend_B(Constants.UserSession, user.ID);

            // Thêm Friend vào User
            FriendHelper.A_AddFriend_B(user, Constants.UserSession.ID);

            _userDAO.SaveChanges();
        }

        private void Menu_OnClickAcceptOrDeleteFriend()
        {
            // Xóa trong requested Friend
            friendList.DeleteItemRequestedFriendByUser(CurrentUser);

            UpdateHeight();

            // Cập nhật db, có thể là accept request hoặc delete friend trong danh sách friend 
            // Hủy bỏ Request bên UserSession nếu có
            FriendHelper.A_DeleteRequestedFriend_B(Constants.UserSession, CurrentUser.ID);

            // Thêm hoặc xóa friend vào UserSession
            FriendHelper.A_AddOrDelete_Friend_B(Constants.UserSession, CurrentUser.ID);

            // Thêm hoặc  xóa Friend vào User
            FriendHelper.A_AddOrDelete_Friend_B(CurrentUser, Constants.UserSession.ID);

            _userDAO.SaveChanges();
        }

        /// <summary>
        /// Cập nhật menu khi cần thiết
        /// </summary>
        /// <param name="isSend"></param>
        private void FriendList_OnClickSendOrCancelRequest(User user, bool isSend)
        {
            // Cần cập nhật lại nút trong menu
            if (user == CurrentUser)
            {
                menu.UpdateButtonSendOrCancelRequest(isSend);
            }

            // Cập nhật  DB với User truyền  vào
            _userDAO.SaveChanges();
        }

        #endregion

        #region SetUpUI

        private void SetUpUI()
        {
            // Set background color for form
            this.BackColor = Constants.MAIN_BACK_COLOR;

            // Set color for button control window
            btnMinimize.BackColor = Constants.MAIN_BACK_COLOR;
            btnMinimize.ForeColor = Constants.MAIN_FORE_COLOR;
            btnMinimize.FlatAppearance.MouseOverBackColor = Constants.CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR;
            btnClose.BackColor = Constants.MAIN_BACK_COLOR;
            btnClose.ForeColor = Constants.MAIN_FORE_COLOR;
            btnClose.FlatAppearance.MouseOverBackColor = Constants.CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            if (MyMessageBox.Show("Bạn có muốn thoát?", MessageBoxType.Question).Value == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, System.EventArgs e)
        {
            Constants.MainForm.WindowState = FormWindowState.Minimized;
        }

        #endregion
    }
}

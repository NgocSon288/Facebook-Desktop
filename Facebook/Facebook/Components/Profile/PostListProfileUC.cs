using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.ControlCustom.WrapperForm;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class PostListProfileUC : UserControl
    {
        public delegate void HeightChanged();
        public delegate void ClickProfileFriend(User user);
        public event HeightChanged OnHeightChanged;
        public event ClickProfileFriend OnClickProfileFriend;

        private readonly IPostDAO _postDAO;
        private User user;

        private List<Post> posts;

        private PAGE page;
        private List<int> friendList;       // danh sách các bạn  của user hiện tại

        public PostListProfileUC(IPostDAO postDAO, User user = null, PAGE page = PAGE.PROFILE)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            Control.CheckForIllegalCrossThreadCalls = false;

            this._postDAO = postDAO;
            this.user = user == null ? Constants.UserSession : user;
            this.page = page;

            Load();
            //UIHelper.SetBlur(this, (o, s) => this.ActiveControl = (Control)o, true);
        }


        private int margin = 10;

        // Sau này có thể thêm profile của bạn bè
        public enum PAGE
        {
            PROFILE,
            HOME,
            FRIEND_FRIENDSHIP,
            FRIEND_NO_FRIENDSHIP
        }

        #region Methods

        new private async Task Load()
        {
            // Kiểm tra user hiện tại với user truyền vào có là  bạn
            if (Constants.UserSession != null)
            {
                friendList = StringHelper.StringToStringList(Constants.UserSession.Friend).Select(i => Convert.ToInt32(i)).ToList();
            }
            else
            {
                friendList = new List<int>();
            }

            if (user != null)
            {
                await FilterPost();

                LoadPostItems();

                pnlThink.Visible = user == Constants.UserSession;
                pnlSeparator.Visible = user == Constants.UserSession;

                LoadUI();
                SetColor();

                //UIHelper.SetBlur(this, (o, s) => this.ActiveControl = (Control)o, true);
            }
        }

        private async Task FilterPost()
        {
            switch (page)
            {
                case PAGE.PROFILE:
                    posts = await _postDAO.GetByUserID(user.ID);

                    if (user.ID != Constants.UserSession.ID)
                    {
                        posts = posts.Where(p => p.PostStatusID != 3).ToList();


                        if (!friendList.Contains(user.ID))
                        {
                            posts = posts.Where(p => p.PostStatusID != 2).ToList();
                        }

                        // Nếu user và userSession không là bạn thì lọc != 2
                    }

                    break;
                case PAGE.HOME:
                    posts = await _postDAO.GetAll();
                    // post public
                    var postPublic = posts.Where(p => p.PostStatusID == 1);

                    // Friend
                    var postFriend = posts.Where(p => p.PostStatusID == 2 && friendList.Contains(p.User.ID));

                    // Self
                    var postSelf = posts.Where(p => p.User.ID == Constants.UserSession.ID);

                    posts = postPublic.Union(postFriend).Union(postSelf).OrderByDescending(u => u.CreatedAt).ToList();

                    break;
                case PAGE.FRIEND_FRIENDSHIP:
                    MessageBox.Show("Coi lại post list profile");
                    if (user == Constants.UserSession)
                    {
                        posts = await _postDAO.GetByUserID(user.ID);
                        break;
                    }

                    posts = await _postDAO.GetByUserIDByFriendPageHaveFriendShip(user.ID);
                    break;
                case PAGE.FRIEND_NO_FRIENDSHIP:
                    MessageBox.Show("Coi lại post list profile");
                    posts = await _postDAO.GetByUserIDByFriendPageNoFriendShip(user.ID);
                    break;
            }
        }

        private async Task LoadPostItems()
        {
            flpContent.Controls.Clear();

            foreach (Control item in flpContent.Controls)
            {
                item.Dispose();
            }
            Task task = new Task(() =>
            {
                lock (posts)
                {
                    foreach (var item in posts)
                    {
                        var postItem = new PostItemUC(item, page);
                        postItem.Margin = new Padding(0, 0, 0, 25);
                        postItem.OnHeightChaned += PostItem_OnHeightChaned;
                        postItem.OnUpdatedPostItem += PostItem_OnUpdatedPostItem;
                        postItem.OnDeletePost += PostItem_OnDeletePost;
                        postItem.OnClickProfileFriend += (u) => OnClickProfileFriend?.Invoke(u);


                        if (flpContent.InvokeRequired)
                        {

                            flpContent.BeginInvoke((Action)(() =>
                            {
                                flpContent.Controls.Add(postItem);
                                UIHelper.BorderRadius(postItem, Constants.BORDER_RADIUS);
                            }));
                        }
                        else
                        {
                            flpContent.Controls.Add(postItem);
                        }

                        Thread.Sleep(1);

                        UpdateHeight();

                        UIHelper.BorderRadius(flpContent, Constants.BORDER_RADIUS);
                    }

                    UpdateHeight();
                }
            });

            task.Start();
            await task;

            if (posts.Count <= 0)
            {
                var emptyItem = new PostEmptyItemUC();
                if (flpContent.InvokeRequired)
                {

                    flpContent.BeginInvoke((Action)(() =>
                    {
                        flpContent.Controls.Add(emptyItem);
                        UIHelper.BorderRadius(emptyItem, Constants.BORDER_RADIUS);
                    }));
                }
                else
                {
                    flpContent.Controls.Add(emptyItem);
                }

                UpdateHeight();
            }
        }

        private void PostItem_OnDeletePost(PostItemUC postItemUC)
        {
            var postDeleted = postItemUC.post;

            // Xóa post trong  posts hiện  tại
            posts.Remove(postDeleted);

            // cập nhật db
            _postDAO.Delete(postDeleted);

            // Xóa ui
            LoadPostItems();

            UpdateHeight();
            OnHeightChanged?.Invoke();

            MyMessageBox.Show("Xóa bài viết thành công!", MessageBoxType.Success);
        }

        private async void PostItem_OnUpdatedPostItem()
        {
            posts = await _postDAO.GetByUserID(user.ID);

            LoadPostItems();
        }

        private void LoadUI()
        {
            // Load image think
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblText.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            pnlWrapText.BackColor = Constants.BOX_WRAP_TEXT_COLOR;

            pnlContent.Location = new Point(margin + 5, 0);

            UIHelper.BorderRadius(pnlThink, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(pnlWrapText, Constants.BORDER_RADIUS * 2);

        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            pnlContent.BackColor = Constants.MAIN_BACK_COLOR;   //adasd
            pnlThink.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            flpContent.BackColor = Constants.MAIN_BACK_COLOR;

            pnlSeparator.BackColor = Constants.MAIN_BACK_COLOR;
            pnlSeparator.Height = 25;
        }

        private void UpdateHeight()
        {
            try
            {
                var mar = margin * 2;
                var heightHead = pnlThink.Visible ? pnlThink.Height : 0;
                var heightSe = pnlThink.Visible ? pnlSeparator.Height : 0;
                var heightContent = 0;

                foreach (Control item in flpContent.Controls)
                {
                    heightContent += item.Height + item.Margin.Bottom;
                }

                this.Height = mar + heightHead + heightSe + heightContent;
                pnlContent.Height = this.Height - mar;
                flpContent.Height = heightContent;

                OnHeightChanged?.Invoke();

                if (!pnlThink.Visible)
                {
                    //pnlContent.Top = -10;
                }

                UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
                UIHelper.BorderRadius(flpContent, Constants.BORDER_RADIUS);
                UIHelper.BorderRadius(pnlThink, Constants.BORDER_RADIUS);
                UIHelper.BorderRadius(pnlContent, Constants.BORDER_RADIUS);
            }
            catch (Exception)
            {
            }
        }

        public void UpdateAvatar()
        {
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR);

            foreach (PostItemUC item in flpContent.Controls)
            {
                item.UpdateAvatar();
            }
        }

        #endregion

        #region Events  
        private void PostItem_OnHeightChaned()
        {
            UpdateHeight();
            OnHeightChanged?.Invoke();
        }

        #endregion

        private void pnlWrapText_MouseEnter(object sender, EventArgs e)
        {
            pnlWrapText.BackColor = Constants.BOX_WRAP_TEXT_ENTER_COLOR;
            lblText.BackColor = Constants.BOX_WRAP_TEXT_ENTER_COLOR;

            UIHelper.BorderRadius(pnlWrapText, Constants.BORDER_RADIUS * 2);
        }

        private void pnlWrapText_MouseLeave(object sender, EventArgs e)
        {
            pnlWrapText.BackColor = Constants.BOX_WRAP_TEXT_COLOR;
            lblText.BackColor = Constants.BOX_WRAP_TEXT_COLOR;

            UIHelper.BorderRadius(pnlWrapText, Constants.BORDER_RADIUS * 2);
        }

        private async void pnlWrapText_Click(object sender, EventArgs e)
        {
            this.ActiveControl = lblText;
            var isCreated = false;
            try
            {
                var fWrapCreatePost = new fWrapCreatePost(AutofacFactory<IPostStatusDAO>.Get(), AutofacFactory<IPostDAO>.Get());
                fWrapCreatePost.OnCreatedPost += (s) => isCreated = s != null;
                var fParent = new fParent(fWrapCreatePost); // Show  thông qua parent, sẽ có hiệu ứng ảo
                fParent.ShowDialog();
            }
            catch (Exception)
            {

            }

            if (isCreated)
            {
                await FilterPost();

                LoadPostItems();
            }
        }
    }
}

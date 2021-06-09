﻿using Facebook.Common;
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

        public PostListProfileUC(IPostDAO postDAO, User user = null, PAGE page = PAGE.PROFILE)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            Control.CheckForIllegalCrossThreadCalls = false;

            this._postDAO = postDAO;
            this.user = user == null ? Constants.UserSession : user;
            this.page = page;

            Load();
        }

        private Image image1;
        private Image image2;
        private int margin = 20;

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
            if (user != null)
            {
                // TH Home hoặc Profile
                // Nếu là home thì không có modified 
                switch (page)
                {
                    case PAGE.PROFILE:
                        posts = await _postDAO.GetByUserID(user.ID);
                        break;
                    case PAGE.HOME:
                        posts = await _postDAO.GetByUserIDByHomePage(user.ID);
                        break;
                    case PAGE.FRIEND_FRIENDSHIP:
                        if (user == Constants.UserSession)
                        {
                            posts = await _postDAO.GetByUserID(user.ID);
                            break;
                        }

                        posts = await _postDAO.GetByUserIDByFriendPageHaveFriendShip(user.ID);
                        break;
                    case PAGE.FRIEND_NO_FRIENDSHIP:
                        posts = await _postDAO.GetByUserIDByFriendPageNoFriendShip(user.ID);
                        break;
                }


                LoadPostItems();

                pnlThink.Visible = user == Constants.UserSession;

                LoadUI();
                SetColor();

                UIHelper.SetBlur(this, () => this.ActiveControl = null);
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
                }

                if (posts.Count <= 0)
                {
                    var emptyItem = new PostEmptyItemUC();

                    flpContent.Controls.Add(emptyItem);
                }
            });

            task.Start();
            await task;
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
            image1 = ImageHelper.FromFile("./../../Assets/Images/Profile/think-1.png");
            image2 = ImageHelper.FromFile("./../../Assets/Images/Profile/think-2.png");

            // Load image think
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            picThink.BackgroundImage = image1;
            picThink.BackgroundImageLayout = ImageLayout.Stretch;

            pnlContent.Location = new Point(margin, margin);

            UIHelper.BorderRadius(pnlThink, Constants.BORDER_RADIUS);

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
            var mar = margin * 2;
            var heightHead = pnlThink.Visible ? pnlThink.Height : 0;
            var heightSe = pnlSeparator.Height;
            var heightContent = 0;

            foreach (Control item in flpContent.Controls)
            {
                heightContent += item.Height + item.Margin.Bottom;
            }

            this.Height = mar + heightHead + heightSe + heightContent;
            pnlContent.Height = this.Height - mar;
            flpContent.Height = heightContent;

            OnHeightChanged?.Invoke();

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(flpContent, Constants.BORDER_RADIUS);

            if (!pnlThink.Visible)
            {
                var a = pnlContent.Top;

                pnlContent.Top -= 8;
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

        private void picThink_MouseEnter(object sender, EventArgs e)
        {
            picThink.BackgroundImage = image2;
        }

        private void picThink_MouseLeave(object sender, EventArgs e)
        {
            picThink.BackgroundImage = image1;
        }

        private async void picThink_Click(object sender, EventArgs e)
        {
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
                // TH Home hoặc Profile
                // Nếu là home thì không có modified 
                switch (page)
                {
                    case PAGE.PROFILE:
                        posts = await _postDAO.GetByUserID(user.ID);
                        break;
                    case PAGE.HOME:
                        posts = await _postDAO.GetByUserIDByHomePage(user.ID);
                        break;
                    case PAGE.FRIEND_FRIENDSHIP:
                        posts = await _postDAO.GetByUserIDByFriendPageHaveFriendShip(user.ID);
                        break;
                    case PAGE.FRIEND_NO_FRIENDSHIP:
                        posts = await _postDAO.GetByUserIDByFriendPageNoFriendShip(user.ID);
                        break;
                }

                LoadPostItems();
            }

        }

        private void PostItem_OnHeightChaned()
        {
            UpdateHeight();
            OnHeightChanged?.Invoke();
        }

        #endregion
    }
}

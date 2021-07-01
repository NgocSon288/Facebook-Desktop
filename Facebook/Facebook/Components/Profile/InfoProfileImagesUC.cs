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
    public partial class InfoProfileImagesUC : UserControl
    {
        public delegate void HeightChanged();
        public event HeightChanged OnHeightChanged;

        private IPostDAO _postDAO;
        private User user;

        private List<Post> imagesPublic;
        private List<Post> imagesFriend;
        private List<Post> imagesPrivate;


        public InfoProfileImagesUC(IPostDAO postDAO, User user)
        {
            InitializeComponent();

            this._postDAO = postDAO;
            this.user = user;

            Load();
        }

        #region Methods

        new private async void Load()
        {
            await LoadImage();

            SetUpUI();
            UpdateImage();

            OnHeightChanged?.Invoke();
        }

        private async Task LoadImage()
        {
            imagesPublic = new List<Post>();
            imagesFriend = new List<Post>();
            imagesPrivate = new List<Post>();

            // Từ Post
            var posts = await _postDAO.GetByUserID(user.ID);

            // Nếu là bạn
            if (FriendHelper.AIsFriendB(user, Constants.UserSession))
            {
                posts = posts.Where(p => p.PostStatusID == 1 || p.PostStatusID == 2).ToList();
            }
            // Không là bạn, không là chính bản thân
            else if (user != Constants.UserSession)
            {
                posts = posts.Where(p => p.PostStatusID == 1).ToList();
            }

            foreach (var item in posts)
            {
                if (!string.IsNullOrEmpty(item.Image))
                {
                    switch (item.PostStatusID)
                    {
                        case 1:
                            imagesPublic.Add(item);
                            //imagesPublic.Add($"./../../Assets/Images/Post/{item.Image}");
                            break;
                        case 2:
                            imagesFriend.Add(item);
                            //imagesFriend.Add($"./../../Assets/Images/Post/{item.Image}");
                            break;
                        case 3:
                            imagesPrivate.Add(item);
                            //imagesPrivate.Add($"./../../Assets/Images/Post/{item.Image}");
                            break;

                    }

                }
            }


            if (!string.IsNullOrEmpty(user.Image) || !string.IsNullOrEmpty(user.Avatar))
            {
                var itemUC = new InfoProfileImagesGroupUC("Ảnh nền, ảnh đại diện", user, true);
                flpContent.Controls.Add(itemUC);
            }

            if (imagesPublic.Count > 0)
            {
                var itemUC = new InfoProfileImagesGroupUC("Ảnh bài viết công khai", imagesPublic);
                flpContent.Controls.Add(itemUC);
            }

            if (imagesFriend.Count > 0)
            {
                var itemUC = new InfoProfileImagesGroupUC("Ảnh bài viết bạn bè", imagesFriend);
                flpContent.Controls.Add(itemUC);
            }

            if (imagesPrivate.Count > 0)
            {
                var itemUC = new InfoProfileImagesGroupUC("Ảnh bài viết riêng tư", imagesPrivate);
                flpContent.Controls.Add(itemUC);
            }
        }

        private void SetUpUI()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;

            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlWrap.Location = new Point(20, 0);
            pnlWrap.Height = this.Height - 2 * 20;
            pnlWrap.Width = this.Width - 2 * 20 - 15;

            flpContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void UpdateImage()
        {
            var count = flpContent.Controls.Count;

            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            if (count == 0)
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
                    Text = "Chưa có hình ảnh nào",
                    ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR,
                    BackColor = Constants.MAIN_BACK_COLOR,
                    AutoSize = true
                };
                lbl.Location = new Point(730, 440);

                pnlWrap.BackColor = Constants.MAIN_BACK_COLOR;
                pnlWrap.Controls.Add(pic);
                pnlWrap.Controls.Add(lbl);
                this.Height = pnlWrap.Height;
                return;
            }

            var height = 0;

            foreach (Control item in flpContent.Controls)
            {
                height += item.Height;
            }

            pnlWrap.Height = height;
            this.Height = pnlWrap.Height;

            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }
    }

    #endregion

    #region Events


    #endregion
}
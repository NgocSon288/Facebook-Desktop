using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Image;
using Facebook.ControlCustom.Message;
using Facebook.ControlCustom.WrapperForm;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Facebook.Components.Profile.PostListProfileUC;

namespace Facebook.Components.Profile
{
    public partial class PostItemUC : UserControl
    {
        public delegate void UpdatedPostItem();
        public delegate void HeightChaned();
        public delegate void DeletePost(PostItemUC postItemUC);
        public delegate void ClickProfileFriend(User user);
        public event UpdatedPostItem OnUpdatedPostItem;
        public event HeightChaned OnHeightChaned;
        public event DeletePost OnDeletePost;
        public event ClickProfileFriend OnClickProfileFriend;

        public Post post;

        PostCommentUC postCommentUC;

        public PAGE page;

        public PostItemUC(Post post, PAGE page = PAGE.PROFILE)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            this.post = post;
            this.page = page;

            Load();
        }

        private int margin = 20;
        private int ch = 47;

        #region Methods

        new private void Load()
        {
            // Home or Profile or...
            btnMenu.Visible = post.User.ID == Constants.UserSession.ID;

            if (page != PAGE.PROFILE)
            {
                btnMenu.Visible = false;
            }

            this.Margin = new Padding(0, 0, 0, margin);

            // Head
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, post.User);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            lblName.Text = post.User.Name;
            lblTime.Text = GetTime(post.CreatedAt);
            picPostStatusIcon.IconChar = GetIcon();
            picPostStatusIcon.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            picPostStatusIcon.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            picPostStatusIcon.Left = lblTime.Right + 20;

            btnMenu.BackgroundImage = ImageHelper.FromFile("./../../Assets/Images/Profile/menu-icon.png");
            btnMenu.BackgroundImageLayout = ImageLayout.Stretch;

            btnDelete.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnDelete.IconColor = Constants.MAIN_FORE_COLOR;

            pnlMenu.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            // Comment
            LoadComment();


            LoadDetail();
            SetColor();
            UpdateHeight();

            UIHelper.SetBlur(this, () => this.ActiveControl = null);
        }

        private IconChar GetIcon()
        {
            switch (post.PostStatusID)
            {
                case 1:
                    return IconChar.UserFriends;
                case 2:
                    return IconChar.User;
                default:
                    return IconChar.Lock;
            }
        }

        private void LoadComment()
        {
            postCommentUC = new PostCommentUC(AutofacFactory<IPostDAO>.Get(), AutofacFactory<ICommentDAO>.Get(), post);
            postCommentUC.OnHeightChanged += PostCommentUC_OnHeightChanged;
            postCommentUC.OnClickProfileFriend += (u) => OnClickProfileFriend?.Invoke(u);

            this.Height += postCommentUC.Height;
            pnlComment.Controls.Add(postCommentUC);
            //pnlComment.Height = postCommentUC.Height;
        }

        private void LoadDetail()
        {
            lblDescription.Text = post.Description;

            // Description
            int row = post.Description.Length / ch;
            var heightLbl = (row + 1) * 40 + 10;
            lblDescription.Height = heightLbl;
            pnlDescription.Height = heightLbl;


            if (string.IsNullOrEmpty(post.Image))
            {
                picImage.Visible = false;
                picImage.Height = 0;
            }
            else
            {
                var image = ImageHelper.FromFile($"./../../Assets/Images/Post/{post.Image}");
                var width = image.Width;
                var height = image.Height;
                var widthPic = picImage.Width;
                var heightPic = widthPic * height / width;

                picImage.Height = heightPic;
                picImage.BackgroundImage = null;
                picImage.BackgroundImage = image;
                picImage.BackgroundImageLayout = ImageLayout.Stretch;
                picImage.Visible = true;
            }

            pnlDescription.Height = lblDescription.Height;
        }

        private void UpdateHeight()
        {
            var heightHead = pnlHead.Height;
            var heightDescription = pnlDescription.Height;
            var heightPic = 0;
            if (picImage.Visible)
            {
                heightPic = picImage.Height;
            }

            var heightComment = pnlComment.Controls[0].Height;  // pnlComment dock fill nên height phụ thuộc vào  this

            this.Height = heightHead + heightDescription + heightPic + heightComment;

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlHead.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            lblName.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            lblTime.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblTime.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            btnEdit.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnEdit.IconColor = Constants.MAIN_FORE_COLOR;

            pnlDescription.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            lblDescription.ForeColor = Constants.MAIN_FORE_COLOR;
            lblDescription.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlComment.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private string GetTime(DateTime time)
        {
            var da = time.ToShortDateString();
            var ti = time.ToShortTimeString();

            var day = da.Substring(0, da.IndexOf('/'));
            da = da.Substring(da.IndexOf('/') + 1);
            var month = da.Substring(0, da.IndexOf('/'));
            var year = da.Substring(da.IndexOf('/') + 1);
            var hour = ti.Substring(0, ti.IndexOf(':'));
            var minute = ti.Substring(ti.IndexOf(':') + 1, ti.IndexOf(' ') - ti.IndexOf(':') - 1);
            var apm = ti.Substring(ti.IndexOf(' ') + 1);

            hour = apm == "PM" ? (Convert.ToInt32(hour) + 12).ToString() : hour;

            return $"{hour}:{minute}, {day} tháng {month} năm {year}";
        }

        public void UpdateAvatar()
        {
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, post.User);

            postCommentUC.UpdateAvatar();
        }

        #endregion


        #region Events

        private void PostCommentUC_OnHeightChanged()
        {
            UpdateHeight();
            OnHeightChaned?.Invoke();

            // Cập nhật lại border, vì nó không tự cập nhật lại khi lập trình bất đồng bộ
            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
        }


        /// <summary>
        /// Update lại bài viết
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var isUpdate = false;
            try
            {
                var fWapUpdatePost = new fWrapUpdatePost(AutofacFactory<IPostStatusDAO>.Get(), AutofacFactory<IPostDAO>.Get(), post);
                fWapUpdatePost.OnUpdatedPost += FWapUpdatePost_OnUpdatedPost;
                var fParent = new fParent(fWapUpdatePost); // Show  thông qua parent, sẽ có hiệu ứng ảo
                fParent.ShowDialog();
            }
            catch (Exception error)
            {
                MyMessageBox.Show(error.Message, MessageBoxType.Error);
            }

            //if (isUpdate)
            //{
            //    // Cập nhật lại Post hiện tại
            //    LoadDetail();
            //    UpdateHeight();
            //    OnHeightChaned?.Invoke();
            //}
        }

        private void FWapUpdatePost_OnUpdateImage(string path)
        {
            var image = ImageHelper.FromFile(path);
            var width = image.Width;
            var height = image.Height;
            var widthPic = picImage.Width;
            var heightPic = widthPic * height / width;

            picImage.Height = heightPic;
            picImage.BackgroundImage = image;
            picImage.BackgroundImageLayout = ImageLayout.Stretch;
            picImage.Visible = true;

        }

        private void FWapUpdatePost_OnUpdatedPost()
        {
            // Dùng post này để cập nhật UI post List  
            OnUpdatedPostItem?.Invoke();
        }

        /// <summary>
        /// Cần show hình ảnh lên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picImage_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Visible)
            {
                pnlMenu.Visible = false;
            }
            //Constants.MainForm.TopMost = true;
            MyImage.Show($"./../../Assets/Images/Post/{post.Image}");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = !pnlMenu.Visible;
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Visible)
            {
                pnlMenu.Visible = false;
            }

            var con = sender as Control;
            if (con.Name == "picAvatar" || con.Name == "lblName")
            {
                OnClickProfileFriend?.Invoke(post.User);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.Show("Bạn có muốn xóa bài viết này?", MessageBoxType.Question).Value == DialogResult.OK)
            {
                // Cập nhật UI: thông báo cho cha xóa item này
                OnDeletePost?.Invoke(this);
            }
        }

        #endregion
    }
}
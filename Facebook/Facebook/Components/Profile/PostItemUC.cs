using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.WrapperForm;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class PostItemUC : UserControl
    {
        public delegate void HeightChaned();
        public event HeightChaned OnHeightChaned;

        private Post post;

        public PostItemUC(Post post)
        {
            InitializeComponent();

            this.post = post;

            Load();
        }

        private int margin = 20;
        private int ch = 47;
        private bool isCreated;

        #region Methods

        new private void Load()
        {
            this.Margin = new Padding(0, 0, 0, margin);

            // Head
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, post.User);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            lblName.Text = post.User.Name;
            lblTime.Text = GetTime(post.CreatedAt);

            // Description
            int row = post.Description.Length / ch;
            var heightLbl = (row + 1) * 40 + 10;
            lblDescription.Height = heightLbl;
            pnlDescription.Height = heightLbl;

            // Comment
            LoadComment();


            LoadDetail();
            SetColor();
            UpdateHeight();
        }

        private void LoadComment()
        {
            var postCommentUC = new PostCommentUC(AutofacFactory<IPostDAO>.Get(), AutofacFactory<ICommentDAO>.Get(), post);
            postCommentUC.OnHeightChanged += PostCommentUC_OnHeightChanged;

            this.Height += postCommentUC.Height;
            pnlComment.Controls.Add(postCommentUC);
            //pnlComment.Height = postCommentUC.Height;
        }

        private void LoadDetail()
        {
            lblDescription.Text = post.Description;
            if (string.IsNullOrEmpty(post.Image))
            {
                picImage.Visible = false;
                picImage.Height = 0;
            }
            else
            {
                var image = Image.FromFile($"./../../Assets/Images/Post/{post.Image}");
                var width = image.Width;
                var height = image.Height;
                var widthPic = picImage.Width;
                var heightPic = widthPic * height / width;

                picImage.Height = heightPic;
                picImage.BackgroundImage = image;
                picImage.BackgroundImageLayout = ImageLayout.Stretch;
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

        #endregion


        #region Events

        private void PostCommentUC_OnHeightChanged()
        {
            UpdateHeight();
            OnHeightChaned?.Invoke();
        }


        #endregion

        /// <summary>
        /// Update lại bài viết
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //var isUpdate = false;
            //try
            //{
            //    var fWapUpdatePost = new fWrapUpdatePost(AutofacFactory<IPostStatusDAO>.Get(), AutofacFactory<IPostDAO>.Get());
            //    //fWapUpdatePost.OnCreatedPost += (s) => isUpdate = true;
            //    var fParent = new fParent(fWapUpdatePost); // Show  thông qua parent, sẽ có hiệu ứng ảo
            //    fParent.Show();
            //}
            //catch (Exception)
            //{

            //}

            //if (isUpdate)
            //{
            //    // Cập nhật lại Post hiện tại
            //    LoadDetail();
            //    UpdateHeight();
            //    OnHeightChaned?.Invoke();
            //}
        }
    }
}
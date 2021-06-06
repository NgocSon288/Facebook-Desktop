using Facebook.Common;
using Facebook.Configure.Autofac;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class PostListProfileUC : UserControl
    {
        public delegate void HeightChanged();
        public event HeightChanged OnHeightChanged;

        private readonly IPostDAO _postDAO;

        private List<Post> posts;

        public PostListProfileUC(IPostDAO postDAO)
        {
            InitializeComponent();

            this._postDAO = postDAO;

            Load();
        }

        private Image image1;
        private Image image2;
        private int margin = 15;

        #region Methods

        new private void Load()
        {
            posts = _postDAO.GetByUserID(Constants.UserSession.ID);

            LoadPostItems();

            LoadUI();
            SetColor();
        }

        private void LoadPostItems()
        {
            flpContent.Controls.Clear();

            foreach (var item in posts)
            {
                var postItem = new PostItemUC(item);
                postItem.Margin = new Padding(0, 0, 0, 25);
                postItem.OnHeightChaned += PostItem_OnHeightChaned;

                flpContent.Controls.Add(postItem);
            }

            UpdateHeight();
        }

        private void LoadUI()
        {
            image1 = Image.FromFile("./../../Assets/Images/Profile/think-1.png");
            image2 = Image.FromFile("./../../Assets/Images/Profile/think-2.png");

            // Load image think
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            picThink.BackgroundImage = image1;
            picThink.BackgroundImageLayout = ImageLayout.Stretch;

            pnlContent.Location = new Point(margin, margin);

        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            pnlContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            flpContent.BackColor = Constants.MAIN_BACK_COLOR;

            pnlSeparator.BackColor = Constants.MAIN_BACK_COLOR;
            pnlSeparator.Height = 25;
        }

        private void UpdateHeight()
        {
            var mar = margin * 2;
            var heightHead = pnlThink.Height;
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

        private void picThink_Click(object sender, EventArgs e)
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
                posts = _postDAO.GetAll();

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

using Facebook.Common;
using Facebook.Helper;
using Facebook.Model.Models;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class UpdatePostUC : UserControl
    {
        public delegate void HeightChanged();
        public delegate void ChangeToPostStatus();
        public delegate void ClickUpdateButton(bool isImageChanged);
        public event HeightChanged OnHeightChangeOnd;
        public event ChangeToPostStatus OnChangeToPostStatus;
        public event ClickUpdateButton OnClickUpdateButton;

        private bool changedImage;
        private bool haveImage;
        private PostStatus postStatus;
        private Post post;

        public UpdatePostUC(PostStatus postStatus, Post post)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            SetStyle(ControlStyles.Selectable, false);

            this.postStatus = postStatus;
            this.post = post;

            Load();
        }

        string TEXT_COMPARE = "Bạn đang nghĩ gì?";
        int margin = 15;

        #region Methods

        new private void Load()
        {
            changedImage = false;

            SetUpUI();
            LoadDetail();

            //UIHelper.SetBlur(this, (o, s) => this.ActiveControl = (Control)o, true);
        }

        private void LoadDetail()
        {
            txtDescription.Text = post.Description;

            if (!string.IsNullOrEmpty(post.Image))
            {
                var image = ImageHelper.FromFile($"./../../Assets/Images/Post/{post.Image}");
                var width = image.Width;
                var height = image.Height;
                var widthPic = picImage.Width;
                var heightPic = widthPic * height / width;

                picImage.Height = heightPic;
                // Update UI avatar
                picImage.BackgroundImage = image;
                picImage.Tag = post.Image;
                pnlSeparator.Visible = true;
                picImage.Visible = true;

                haveImage = true;
            }
            else
            {
                haveImage = false;
                pnlSeparator.Visible = false;
                picImage.Visible = false;
            }

            UpdateHeight();
        }

        private void SetUpUI()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlContent.Width = this.Width - margin * 2;
            pnlContent.Height = this.Height - margin * 2;
            pnlContent.Location = new Point(margin, margin);

            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, Constants.UserSession);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblName.Text = Constants.UserSession.Name;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;

            // Button Add image
            btnAddImage.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnAddImage.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;


            // ComboBox
            btnLeft.BackColor = Constants.BACKGROUND_COMBOBOX_COLOR;
            btnLeft.IconColor = Constants.MAIN_FORE_COLOR;
            btnLeft.FlatAppearance.MouseOverBackColor = Constants.BACKGROUND_COMBOBOX_COLOR;
            btnLeft.FlatAppearance.MouseDownBackColor = Constants.BACKGROUND_COMBOBOX_COLOR;
            btnRight.BackColor = Constants.BACKGROUND_COMBOBOX_COLOR;
            btnRight.IconColor = Constants.MAIN_FORE_COLOR;
            btnRight.FlatAppearance.MouseOverBackColor = Constants.BACKGROUND_COMBOBOX_COLOR;
            btnRight.FlatAppearance.MouseDownBackColor = Constants.BACKGROUND_COMBOBOX_COLOR;
            pnlPostStatus.BackColor = Constants.BACKGROUND_COMBOBOX_COLOR;
            lblPostStatus.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            UpdatePostStatus();

            //Description
            txtDescription.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            txtDescription.ForeColor = Constants.MAIN_FORE_PARAGRAPH_NOT_ACTIVE_COLOR;

            // Image and separator
            pnlSeparator.BackColor = Constants.MAIN_BACK_CONTENT_COLOR; ;
            pnlSeparator.Visible = false;


            var btn = new Button()
            {
                Width = 50,
                Height = 50,
                Text = "X",
                ForeColor = Color.Red,
                BackColor = Color.Transparent
            };
            btn.Click += Btn_Click;
            picImage.Controls.Add(btn);

            // button create
            btnCreate.BackColor = Color.Transparent;

            UpdateHeight();

            // Add sự kiện remove focus textbox
            //UIHelper.SetBlur(this, (o, s) => this.ActiveControl = (Control)o, true);
        }

        private void UpdateHeight()
        {
            var mar2 = 10;
            var mar = margin * 2;
            var heightHead = pnlHead.Height;
            var heightTxt = txtDescription.Height;
            var heightBtn = btnCreate.Height;
            var heightSepa = pnlSeparator.Height;
            var heightPic = picImage.Height;

            if (haveImage)
            {
                this.Height = mar + heightHead + heightTxt + heightSepa + heightPic + heightBtn + 2 * mar2;
                pnlContent.Height = this.Height - mar + mar2;

                // update Button location
                btnCreate.Top = pnlContent.Height - btnCreate.Height - 2 * mar2;
            }
            else
            {
                this.Height = mar + heightHead + heightTxt + heightBtn + 2 * mar2;
                pnlContent.Height = this.Height - mar + mar2;

                // update Button location
                btnCreate.Top = pnlContent.Height - btnCreate.Height - 2 * mar2;
            }
        }

        public void UpdatePostStatus(PostStatus post = null)
        {
            if (post != null)
            {
                this.postStatus = post;
            }

            lblPostStatus.Text = postStatus.DisplayName;


            pnlPostStatus.Width = btnLeft.Width + lblPostStatus.Width + btnRight.Width;
            btnLeft.Left = 0;
            btnLeft.IconChar = GetIcon(postStatus);
            lblPostStatus.Left = btnLeft.Width;
            lblPostStatus.Top = 9;
            btnRight.Left = btnLeft.Width + lblPostStatus.Width;
            btnRight.Top = -4;
        }

        private IconChar GetIcon(PostStatus postStatus)
        {
            switch (postStatus.Name)
            {
                case "public":
                    return IconChar.UserFriends;
                case "friend":
                    return IconChar.User;
                default:
                    return IconChar.Lock;
            }
        }

        public void UpdateAvatar()
        {
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, Constants.UserSession);
        }

        #endregion

        #region Events

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            var txt = txtDescription.Text;
            txtDescription.ForeColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;

            if (string.Equals(txt, TEXT_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txtDescription.Text = "";
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            var txt = txtDescription.Text;
            txtDescription.ForeColor = Constants.MAIN_FORE_PARAGRAPH_NOT_ACTIVE_COLOR;

            if (string.IsNullOrEmpty(txt.Trim()))
            {
                txtDescription.Text = TEXT_COMPARE;
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn một hình ảnh";
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.jfif)|*.jpg; *.jpeg; *.gif; *.bmp; *.jfif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;

                if (File.Exists(fileName))
                {
                    var image = ImageHelper.FromFile(fileName);
                    var width = image.Width;
                    var height = image.Height;
                    var widthPic = picImage.Width;
                    var heightPic = widthPic * height / width;

                    picImage.Height = heightPic;
                    // Update UI avatar
                    picImage.BackgroundImage = image;
                    picImage.Tag = fileName;

                    changedImage = true;
                }

                haveImage = true;
                pnlSeparator.Visible = true;
                picImage.Visible = true;

                UpdateHeight();
                OnHeightChangeOnd?.Invoke();
            }

        }

        /// <summary>
        /// Click vào chuyển box trang,
        /// Thông báo cho cha là đổi trang, enable lên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            OnChangeToPostStatus?.Invoke();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            changedImage = true;
            haveImage = false;
            pnlSeparator.Visible = false;
            picImage.Visible = false;

            // get image đưa vào picImage
            picImage.BackgroundImage = null;
            picImage.Tag = null;

            UpdateHeight();
            OnHeightChangeOnd?.Invoke();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            var txt = txtDescription.Text;

            btnCreate.Enabled = !string.IsNullOrEmpty(txt.Trim()) && txt != "Bạn đang nghĩ gì?";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var description = txtDescription.Text;
            var image = picImage.Tag?.ToString();
            var postStatus = this.postStatus;

            post.Description = description;
            post.Image = image;
            post.PostStatus = postStatus;
            post.PostStatusID = postStatus.ID;

            // Thông báo cho cha WrapCreatePost tạo
            OnClickUpdateButton?.Invoke(changedImage);
        }

        #endregion

    }
}

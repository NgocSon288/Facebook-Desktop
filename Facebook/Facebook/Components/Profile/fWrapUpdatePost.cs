using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Model.Models;
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
    public partial class fWrapUpdatePost : Form
    {
        public delegate void UpdatedPost();
        public event UpdatedPost OnUpdatedPost;

        private readonly IPostStatusDAO _postStatusDAO;
        private readonly IPostDAO _postDAO;

        private UpdatePostUC createPostUC;
        private PostStatusUC postStatusUC;

        private Post post;
        private PostStatus postStatus;

        private List<PostStatus> postStatuses;

        public fWrapUpdatePost(IPostStatusDAO postStatusDAO, IPostDAO postDAO, Post post)
        {
            InitializeComponent();

            this._postStatusDAO = postStatusDAO;
            this._postDAO = postDAO;
            this.post = post;

            Load();
        }

        int margin = 1;

        #region Methods

        new private void Load()
        {
            SetUpUI();
            postStatuses = _postStatusDAO.GetAll();
            postStatus = post.PostStatus;

            // Add CreatePostUC vào panelContent
            createPostUC = new UpdatePostUC(postStatus, post);
            createPostUC.Margin = new Padding(0, 0, 0, 0);
            createPostUC.Visible = true;
            createPostUC.Name = "create";
            createPostUC.OnHeightChangeOnd += CreatePostUC_OnHeightChangeOnd;
            createPostUC.OnChangeToPostStatus += CreatePostUC_OnChangeToPostStatus;
            createPostUC.OnClickUpdateButton += CreatePostUC_OnClickCreateButton;

            // Add PostStatusUC vào panelContent
            postStatusUC = new PostStatusUC(postStatuses, post.PostStatusID);
            postStatusUC.Margin = new Padding(0, 0, 0, 0);
            postStatusUC.Visible = false;   // cho ẩn đi
            postStatusUC.Name = "post";
            postStatusUC.OnChangeToCreatePost += PostStatusUC_OnChangeToCreatePost;



            createPostUC.Left = panelContent.Width / 2 - createPostUC.Width / 2;
            postStatusUC.Left = panelContent.Width / 2 - postStatusUC.Width / 2;

            panelContent.Controls.Add(createPostUC);
            panelContent.Controls.Add(postStatusUC);

            UpdateHeight("create");
        }

        private void SetUpUI()
        {

            this.BackColor = Constants.BORDER_BOX_COLOR;

            pnlContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlContent.Width = this.Width - margin * 2;
            pnlContent.Top = margin;
            pnlContent.Left = margin;
            pnlContent.Height = this.Height - margin * 2;
            pnlSeparator.BackColor = Constants.BORDER_BOX_COLOR;
            pnlSeparator.Height = margin * 2;

            // Header
            lblTitle.Left = pnlHeader.Width / 2 - lblTitle.Width / 2;
            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;

            btnClose.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;


            // PanelContent: chứa  các component
            panelContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void UpdateHeight(string name)
        {
            var heightHead = pnlHeader.Height;
            var heightSepa = pnlSeparator.Height;
            var heightContent = 0;
            foreach (UserControl item in panelContent.Controls)
            {
                if (item.Name == name)
                {
                    heightContent = item.Height;
                    break;
                }
            }

            // cập nhật 
            //this.Height = height;
            panelContent.Height = heightContent;
            pnlContent.Height = heightHead + heightSepa + heightContent;
            this.Height = pnlContent.Height + margin * 2;
            pnlContent.Location = new Point(margin, margin);

            // Set lại position
            var top = Constants.AccountForm.Top;
            var heightParent = Constants.MainForm.Height;

            // Cập  nhật vị trí form
            this.Top = heightParent / 2 - this.Height / 2 + top;
        }

        #endregion


        #region Events

        private void btnClose_Click(object sender, EventArgs e)
        {
            //OnUpdatedPost?.Invoke();
            this.Close();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void CreatePostUC_OnHeightChangeOnd()
        {
            UpdateHeight("create");
        }

        /// <summary>
        /// Chuyển sang form PostStatus
        /// </summary>
        private void CreatePostUC_OnChangeToPostStatus()
        {
            lblTitle.Text = "Chọn đối tượng";
            lblTitle.Left = pnlHeader.Width / 2 - lblTitle.Width / 2;

            // Cho ẩn đi các Control trong panelContent trừ PostStatusUC
            createPostUC.Visible = false;
            postStatusUC.Visible = true;

            UpdateHeight("post");
        }

        /// <summary>
        /// Chuyền sang form CreatePost
        /// </summary>
        /// <param name="postStatus"></param>
        private void PostStatusUC_OnChangeToCreatePost(PostStatus postStatus)
        {
            this.postStatus = postStatus;

            lblTitle.Text = "Cập nhật bài viết";
            lblTitle.Left = pnlHeader.Width / 2 - lblTitle.Width / 2;

            post.PostStatusID = postStatus.ID;

            // Cho ẩn đi các Control trong panelContent trừ PostStatusUC
            createPostUC.Visible = true;
            postStatusUC.Visible = false;

            createPostUC.UpdatePostStatus(postStatus);

            UpdateHeight("create");
        }

        /// <summary>
        /// Cập nhật post dụa vào isChangeImage
        /// </summary>
        private void CreatePostUC_OnClickCreateButton(bool isImageChanged)
        {
            var imagePath = post.Image;
            // Lưu hình ảnh của bài viết nếu có
            if (isImageChanged)
            {
                if (!string.IsNullOrEmpty(post.Image))
                {
                    var strBonus = new Random().Next(0, 999999999).ToString().PadLeft(9, '9');
                    var fileName = strBonus + "-" + Path.GetFileName(post.Image); // Cộng thêm tiền tố cho nó khó bị  trùng
                    var pathNew = Path.Combine("./../../Assets/Images/Post/", fileName);

                    File.Copy(post.Image, pathNew);  // save file 
                    post.Image = fileName;
                }
            }

            OnUpdatedPost?.Invoke();

            // Save db
            if (_postDAO.SaveChanges())
            {
                MyMessageBox.Show("Cập nhật bài viết thành công!", MessageBoxType.Success);
            }
            else
            {
                MyMessageBox.Show(" Cập nhật bài viết không thành công!", MessageBoxType.Error);
            }

            this.Close();
        }

        #endregion
    }
}

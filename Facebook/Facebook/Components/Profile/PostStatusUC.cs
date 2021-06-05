using Facebook.Common;
using Facebook.DAO;
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
    public partial class PostStatusUC : UserControl
    {
        public delegate void ChangeToCreatePost(PostStatus postStatus);
        public event ChangeToCreatePost OnChangeToCreatePost;

        private List<PostStatus> postStatuses;

        private int postStatusIDActive;

        // Cần nhận vào postStatus
        public PostStatusUC(List<PostStatus> postStatuses, int postStatusIDActive = 1)
        {
            InitializeComponent();

            this.postStatuses = postStatuses;
            this.postStatusIDActive = postStatusIDActive;

            Load();
        }

        int margin = 1;

        #region Methods

        new private void Load()
        {
            foreach (var item in postStatuses)
            {
                PostStatusItemUC postItem = null;
                if (item.ID == postStatusIDActive)
                {
                    postItem = new PostStatusItemUC(item, true);
                }
                else
                {
                    postItem = new PostStatusItemUC(item);
                }

                postItem.Margin = new Padding(0, 0, 0, 20);
                postItem.Padding = new Padding(0, 0, 0, 15);
                postItem.OnClickItem += PostItem_OnClickItem;

                flpItems.Controls.Add(postItem);
            }

            SetUpUI();
            SetColor();
            UpdateHeight();
        }

        private void UpdateHeight()
        {
            var height = 25;
            var mar = 10;
            foreach (Control item in flpItems.Controls)
            {
                height += item.Height;
            }

            flpItems.Height = height + mar;
            this.Height = height + pnlHead.Height + mar;
        }

        private void SetUpUI()
        {
            pnlSeparator.Height = margin;
            pnlSeparator.BackColor = Constants.BORDER_BOX_COLOR;
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            lblParagraph.ForeColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;
        }

        #endregion

        #region Events

        /// <summary>
        /// Lấy được postStatus và thông báo cho cha chuyển sang   CreatePost
        /// </summary>
        /// <param name="postStatus"></param>
        private void PostItem_OnClickItem(PostStatus postStatus)
        {
            // Duyệt flpItems. nếu có postStatusID khac thì cập nhật lại thành không  active, bg
            foreach (PostStatusItemUC item in flpItems.Controls)
            {
                if (item.postStatus.ID != postStatus.ID)
                {
                    item.RestColor();
                }
            }

            OnChangeToCreatePost?.Invoke(postStatus);
        }

        #endregion
    }
}

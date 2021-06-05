using Facebook.Common;
using Facebook.Model.Models;
using FontAwesome.Sharp;
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
    public partial class PostStatusItemUC : UserControl
    {
        public delegate void ClickItem(PostStatus postStatus);
        public event ClickItem OnClickItem;

        public PostStatus postStatus;
        private bool isActive;

        public PostStatusItemUC(PostStatus postStatus, bool isActive = false)
        {
            InitializeComponent();

            this.postStatus = postStatus;
            this.isActive = isActive;

            Load();
        }

        int margin = 10;

        #region Methods

        new private void Load()
        {
            lblTitle.Text = postStatus.DisplayName;
            lblParagraph.Text = postStatus.Description;

            picBg.BackgroundImage = Image.FromFile("./../../Assets/Images/Profile/circle-bg.png");
            picBg.BackgroundImageLayout = ImageLayout.Stretch;

            picIcon.IconChar = GetIcon();
            picIcon.BackColor = Color.FromArgb(60, 70, 80);

            this.Height = margin * 2 + picBg.Height;
            picBg.Top = margin;

            this.BackColor = isActive ? Constants.BACKGROUND_POSTSTATUS_ACTIVE_COLOR : Constants.MAIN_BACK_CONTENT_COLOR;
            rdbStatus.Checked = isActive;
            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            lblParagraph.ForeColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;
        }

        private IconChar GetIcon()
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

        public void RestColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            rdbStatus.Checked = false;
            isActive = false;
        }

        private void PostStatusItemUC_MouseEnter(object sender, EventArgs e)
        {
            if (!isActive)
            {
                this.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
            }
        }

        private void PostStatusItemUC_MouseLeave(object sender, EventArgs e)
        {
            if (!isActive)
            {
                this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            }
        }

        /// <summary>
        /// Thông báo cho cha biết là đã  click vào để chuyển về CreatePostUC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBg_Click(object sender, EventArgs e)
        {
            isActive = true;    // cần thông báo cho item kia thành  không active
            this.BackColor = Constants.BACKGROUND_POSTSTATUS_ACTIVE_COLOR;
            rdbStatus.Checked = true;

            OnClickItem?.Invoke(postStatus);
        }

        #endregion
    }
}

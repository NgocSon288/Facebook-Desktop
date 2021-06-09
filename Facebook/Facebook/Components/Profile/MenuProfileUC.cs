using Facebook.Common;
using Facebook.Helper;
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
    public partial class MenuProfileUC : UserControl
    {
        public delegate void ClickButtonIntro();
        public delegate void ClickButtonFriends();
        public delegate void ClickButtonImages();
        public event ClickButtonIntro OnClickButtonIntro;
        public event ClickButtonFriends OnClickButtonFriends;
        public event ClickButtonImages OnClickButtonImages;

        public static BUTTON BUTTON_CURRENT = BUTTON.INTRO;

        public enum BUTTON
        {
            INTRO,
            FRIENDS,
            IMAGES
        }

        public MenuProfileUC()
        {
            InitializeComponent();

            Load();
        }

        int margin = 20;
        int marginContent = 10;
        int widthButton = 300;
        int marginButton = 100;

        #region Methods

        new private void Load()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlWrap.Width = this.Width - margin * 2 - 15;
            pnlWrap.Height = this.Height - margin * 2;
            pnlWrap.Location = new Point(margin, margin);

            SetUI();
            ResetColor(BUTTON.INTRO);

            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void SetUI()
        {
            // Giới thiệu 
            SetButtonVirtual(pnlWrapIntro, lblIntro, pnlBorderIntro);
            SetButtonVirtual(pnlWrapFriends, lblFriends, pnlBorderFriends);
            SetButtonVirtual(pnlWrapImages, lblImages, pnlBorderImages);

            // Hiện  tại  3
            pnlWrapFriends.Left = pnlWrap.Width / 2 - pnlWrapFriends.Width / 2;
            pnlWrapIntro.Left = pnlWrapFriends.Left - pnlWrapIntro.Width - marginButton;
            pnlWrapImages.Left = pnlWrapFriends.Right + marginButton;

            pnlBorderIntro.Left = pnlWrapIntro.Left;
            pnlBorderFriends.Left = pnlWrapFriends.Left;
            pnlBorderImages.Left = pnlWrapImages.Left;
        }

        private void SetButtonVirtual(Panel pnlWrap, Label lbl, Panel pnlBorder)
        {
            pnlWrap.Width = widthButton;
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlWrap.Height = pnlWrap.Height - 2 * marginContent;
            pnlWrap.Top = marginContent;
            lbl.Left = pnlWrap.Width / 2 - lbl.Width / 2;
            lbl.Top = pnlWrap.Height / 2 - lbl.Height / 2;
            lbl.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lbl.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlBorder.Width = pnlWrap.Width;
            pnlBorder.Height = marginContent;
            pnlBorder.Top = pnlWrap.Bottom;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
            pnlBorder.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void SetColorEnter(Panel pnlWrap, Panel pnlBorder, Label lbl, bool isActive)
        {
            pnlBorder.BackColor = isActive ? Constants.MAIN_FORE_LINK_COLOR : Constants.MAIN_BACK_CONTENT_COLOR;
            lbl.ForeColor = isActive ? Constants.MAIN_FORE_LINK_COLOR : Constants.MAIN_FORE_SMALLTEXT_COLOR;
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lbl.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void ResetColor(BUTTON buttonCur)
        {
            BUTTON_CURRENT = buttonCur;
            SetColorEnter(pnlWrapIntro, pnlBorderIntro, lblIntro, false);
            SetColorEnter(pnlWrapFriends, pnlBorderFriends, lblFriends, false);
            SetColorEnter(pnlWrapImages, pnlBorderImages, lblImages, false);

            switch (MenuProfileUC.BUTTON_CURRENT)
            {
                case BUTTON.INTRO:
                    SetColorEnter(pnlWrapIntro, pnlBorderIntro, lblIntro, true);
                    break;
                case BUTTON.FRIENDS:
                    SetColorEnter(pnlWrapFriends, pnlBorderFriends, lblFriends, true);
                    break;
                case BUTTON.IMAGES:
                    SetColorEnter(pnlWrapImages, pnlBorderImages, lblImages, true);
                    break;
            }
        }


        #endregion

        #region Events 

        #endregion

        #region UI


        private void pnlWrapIntro_Enter(object sender, EventArgs e)
        {
            if (BUTTON_CURRENT == BUTTON.INTRO)
                return;

            pnlWrapIntro.BackColor = Constants.EXPAND_HEADER_COLOR;
            lblIntro.BackColor = Constants.EXPAND_HEADER_COLOR;
        }

        private void pnlWrapIntro_MouseLeave(object sender, EventArgs e)
        {
            if (BUTTON_CURRENT == BUTTON.INTRO)
                return;

            pnlWrapIntro.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblIntro.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        #endregion

        private void pnlWrapFriends_MouseEnter(object sender, EventArgs e)
        {
            if (BUTTON_CURRENT == BUTTON.FRIENDS)
                return;

            pnlWrapFriends.BackColor = Constants.EXPAND_HEADER_COLOR;
            lblFriends.BackColor = Constants.EXPAND_HEADER_COLOR;
        }

        private void pnlWrapFriends_MouseLeave(object sender, EventArgs e)
        {
            if (BUTTON_CURRENT == BUTTON.FRIENDS)
                return;

            pnlWrapFriends.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblFriends.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void lblImages_MouseEnter(object sender, EventArgs e)
        {
            if (BUTTON_CURRENT == BUTTON.IMAGES)
                return;

            pnlWrapImages.BackColor = Constants.EXPAND_HEADER_COLOR;
            lblImages.BackColor = Constants.EXPAND_HEADER_COLOR;
        }

        private void lblImages_MouseLeave(object sender, EventArgs e)
        {
            if (BUTTON_CURRENT == BUTTON.IMAGES)
                return;

            pnlWrapImages.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblImages.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void pnlWrapIntro_Click(object sender, EventArgs e)
        {
            ResetColor(BUTTON.INTRO);
            OnClickButtonIntro?.Invoke();
        }

        private void lblFriends_Click(object sender, EventArgs e)
        {
            ResetColor(BUTTON.FRIENDS);
            OnClickButtonFriends?.Invoke();
        }

        private void lblImages_Click(object sender, EventArgs e)
        {
            ResetColor(BUTTON.IMAGES);
            OnClickButtonImages?.Invoke();
        }
    }
}

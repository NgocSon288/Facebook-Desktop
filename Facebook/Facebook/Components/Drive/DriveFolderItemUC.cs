using Facebook.Common;
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

namespace Facebook.Components.Drive
{
    public partial class DriveFolderItemUC : UserControl
    {
        public delegate void OneClick();
        public delegate void TwoClick();
        public event OneClick OnOneClick;
        public event TwoClick OnTwoClick;

        public Folder folder;

        private string colorName;

        public static DriveFolderItemUC CurrentFolderItemUCFocus = null;

        public DriveFolderItemUC(Folder folder)
        {
            InitializeComponent();

            this.folder = folder;

            Load();
        }

        int margin = 2;

        #region Methods

        new private void Load()
        {
            colorName = folder.ColorName;

            pnlWrap.Width = this.Width - 2 * margin;
            pnlWrap.Height = this.Height - 2 * margin;
            pnlWrap.Location = new Point(margin, margin);
            pnlWrap.BackColor = Constants.FOLDER_ITEM_COLOR;

            lblName.Text = folder.Name;
            var text = lblName.Text;
            if (text.Length > 17)
            {
                text = text.Substring(0, 17) + "...";
            }
            lblName.Text = text;
            lblName.BackColor = Constants.FOLDER_ITEM_COLOR;
            lblName.ForeColor = GetColorPriority();

            picIcon.IconColor = GetColorPriority();
            picIcon.BackColor = Constants.FOLDER_ITEM_COLOR;

            this.BackColor = Constants.FOLDER_ITEM_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);

            tt.SetToolTip(lblName, folder.Name);
            tt.SetToolTip(picIcon, folder.Name);
            Cut();
        }

        private Color GetColorPriority(bool isCut = false)
        {
            if (!isCut)
            {
                if (string.IsNullOrEmpty(colorName))
                    return Constants.MAIN_FORE_COLOR;

                return ThemeColor.GetThemeByName(colorName).Color;
            }
            else
            {
                if (string.IsNullOrEmpty(colorName))
                    return Constants.FOLDER_ITEM_CUTED_FG_COLOR;

                var i = 70;
                var co = ThemeColor.GetThemeByName(colorName).Color;
                var r = co.R - i >= 0 ? co.R : 0;
                var g = co.G - i >= 0 ? co.G : 0;
                var b = co.B - i >= 0 ? co.B : 0;

                return Color.FromArgb(r, g, b);
            }
        }

        public void ChangedColorName(string coName)
        {
            colorName = coName;

            // nếu được cut
            if (Constants.Clipboard != null && Constants.Clipboard.IsFolder && Constants.Clipboard.Folder.ID == folder.ID)
            {
                picIcon.IconColor = GetColorPriority(true);
                lblName.ForeColor = GetColorPriority(true);
            }
            else
            {
                picIcon.IconColor = GetColorPriority();
                lblName.ForeColor = GetColorPriority();
            }

        }

        public void Rename(string name)
        {
            lblName.Text = name;
            var text = name;
            if (text.Length > 17)
            {
                text = text.Substring(0, 17) + "...";
            }
            lblName.Text = text;
            lblName.BackColor = Constants.FOLDER_ITEM_ENTER_COLOR;
            lblName.ForeColor = GetColorPriority();
            tt.SetToolTip(lblName, name);

            Cut();
        }

        private void SetColor(Color color, bool isEnter = false, bool isPriority = false)
        {
            if (!CheckCut() || isPriority)
            {
                pnlWrap.BackColor = color;
                lblName.BackColor = color;
                lblName.ForeColor = GetColorPriority();
                picIcon.BackColor = color;
                picIcon.IconColor = GetColorPriority();

                this.BackColor = isEnter ? Constants.FOLDER_BORDER_ITEM_ENTER_COLOR : color;
                UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
                UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
            }
        }

        public void ResetColor()
        {
            CurrentFolderItemUCFocus.SetColor(Constants.FOLDER_ITEM_COLOR);
            CurrentFolderItemUCFocus = null;
        }

        private bool CheckCut()
        {
            return Constants.Clipboard != null && Constants.Clipboard.IsFolder && Constants.Clipboard.Folder.ID == folder.ID;
        }

        /// <summary>
        /// Khi gọi cut thì cập nhật màu sắc
        /// </summary>
        public void Cut()
        {
            if (CheckCut())
            {
                SetColor(Constants.FOLDER_ITEM_CUTED_BG__COLOR, true, true);
                lblName.ForeColor = GetColorPriority(true);
                picIcon.IconColor = GetColorPriority(true);

                Constants.CurrentCut = this;
            }
        }

        public void UnCut()
        {
            SetColor(Constants.FOLDER_ITEM_COLOR, false, true);
            lblName.ForeColor = GetColorPriority();
            picIcon.IconColor = GetColorPriority();
        }

        public void SetColorAfterUnCut()
        {
            SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);
        }

        #endregion

        private void lblName_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentFolderItemUCFocus == this || CheckCut())
                return;

            SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);
        }

        private void DriveFileItemUC_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentFolderItemUCFocus == this || CheckCut())
                return;

            SetColor(Constants.FOLDER_ITEM_COLOR);
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            CurrentFolderItemUCFocus?.SetColor(Constants.FOLDER_ITEM_COLOR);
            CurrentFolderItemUCFocus = this;
            CurrentFolderItemUCFocus.SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);

            OnOneClick?.Invoke();
        }

        private void picIcon_DoubleClick(object sender, EventArgs e)
        {
            OnTwoClick?.Invoke();
        }


        /// <summary>
        ///  Kéo file, folder vào folder con
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlWrap_DragEnter(object sender, DragEventArgs e)
        {
            this.BackColor = Constants.FOLDER_BORDER_DRAG_ENTER_COLOR;
            pnlWrap.BackColor = Constants.FOLDER_BACKGROUND_DRAG_ENTER_COLOR;
            picIcon.BackColor = Constants.FOLDER_BACKGROUND_DRAG_ENTER_COLOR;
            lblName.BackColor = Constants.FOLDER_BACKGROUND_DRAG_ENTER_COLOR;
        }

        private void pnlWrap_DragDrop(object sender, DragEventArgs e)
        {
            this.BackColor = Constants.FOLDER_ITEM_COLOR;
            pnlWrap.BackColor = Constants.FOLDER_ITEM_COLOR;
            picIcon.BackColor = Constants.FOLDER_ITEM_COLOR;
            lblName.BackColor = Constants.FOLDER_ITEM_COLOR;

            if (CurrentFolderItemUCFocus == this)
            {
                SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);
            }
        }

        private void pnlWrap_DragLeave(object sender, EventArgs e)
        {
            this.BackColor = Constants.FOLDER_ITEM_COLOR;
            pnlWrap.BackColor = Constants.FOLDER_ITEM_COLOR;
            picIcon.BackColor = Constants.FOLDER_ITEM_COLOR;
            lblName.BackColor = Constants.FOLDER_ITEM_COLOR;

            if (CurrentFolderItemUCFocus == this)
            {
                SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);
            }
        }
    }
}

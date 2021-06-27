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

namespace Facebook.Components.Drive
{
    public partial class DriveFileItemUC : UserControl
    {
        public delegate void OneClick();
        public event OneClick OnOneClick;

        private readonly IFileColorDAO _fileColorDAO;

        public string fileName;

        public static DriveFileItemUC CurrentFileItemUCFocus = null;

        public DriveFileItemUC(IFileColorDAO fileColorDAO, string fileName)
        {
            InitializeComponent();

            this._fileColorDAO = fileColorDAO;
            this.fileName = fileName;

            Load();
        }

        int margin = 2;

        #region Methods

        new private void Load()
        {
            pnlWrap.Width = this.Width - 2 * margin;
            pnlWrap.Height = this.Height - 2 * margin;
            pnlWrap.Location = new Point(margin, margin);
            pnlWrap.BackColor = Constants.FOLDER_ITEM_COLOR;

            lblName.Text = fileName.Substring(9);
            var text = lblName.Text.Substring(0, lblName.Text.LastIndexOf("."));
            if (text.Length > 17)
            {
                text = text.Substring(0, 17) + "...";
            }
            lblName.Text = text;
            lblName.BackColor = Constants.FOLDER_ITEM_COLOR;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;

            picIcon.IconChar = ExtensionIcon.GetIconByPath(fileName);
            picIcon.IconColor = GetColorByExtension();
            picIcon.BackColor = Constants.FOLDER_ITEM_COLOR;

            this.BackColor = Constants.FOLDER_ITEM_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);

            tt.SetToolTip(lblName, fileName.Substring(9));
            tt.SetToolTip(picIcon, fileName.Substring(9));
            Cut();
        }

        public void RenameFile()
        {
            lblName.Text = fileName.Substring(9);
            var text = lblName.Text.Substring(0, lblName.Text.LastIndexOf("."));
            if (text.Length > 17)
            {
                text = text.Substring(0, 17) + "...";
            }
            lblName.Text = text;
            lblName.BackColor = Constants.FOLDER_ITEM_ENTER_COLOR;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;

            tt.SetToolTip(lblName, fileName.Substring(9));

            if (Constants.Clipboard != null)
            {
                Constants.Clipboard.FileName = fileName;
            }

            Cut();
        }

        private void SetColor(Color color, bool isEnter = false, bool isPriority = false)
        {
            if (!CheckCut() || isPriority)
            {
                pnlWrap.BackColor = color;
                lblName.BackColor = color;
                lblName.ForeColor = Constants.MAIN_FORE_COLOR;
                picIcon.BackColor = color;
                picIcon.IconColor = GetColorByExtension();

                this.BackColor = isEnter ? Constants.FOLDER_BORDER_ITEM_ENTER_COLOR : color;
                UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
                UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
            }
        }

        public void ResetColor()
        {
            CurrentFileItemUCFocus.SetColor(Constants.FOLDER_ITEM_COLOR);
            CurrentFileItemUCFocus = null;
        }

        private Color GetColorByExtension(bool isCut = false)
        {
            var ext = fileName.Substring(fileName.LastIndexOf(".") + 1);
            var fileColor = _fileColorDAO.GetByExtension(ext);

            if (!isCut)
            {
                if (fileColor == null || string.IsNullOrEmpty(fileColor.ColorName))
                    return Constants.MAIN_FORE_COLOR;

                return ThemeColor.GetThemeByName(fileColor.ColorName).Color;
            }
            else
            {
                if (fileColor == null || string.IsNullOrEmpty(fileColor.ColorName))
                    return Constants.FOLDER_ITEM_CUTED_FG_COLOR;

                var i = 70;
                var co = ThemeColor.GetThemeByName(fileColor.ColorName).Color;
                var r = co.R - i >= 0 ? co.R : 0;
                var g = co.G - i >= 0 ? co.G : 0;
                var b = co.B - i >= 0 ? co.B : 0;

                return Color.FromArgb(r, g, b);
            }
        }

        private bool CheckCut()
        {
            return Constants.Clipboard != null && !Constants.Clipboard.IsFolder && string.Equals(Constants.Clipboard.FileName, fileName, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Khi gọi cut thì cập nhật màu sắc
        /// </summary>
        public void Cut()
        {
            if (CheckCut())
            {
                SetColor(Constants.FOLDER_ITEM_CUTED_BG__COLOR, true, true);
                lblName.ForeColor = Constants.FOLDER_ITEM_CUTED_FG_COLOR;
                picIcon.IconColor = GetColorByExtension(true);

                Constants.CurrentCut = this;
            }
        }

        public void UnCut()
        {
            SetColor(Constants.FOLDER_ITEM_COLOR, false, true);
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            picIcon.IconColor = GetColorByExtension();
        }

        public void SetColorAfterChangeColor()
        {
            picIcon.IconColor = GetColorByExtension(CheckCut());
        }

        public void SetColorAfterUnCut()
        {
            SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);
        }

        #endregion

        private void lblName_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentFileItemUCFocus == this || CheckCut())
                return;

            SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);
        }

        private void DriveFileItemUC_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentFileItemUCFocus == this || CheckCut())
                return;

            SetColor(Constants.FOLDER_ITEM_COLOR);
        }

        private void pnlWrap_Click(object sender, EventArgs e)
        {
            CurrentFileItemUCFocus?.SetColor(Constants.FOLDER_ITEM_COLOR);
            CurrentFileItemUCFocus = this;
            CurrentFileItemUCFocus.SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);

            OnOneClick?.Invoke();
        }
    }
}

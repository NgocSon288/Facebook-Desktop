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

namespace Facebook.Components.Drive.Files.ChangeColor
{
    public partial class FileItemUC : UserControl
    {
        public delegate void ClickFileItem();
        public event ClickFileItem OnClickFileItem;

        public FileColor fileColor;

        public static FileItemUC CurrentFileItem;

        public FileItemUC(FileColor fileColor)
        {
            InitializeComponent();

            this.fileColor = fileColor;

            Load();
        }

        #region Methods

        new private void Load()
        {
            lblName.Text = $"File {fileColor.ExtensionName}";
            lblName.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            pnlWrap.Left = this.Width / 2 - pnlWrap.Width / 2;
            pnlWrap.Width = this.Width - 5;
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            if (string.IsNullOrEmpty(fileColor.ColorName))
            {
                picColor.BackColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            }
            else
            {
                var color = ThemeColor.GetThemeByName(fileColor.ColorName).Color;
                picColor.BackColor = color;
            }


            UIHelper.BorderRadius(picColor, picColor.Width);
        }

        public void ReSetColor()
        {
            if (string.IsNullOrEmpty(fileColor.ColorName))
            {
                picColor.BackColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            }
            else
            {
                var color = ThemeColor.GetThemeByName(fileColor.ColorName).Color;
                picColor.BackColor = color;
            }
        }


        #endregion 

        private void pnlWrap_Click(object sender, EventArgs e)
        {
            CurrentFileItem = this;

            OnClickFileItem?.Invoke();
        }

        private void picColor_MouseEnter(object sender, EventArgs e)
        {
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void pnlWrap_MouseLeave(object sender, EventArgs e)
        {
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            UIHelper.BorderRadius(pnlWrap, 0);
        }
    }
}

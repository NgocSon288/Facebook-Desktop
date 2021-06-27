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

namespace Facebook.Components.Drive.Files.ChangeColor
{
    public partial class ColorListUC : UserControl
    {
        public delegate void ChangedTheme();
        public delegate void ClickBack();
        public ChangedTheme OnChangedTheme;
        public ClickBack OnClickBack;

        private readonly IFileColorDAO _fileColorDAO;

        public ColorListUC(IFileColorDAO fileColorDAO)
        {
            InitializeComponent();

            this._fileColorDAO = fileColorDAO;

            Load();
        }

        #region Methods

        new private void Load()
        {
            foreach (var item in ThemeColor.Themes)
            {
                var itemUC = new ColorItemUC(item, false);
                itemUC.OnChangedTheme += () =>
                {
                    // cập nhật lại tên file
                    FileItemUC.CurrentFileItem.fileColor.ColorName = item.Name;
                    _fileColorDAO.SaveChanges();

                    FileItemUC.CurrentFileItem.ReSetColor();

                    OnChangedTheme?.Invoke();
                };

                flpContent.Controls.Add(itemUC);
            }

            btnDefault.BackColor = Constants.FOLDER_ITEM_COLOR;
            btnDefault.ForeColor = Constants.MAIN_FORE_COLOR;
            btnDefault.FlatStyle = FlatStyle.Flat;
            btnDefault.FlatAppearance.BorderSize = 0;
            UIHelper.BorderRadius(btnDefault, Constants.BORDER_RADIUS);
        }

        public void SetActive(FileColor fileColor)
        {
            if (string.IsNullOrEmpty(fileColor.ColorName))
            {
                (flpContent.Controls[0] as ColorItemUC).SetActive();
            }
            else
            {
                foreach (ColorItemUC item in flpContent.Controls)
                {
                    if (item.theme.Name == fileColor.ColorName)
                    {
                        item.SetActive();
                        return;
                    }
                }
            }
        }

        #endregion

        private void btnDefault_Click(object sender, EventArgs e)
        {
            // cập nhật lại tên file
            FileItemUC.CurrentFileItem.fileColor.ColorName = null;
            _fileColorDAO.SaveChanges();

            FileItemUC.CurrentFileItem.ReSetColor();

            OnChangedTheme?.Invoke();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            OnClickBack.Invoke();
        }
    }
}

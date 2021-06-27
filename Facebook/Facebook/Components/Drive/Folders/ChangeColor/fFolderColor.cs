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

namespace Facebook.Components.Drive.Folders.ChangeColor
{
    public partial class fFolderColor : Form
    {
        public delegate void UpdateThemeColor(string nameColor);
        public delegate void ResetColor();
        public event UpdateThemeColor OnUpdateThemeColor;
        public event ResetColor OnResetColor;

        private string name;

        public fFolderColor(string name)
        {
            InitializeComponent();

            this.name = name;

            Load();
        }

        #region Methods

        new private void Load()
        {
            this.name = ThemeColor.GetThemeByName(name).Name;
            FolderColorItemUC itemUC;

            foreach (var item in ThemeColor.Themes)
            {
                itemUC = new FolderColorItemUC(item, item.Name == name);
                itemUC.OnChangedTheme += () =>
                {
                    name = item.Name;
                };

                flpContent.Controls.Add(itemUC);
            }
            pnlHead.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            label1.Top = pnlHead.Height / 2 - label1.Height / 2;
            label1.Left = pnlHead.Width / 2 - label1.Width / 2;
            label1.ForeColor = Constants.MAIN_FORE_COLOR;

            btnReset.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            btnReset.FlatAppearance.BorderColor = Constants.MAIN_FORE_LINK2_COLOR;
            btnReset.FlatAppearance.BorderSize = 1;

            btnSave.BackColor = Constants.MAIN_FORE_LINK2_COLOR;
            btnSave.ForeColor = Constants.MAIN_FORE_COLOR;

            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            flpContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            this.BackColor = Constants.BORDER_BOX_COLOR;

            UIHelper.BorderRadius(this, 5);
            UIHelper.BorderRadius(btnSave, 10);
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnUpdateThemeColor?.Invoke(name);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            OnResetColor?.Invoke();
        }
    }
}

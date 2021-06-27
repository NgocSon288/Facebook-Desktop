using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.DAO;
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
    public partial class fFileColor : Form
    {

        private FileListUC fileListUC;
        private ColorListUC colorListUC;

        public fFileColor()
        {
            InitializeComponent();


            Load();
        }

        int margin = 2;

        #region Methods

        new private void Load()
        {
            LoadFileList();

            LoadColorList();

            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            lblTitle.Left = pnlHead.Width / 2 - lblTitle.Width / 2;

            pnlHead.Width = this.Width - 2 * margin;
            pnlHead.Top = margin;
            pnlHead.Left = margin;

            pnlContent.Width = this.Width - 2 * margin;
            pnlContent.Height = this.Height - 3 * margin - pnlHead.Height;
            pnlContent.Top = pnlHead.Height + 2 * margin;
            pnlContent.Left = margin;

            pnlHead.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            this.BackColor = Constants.BORDER_BOX_COLOR;
        }

        private void LoadFileList()
        {
            fileListUC = new FileListUC(AutofacFactory<IFileColorDAO>.Get());
            fileListUC.OnClickFileItem += (f) =>
            {
                colorListUC.SetActive(f);

                fileListUC.Visible = false;
                colorListUC.Visible = true;
            };

            pnlContent.Controls.Add(fileListUC);
        }

        private void LoadColorList()
        {
            colorListUC = new ColorListUC(AutofacFactory<IFileColorDAO>.Get());
            colorListUC.Visible = false;
            colorListUC.OnChangedTheme += () =>
            {
                // Cho hiện list file lên và cập nhật db
                fileListUC.Visible = true;
                colorListUC.Visible = false;
            };

            colorListUC.OnClickBack += () =>
            {
                // Cho hiện list file lên và không làm gì
                fileListUC.Visible = true;
                colorListUC.Visible = false;
            };

            pnlContent.Controls.Add(colorListUC);
        }

        #endregion

        #region Events 


        #endregion
    }
}

using Facebook.Common;
using Facebook.Configure.Autofac;
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

namespace Facebook.Components.Drive
{
    public partial class DriveContentUC : UserControl
    {
        public delegate void ClickSpace();
        public delegate void OneClickFile(string file);
        public delegate void OneClickFolder(Folder folder);
        public delegate void TwoClickFolder(Folder folder);
        public event ClickSpace OnClickSpace;
        public event OneClickFile OnOneClickFile;
        public event OneClickFolder OnOneClickFolder;
        public event TwoClickFolder OnTwoClickFolder;

        DriveFolderUC driveFolderUC;
        DriveFileUC driveFileUC;
        DriveContentEmptyUC driveContentEmptyUC;

        public DriveContentUC()
        {
            InitializeComponent();

            Load();
        }

        int margin = 20;

        #region Methods

        new private void Load()
        {
            driveContentEmptyUC = new DriveContentEmptyUC();
            pnlEmpty.Controls.Add(driveContentEmptyUC);
            pnlEmpty.Height = driveContentEmptyUC.Height;

            CheckEmpty();
            pnlFolders.BackColor = Constants.MAIN_BACK_COLOR;
            pnlFiles.BackColor = Constants.MAIN_BACK_COLOR;

            lblFolders.ForeColor = Constants.MAIN_FORE_COLOR;
            lblFolders.BackColor = Constants.MAIN_BACK_COLOR;

            lblFiles.ForeColor = Constants.MAIN_FORE_COLOR;
            lblFiles.BackColor = Constants.MAIN_BACK_COLOR;

            LoadFolder();
            LoadFile();
        }

        private void LoadFolder()
        {
            driveFolderUC = new DriveFolderUC(AutofacFactory<IFolderDAO>.Get());
            driveFolderUC.Top = lblFolders.Height + margin;
            driveFolderUC.OnHeightChanged += () =>
            {
                pnlFolders.Height = lblFolders.Height + driveFolderUC.Height + margin;
            };
            driveFolderUC.OnOneClick += f => OnOneClickFolder?.Invoke(f);
            driveFolderUC.OnTwoClick += f => OnTwoClickFolder?.Invoke(f);
            driveFolderUC.OnClickSpace += () => OnClickSpace?.Invoke();

            pnlFolders.Controls.Add(driveFolderUC);
            pnlFolders.Height = lblFolders.Height + driveFolderUC.Height + margin;
        }

        private void LoadFile()
        {
            driveFileUC = new DriveFileUC(AutofacFactory<IFolderDAO>.Get());
            driveFileUC.Top = lblFiles.Height + margin;
            driveFileUC.OnHeightChanged += () =>
            {
                pnlFiles.Height = lblFiles.Height + driveFileUC.Height + margin;
            };
            driveFileUC.OnOneClick += (file) => OnOneClickFile?.Invoke(file);
            driveFileUC.OnClickSpace += () => OnClickSpace?.Invoke();

            pnlFiles.Controls.Add(driveFileUC);
            pnlFiles.Height = lblFiles.Height + driveFileUC.Height + margin;
        }

        private void CheckEmpty()
        {
            // Kiểm tra nếu Folder và file trống thì cho 2 pnl disable 
            // không có folder hay file gì
            pnlFiles.Visible = !string.IsNullOrEmpty(DriveLinkUC.CurrentFolder.Files);
            pnlFolders.Visible = !string.IsNullOrEmpty(DriveLinkUC.CurrentFolder.ChildrenID);
            pnlEmpty.Visible = !pnlFiles.Visible && !pnlFolders.Visible;
        }

        public void CreateOrUpdate()
        {
            CheckEmpty();
            driveFolderUC.CreateOrUpdate();
            driveFileUC.CreateOrUpdate();

        }


        public void DragEnter()
        {
            lblFiles.BackColor = lblFolders.BackColor = pnlEmpty.BackColor = pnlFiles.BackColor = pnlFolders.BackColor = this.BackColor = Constants.FOLDER_BACKGROUND_DRAG_ENTER_COLOR;
            //lblFiles.ForeColor = lblFolders.ForeColor = Constants.MAIN_BACK_COLOR;
            driveFolderUC.DragEnter();
            driveFileUC.DragEnter();
            driveContentEmptyUC.DragEnter();
        }

        public void DragLeave()
        {
            lblFiles.BackColor = lblFolders.BackColor = pnlEmpty.BackColor = pnlFiles.BackColor = pnlFolders.BackColor = this.BackColor = Constants.MAIN_BACK_COLOR;
            //lblFiles.ForeColor = lblFolders.ForeColor = Constants.MAIN_FORE_COLOR;
            driveFolderUC.DragLeave();
            driveFileUC.DragLeave();
            driveContentEmptyUC.DragLeave();
        }

        private void flpContent_Click(object sender, EventArgs e)
        {
            OnClickSpace?.Invoke();
        }

        #endregion
    }
}

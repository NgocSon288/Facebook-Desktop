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
            UpdateHeight();
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

            UpdateHeight();
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

            UpdateHeight();
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

            UpdateHeight();
        }

        public void ChangeColorExtension()
        {
            driveFileUC.ChangeColorExtension();
        }

        public void PasteFileOrFolder()
        {
            // xóa ra khỏi list
            var itemUC1 = Constants.CurrentCut as DriveFolderItemUC;
            var itemUC2 = Constants.CurrentCut as DriveFileItemUC;

            if (itemUC1 != null)
            {
                driveFolderUC.RemoveItem(itemUC1);
                pnlFolders.Height = lblFolders.Height + driveFolderUC.Height + margin;
            }

            if (itemUC2 != null)
            {
                driveFileUC.RemoveItem(itemUC2);
                pnlFiles.Height = lblFiles.Height + driveFileUC.Height + margin;
            }

            UpdateHeight();
        }

        private void UpdateHeight()
        {
            var mar = 2;
            var height = (pnlEmpty.Visible ? pnlEmpty.Height : 0) + (pnlFiles.Visible ? pnlFiles.Height : 0) + (pnlFolders.Visible ? pnlFolders.Height : 0) + mar * 2;

            var minHeight = 1252;
            pnlWrap.Height = height < minHeight ? minHeight : height;

            if (!pnlEmpty.Visible)
            {
                if (pnlFolders.Visible)
                {
                    pnlFolders.Top = mar;
                }
                else
                {
                    pnlFolders.Height = 0;
                }

                if (pnlFiles.Visible)
                {
                    pnlFiles.Top = pnlFolders.Bottom;
                }
            }
            else
            {
                pnlEmpty.Top = mar;
            }

            if (height < 1252)
            {
                if (pnlFiles.Visible && pnlFolders.Visible)
                {
                    // cho file height dài ra 
                    var heightSub = pnlWrap.Height - pnlFiles.Bottom;
                    pnlFiles.Height = pnlFiles.Height + heightSub - mar;
                }
                else if (pnlFiles.Visible)
                {
                    // cho file height dài ra 
                    var heightSub = pnlWrap.Height - pnlFiles.Bottom;
                    pnlFiles.Height = pnlFiles.Height + heightSub - mar;
                }
                else
                {
                    // cho folder dai ra 
                    var heightSub = pnlWrap.Height - pnlFolders.Bottom;
                    pnlFolders.Height = pnlFolders.Height + heightSub - mar;
                }
            }
        }

        public void DragEnter()
        {
            lblFiles.BackColor = lblFolders.BackColor = pnlEmpty.BackColor = pnlFiles.BackColor = pnlFolders.BackColor = this.BackColor = Constants.FOLDER_BACKGROUND_DRAG_ENTER_COLOR;
            driveFolderUC.DragEnter();
            driveFileUC.DragEnter();
            driveContentEmptyUC.DragEnter();
            pnlWrap.BackColor = Constants.FOLDER_BORDER_DRAG_ENTER_COLOR;
        }

        public void DragLeave()
        {
            lblFiles.BackColor = lblFolders.BackColor = pnlEmpty.BackColor = pnlFiles.BackColor = pnlFolders.BackColor = this.BackColor = Constants.MAIN_BACK_COLOR;
            driveFolderUC.DragLeave();
            driveFileUC.DragLeave();
            driveContentEmptyUC.DragLeave();
            pnlWrap.BackColor = Constants.MAIN_BACK_COLOR;
        }

        private void flpContent_Click(object sender, EventArgs e)
        {
            OnClickSpace?.Invoke();
        }

        #endregion 
    }
}

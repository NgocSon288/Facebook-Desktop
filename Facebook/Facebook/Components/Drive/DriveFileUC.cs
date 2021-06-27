using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.DAO;
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

namespace Facebook.Components.Drive
{
    public partial class DriveFileUC : UserControl
    {
        public delegate void ClickSpace();
        public delegate void OneClick(string file);
        public delegate void HeightChanged();
        public event ClickSpace OnClickSpace;
        public event OneClick OnOneClick;
        public event HeightChanged OnHeightChanged;

        private readonly IFolderDAO _folderDAO;

        List<string> files;

        public DriveFileUC(IFolderDAO folderDAO)
        {
            InitializeComponent();

            this._folderDAO = folderDAO;

            Load();
        }

        #region Methods

        new private void Load()
        {
            // Get file from DriveLinkUC.CurrentFolder
            files = StringHelper.StringToStringList(DriveLinkUC.CurrentFolder.Files);

            foreach (var item in files)
            {
                var itemUC = new DriveFileItemUC(AutofacFactory<IFileColorDAO>.Get(), item);
                itemUC.OnOneClick += () => OnOneClick?.Invoke(item);

                flpContent.Controls.Add(itemUC);
            }


            UpdateHeight();
            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        public void CreateOrUpdate()
        {
            var fis = StringHelper.StringToStringList(DriveLinkUC.CurrentFolder.Files); // danh sách các tên file(có random) bao gồm cũ và mới
            var fisNew = new List<string>();
            var fisDel = new List<string>();
            // tìm ra danh sách các file mới
            foreach (var item in fis)
            {
                if (!files.Contains(item))
                {
                    fisNew.Add(item);
                }
            }

            foreach (var item in files)
            {
                if (!fis.Contains(item))
                {
                    fisDel.Add(item);
                }
            }

            // Cập nhật Ram
            files.AddRange(fisNew);

            // Xóa các file cũ
            foreach (var item in fisDel)
            {
                files.Remove(item);
            }

            // Cập nhật UI với các file mới
            foreach (var item in fisNew)
            {
                var itemUC = new DriveFileItemUC(AutofacFactory<IFileColorDAO>.Get(), item);
                itemUC.OnOneClick += () => OnOneClick?.Invoke(item);

                flpContent.Controls.Add(itemUC);
            }

            // Xóa ui với các file bị xóa
            foreach (DriveFileItemUC item in flpContent.Controls)
            {
                if (fisDel.Contains(item.fileName))
                {
                    flpContent.Controls.Remove(item);
                }
            }

            UpdateHeight();
            OnHeightChanged?.Invoke();
        }

        private void UpdateHeight()
        {
            if (flpContent.Controls.Count <= 0)
            {
                this.Height = 0;
            }
            else
            {
                var item = flpContent.Controls[0];
                var count = flpContent.Controls.Count;
                var height = item.Height + item.Margin.Top + item.Margin.Bottom;


                this.Height = height * ((count + 3) / 4);
            }
        }

        public void ChangeColorExtension()
        {
            foreach (DriveFileItemUC item in flpContent.Controls)
            {
                item.SetColorAfterChangeColor();
            }
        }

        public void DragEnter()
        {
            flpContent.BackColor = this.BackColor = Constants.FOLDER_BACKGROUND_DRAG_ENTER_COLOR;
        }

        public void DragLeave()
        {
            flpContent.BackColor = this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        private void flpContent_Click(object sender, EventArgs e)
        {
            OnClickSpace?.Invoke();
        }

        public void RemoveItem(DriveFileItemUC item)
        {
            // Xóa ram
            files.Remove(item.fileName);

            // Xóa ui
            flpContent.Controls.Remove(item);
            UpdateHeight();
        }

        #endregion
    }
}

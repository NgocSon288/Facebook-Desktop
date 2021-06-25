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
    public partial class DriveFolderUC : UserControl
    {
        public delegate void ClickSpace();
        public delegate void OneClick(Folder folder);
        public delegate void TwoClick(Folder folder);
        public delegate void HeightChanged();
        public event ClickSpace OnClickSpace;
        public event OneClick OnOneClick;
        public event TwoClick OnTwoClick;
        public event HeightChanged OnHeightChanged;

        private readonly IFolderDAO _folderDAO;

        private List<Folder> folders;

        public DriveFolderUC(IFolderDAO folderDAO)
        {
            InitializeComponent();

            this._folderDAO = folderDAO;

            Load();
        }

        #region Methods

        new private void Load()
        {
            // Get file from DriveLinkUC.CurrentFolder
            folders = _folderDAO.GetByListID(StringHelper.StringToIntList(DriveLinkUC.CurrentFolder.ChildrenID));

            foreach (var item in folders)
            {
                var itemUC = new DriveFolderItemUC(item);
                itemUC.OnOneClick += () => OnOneClick?.Invoke(item);
                itemUC.OnTwoClick += () => OnTwoClick?.Invoke(item);

                flpContent.Controls.Add(itemUC);
            }

            UpdateHeight();
            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        public void CreateOrUpdate()
        {
            var fds = _folderDAO.GetByListID(StringHelper.StringToIntList(DriveLinkUC.CurrentFolder.ChildrenID)); // danh sách các Folder bao gồm cũ và mới
            var fdsNew = new List<Folder>();
            // tìm ra danh sách các file mới
            foreach (var item in fds)
            {
                if (!folders.Any(i => string.Equals(i.Name, item.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    fdsNew.Add(item);
                }
            }

            // Cập nhật Ram
            folders.AddRange(fdsNew);

            // Cập nhật UI với các file mới
            foreach (var item in fdsNew)
            {
                var itemUC = new DriveFolderItemUC(item);
                itemUC.OnOneClick += () => OnOneClick?.Invoke(item);
                itemUC.OnTwoClick += () => OnTwoClick?.Invoke(item);

                flpContent.Controls.Add(itemUC);
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

        #endregion
    }
}

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
    public partial class DriveLinkUC : UserControl
    {
        public delegate void ClickSpace();
        public delegate void ClickLinkItem();
        public event ClickSpace OnClickSpace;
        public event ClickLinkItem OnClickLinkItem;

        private List<Folder> folders;

        public static Folder CurrentFolder;

        public DriveLinkUC(List<Folder> folderInit)
        {
            InitializeComponent();

            this.folders = folderInit;

            Load();
        }

        #region Methods

        new private void Load()
        {
            // theo chiều ngang
            flpContent.WrapContents = false;

            var i = 0;
            foreach (var item in folders)
            {
                DriveLinkItemUC itemUC;
                if (i == 0)
                {
                    i++;
                    itemUC = new DriveLinkItemUC(item, true);
                }
                else
                {
                    itemUC = new DriveLinkItemUC(item, false);
                }

                itemUC.OnChangedFolder += () => ChangedFolder(item);

                flpContent.Controls.Add(itemUC);
            }

            CurrentFolder = folders[folders.Count - 1];
        }

        /// <summary>
        /// Khi bấm vào một item folder trên header
        /// </summary>
        /// <param name="item"></param>
        private void ChangedFolder(Folder item)
        {
            var index = folders.IndexOf(item);
            List<DriveLinkItemUC> itemsDelete = new List<DriveLinkItemUC>();
            List<Folder> foldersDelete = new List<Folder>();
            // Remove các itemUC phía sau nó
            foreach (DriveLinkItemUC linkItem in flpContent.Controls)
            {
                if (folders.IndexOf(linkItem.folder) > index)
                {
                    itemsDelete.Add(linkItem);
                    foldersDelete.Add(linkItem.folder);
                }
            }

            foreach (var itemDelete in itemsDelete)
            {
                flpContent.Controls.Remove(itemDelete);
            }

            foreach (var itemDelete in foldersDelete)
            {
                folders.Remove(itemDelete);
            }

            CurrentFolder = folders[folders.Count - 1];
            OnClickLinkItem?.Invoke();
        }

        public void AddFolder(Folder folder)
        {
            folders.Add(folder);
            CurrentFolder = folder;

            DriveLinkItemUC itemUC = new DriveLinkItemUC(folder);
            itemUC.OnChangedFolder += () => ChangedFolder(folder);

            flpContent.Controls.Add(itemUC);

        }

        #endregion

        #region Events

        private void flpContent_Click(object sender, EventArgs e)
        {
            OnClickSpace?.Invoke();
        }

        #endregion
    }
}

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

namespace Facebook.Components.Drive.Files.ChangeColor
{
    public partial class FileListUC : UserControl
    {
        public delegate void ClickFileItem(FileColor fileColor);
        public event ClickFileItem OnClickFileItem;

        private readonly IFileColorDAO _fileColorDAO;

        public FileListUC(IFileColorDAO fileColorDAO)
        {
            InitializeComponent();

            this._fileColorDAO = fileColorDAO;

            Load();
        }

        #region Methods

        new private void Load()
        {
            var fileColors = _fileColorDAO.GetAll();

            foreach (var item in fileColors)
            {
                var itemUC = new FileItemUC(item);
                itemUC.OnClickFileItem += () =>
                {
                    OnClickFileItem(item);
                };

                flpContent.Controls.Add(itemUC);
            }
        }


        #endregion
    }
}

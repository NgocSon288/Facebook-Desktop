using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Messenger
{
    public partial class FileAttachListUC : UserControl
    {
        public delegate void HeightChanged();
        public event HeightChanged OnHeightChanged;

        private List<string> fileList;

        public FileAttachListUC(List<string> fileList)
        {
            InitializeComponent();

            this.fileList = fileList;

            Load();
        }

        #region Methods

        new private void Load()
        {
            foreach (var item in fileList)
            {
                var itemUC = new FileAttachItemUC(item);
                itemUC.OnDeleteImage += () =>
                {
                    fileList.Remove(item);
                    flpContent.Controls.Remove(itemUC);
                    UpdateHeight();
                };

                flpContent.Controls.Add(itemUC);
            }

            UpdateHeight();
        }

        public void UpdateHeight()
        {
            if (fileList.Count <= 0)
            {
                this.Height = 0;
            }
            else
            {
                var con = flpContent.Controls[0];
                var count = flpContent.Controls.Count;
                var height = con.Height + con.Margin.Top + con.Margin.Bottom;

                this.Height = ((count + 1) / 2) * height;
            }

            OnHeightChanged?.Invoke();
        }

        #endregion
    }
}

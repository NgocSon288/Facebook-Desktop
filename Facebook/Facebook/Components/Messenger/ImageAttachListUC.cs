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
    public partial class ImageAttachListUC : UserControl
    {
        public delegate void HeightChanged();
        public event HeightChanged OnHeightChanged;

        private List<string> imageList;

        public ImageAttachListUC(List<string> imageList)
        {
            InitializeComponent();

            this.imageList = imageList;

            Load();
        }

        #region Methods

        new private void Load()
        {
            foreach (var item in imageList)
            {
                var itemUC = new ImageAttachItemUC(item);
                itemUC.OnDeleteImage += () =>
                {
                    imageList.Remove(item);
                    flpContent.Controls.Remove(itemUC);
                    UpdateHeight();
                };

                flpContent.Controls.Add(itemUC);
            }

            UpdateHeight();
        }

        public void UpdateHeight()
        {
            if (imageList.Count <= 0)
            {
                this.Height = 0;
            }
            else
            {
                var con = flpContent.Controls[0];
                var count = flpContent.Controls.Count;
                var height = con.Height + con.Margin.Top + con.Margin.Bottom;

                this.Height = ((count + 3) / 4) * height;
            }

            OnHeightChanged?.Invoke();
        }

        #endregion
    }
}

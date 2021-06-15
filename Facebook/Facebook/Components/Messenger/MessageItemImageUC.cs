using Facebook.Common;
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
    public partial class MessageItemImageUC : UserControl
    {
        private List<string> imagePaths;
        public bool isLeft;

        public MessageItemImageUC(List<string> imagePaths, bool isLeft)
        {
            InitializeComponent();

            this.imagePaths = imagePaths;
            this.isLeft = isLeft;

            Load();
            UpdateHeight();
        }

        #region Methods

        new private void Load()
        {
            flpContent.FlowDirection = isLeft ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;

            foreach (var item in imagePaths)
            {
                var itemUC = new MessageItemImageItemUC(item);

                flpContent.Controls.Add(itemUC);
            }

            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        private void UpdateHeight()
        {
            if (imagePaths == null || imagePaths.Count <= 0)
            {
                this.Height = 0;
                return;
            }

            var con = flpContent.Controls[0];
            var height = con.Height + con.Margin.Top + con.Margin.Bottom;
            var count = (flpContent.Controls.Count + 1) / 2;


            this.Height = height * count;
        }
        #endregion
    }
}

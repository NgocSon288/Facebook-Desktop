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
    public partial class MessageItemFileUC : UserControl
    {
        private List<string> fileNames;
        public bool isLeft;

        public MessageItemFileUC(List<string> fileNames, bool isLeft)
        {
            InitializeComponent();

            this.fileNames = fileNames;
            this.isLeft = isLeft;

            Load();
            UpdateHeight();
        }

        #region Methods

        new private void Load()
        {
            flpContent.FlowDirection = isLeft ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;

            foreach (var item in fileNames)
            {
                var itemUC = new MessageItemFileItemUC(item);

                flpContent.Controls.Add(itemUC);
            }

            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        private void UpdateHeight()
        {
            if (fileNames == null || fileNames.Count <= 0)
            {
                this.Height = 0;
                return;
            }

            var height = 0;

            foreach (Control item in flpContent.Controls)
            {
                height += item.Height + item.Margin.Bottom;
            }

            this.Height = height;
        }

        #endregion

        #region Events



        #endregion
    }
}

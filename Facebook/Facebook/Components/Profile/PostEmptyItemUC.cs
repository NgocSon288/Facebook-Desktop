using Facebook.Common;
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

namespace Facebook.Components.Profile
{
    public partial class PostEmptyItemUC : UserControl
    {
        public PostEmptyItemUC()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            Load();
        }

        #region Methods

        new private void Load()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            picEmpty.BackgroundImage = ImageHelper.FromFile("./../../Assets/Images/Profile/empty-post-icon.png");
            picEmpty.BackgroundImageLayout = ImageLayout.Stretch;
            picEmpty.Left = this.Width / 2 - picEmpty.Width / 2;

            lblTitle.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblTitle.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblTitle.Left = this.Width / 2 - lblTitle.Width / 2;

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
            UIHelper.SetBlur(this, () => this.ActiveControl = null);
        }

        #endregion 
    }
}

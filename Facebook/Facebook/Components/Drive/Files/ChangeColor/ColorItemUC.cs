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

namespace Facebook.Components.Drive.Files.ChangeColor
{
    public partial class ColorItemUC : UserControl
    {
        public delegate void ChangedTheme();
        public ChangedTheme OnChangedTheme;

        public ThemeColorItem theme;
        private bool isActive;

        public static ColorItemUC CurrentItemUC;

        public ColorItemUC(ThemeColorItem theme, bool isActive = false)
        {
            InitializeComponent();

            this.theme = theme;
            this.isActive = isActive;

            Load();
        }

        #region Methods

        new private void Load()
        {
            if (isActive)
            {
                SetActive();
            }

            pnlColor.BackColor = theme.Color;

            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(pnlColor, 100);
        }

        public void SetActive()
        {
            if (CurrentItemUC != null)
            {
                CurrentItemUC.pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
                UIHelper.BorderRadius(CurrentItemUC.pnlWrap, Constants.BORDER_RADIUS);
            }

            CurrentItemUC = this;

            CurrentItemUC.pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            UIHelper.BorderRadius(CurrentItemUC.pnlWrap, Constants.BORDER_RADIUS);
        }

        #endregion

        private void pnlWrap_Enter(object sender, EventArgs e)
        {
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void pnlWrap_MouseLeave(object sender, EventArgs e)
        {
            if (this == CurrentItemUC)
            {
                return;
            }

            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void pnlColor_Click(object sender, EventArgs e)
        {
            SetActive();
            OnChangedTheme?.Invoke();
        }
    }
}

﻿using Facebook.Common;
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
    public partial class DriveFileItemUC : UserControl
    {
        public delegate void OneClick();
        public event OneClick OnOneClick;

        public string fileName;

        public static DriveFileItemUC CurrentFileItemUCFocus = null;

        public DriveFileItemUC(string fileName)
        {
            InitializeComponent();

            this.fileName = fileName;

            Load();
        }

        int margin = 2;

        #region Methods

        new private void Load()
        {
            pnlWrap.Width = this.Width - 2 * margin;
            pnlWrap.Height = this.Height - 2 * margin;
            pnlWrap.Location = new Point(margin, margin);
            pnlWrap.BackColor = Constants.FOLDER_ITEM_COLOR;

            lblName.Text = fileName.Substring(9);
            var text = lblName.Text.Substring(0, lblName.Text.LastIndexOf("."));
            if (text.Length > 17)
            {
                text = text.Substring(0, 17) + "...";
            }
            lblName.Text = text;
            lblName.BackColor = Constants.FOLDER_ITEM_COLOR;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;

            picIcon.IconChar = ExtensionIcon.GetIconByPath(fileName);
            picIcon.IconColor = Constants.MAIN_FORE_COLOR;
            picIcon.BackColor = Constants.FOLDER_ITEM_COLOR;

            this.BackColor = Constants.FOLDER_ITEM_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);

            tt.SetToolTip(lblName, fileName.Substring(9));
            tt.SetToolTip(picIcon, fileName.Substring(9));
            Cut();
        }

        private void SetColor(Color color, bool isEnter = false, bool isPriority = false)
        {
            if (!CheckCut() || isPriority)
            {
                pnlWrap.BackColor = color;
                lblName.BackColor = color;
                lblName.ForeColor = Constants.MAIN_FORE_COLOR;
                picIcon.BackColor = color;
                picIcon.IconColor = Constants.MAIN_FORE_COLOR;

                this.BackColor = isEnter ? Constants.FOLDER_BORDER_ITEM_ENTER_COLOR : color;
                UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
                UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
            }
        }

        public void ResetColor()
        {
            CurrentFileItemUCFocus.SetColor(Constants.FOLDER_ITEM_COLOR);
            CurrentFileItemUCFocus = null;
        }

        private bool CheckCut()
        {
            return Constants.Clipboard != null && !Constants.Clipboard.IsFolder && string.Equals(Constants.Clipboard.FileName, fileName, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Khi gọi cut thì cập nhật màu sắc
        /// </summary>
        public void Cut()
        {
            if (CheckCut())
            {
                SetColor(Constants.FOLDER_ITEM_CUTED_BG__COLOR, true, true);
                lblName.ForeColor = Constants.FOLDER_ITEM_CUTED_FG_COLOR;
                picIcon.IconColor = Constants.FOLDER_ITEM_CUTED_FG_COLOR;

                Constants.CurrentCut = this;
            }
        }

        public void UnCut()
        {
            SetColor(Constants.FOLDER_ITEM_COLOR, false, true);
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            picIcon.IconColor = Constants.MAIN_FORE_COLOR;
        }

        public void SetColorAfterUnCut()
        {
            SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);
        }

        #endregion

        private void lblName_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentFileItemUCFocus == this || CheckCut())
                return;

            SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);
        }

        private void DriveFileItemUC_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentFileItemUCFocus == this || CheckCut())
                return;

            SetColor(Constants.FOLDER_ITEM_COLOR);
        }

        private void pnlWrap_Click(object sender, EventArgs e)
        {
            CurrentFileItemUCFocus?.SetColor(Constants.FOLDER_ITEM_COLOR);
            CurrentFileItemUCFocus = this;
            CurrentFileItemUCFocus.SetColor(Constants.FOLDER_ITEM_ENTER_COLOR, true);

            OnOneClick?.Invoke();
        }
    }
}
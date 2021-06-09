﻿using Facebook.Common;
using Facebook.ControlCustom.Image;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class HeaderProfileUC : UserControl
    {
        public delegate void UpdatedAvatar();
        public event UpdatedAvatar OnUpdatedAvatar;

        private readonly IUserDAO _userDAO;
        private User user;

        public HeaderProfileUC(IUserDAO userDAO, User user = null)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            this._userDAO = userDAO;
            this.user = user == null ? Constants.UserSession : user;

            Load();
        }

        #region Methods

        new private void Load()
        {
            beWrapAavatar.BackgroundImage = ImageHelper.GetImageByUser(user);
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_COLOR, user);

            lblName.Text = user?.Name;
            lblName.Left = this.Width / 2 - lblName.Width / 2;
            lblName.Top = this.Height - pnlBottom.Height - lblName.Height;

            pnlBottom.Width = 300;
            pnlBottom.Height = 5;
            pnlBottom.BackColor = Color.Gray;
            pnlBottom.Left = this.Width / 2 - pnlBottom.Width / 2;
            pnlBottom.Top = this.Height - pnlBottom.Height;

            SetColor();

            pnlWrapImage.BackColor = Constants.BORDER_IMAGE_COLOR;

            UIHelper.BorderRadius(beWrapAavatar, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(pnlWrapImage, Constants.BORDER_RADIUS);
            UIHelper.SetBlur(this, () => this.ActiveControl = null);
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            pnlBottom.BackColor = Constants.MAIN_FORE_COLOR;
        }

        #endregion



        #region Events

        /// <summary>
        /// Upload avatar khi click vào avatar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picAvatar_Click(object sender, EventArgs e)
        {
            if (user == Constants.UserSession)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Chọn một hình ảnh (Nên chọn hình ảnh có kích thướng vuông)";
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png;)|*.jpg; *.jpeg; *.gif; *.bmp; *.pnj;";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = openFileDialog.FileName;

                    if (File.Exists(fileName))
                    {

                        var newFileName = Path.GetFileName(fileName);
                        newFileName = new Random().Next(0, 1000000000).ToString() + newFileName;

                        if (!File.Exists(Path.Combine("./../../Assets/Images/Profile/" + fileName)))
                        {
                            File.Copy(fileName, Path.Combine("./../../Assets/Images/Profile/", newFileName));

                            // Update session
                            user.Avatar = newFileName;

                            // Thông báo cho các con tromg trang
                            OnUpdatedAvatar?.Invoke();

                            // Update DB
                            _userDAO.SaveChanges();
                        }

                        // Update UI avatar
                        picAvatar.BackgroundImage = UIHelper.ClipToCircle(ImageHelper.FromFile(fileName), Constants.MAIN_BACK_COLOR);
                    }
                }
            }
            else
            {
                MyImage.Show($"./../../Assets/Images/Profile/{user.Avatar}");
            }
        }

        /// <summary>
        /// Upload image khi click vào ảnh nền
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picImage_Click(object sender, EventArgs e)
        {
            if (user == Constants.UserSession)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Chọn một hình ảnh (1000 x 370)";
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png;)|*.jpg; *.jpeg; *.gif; *.bmp; *.pnj;";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = openFileDialog.FileName;

                    if (File.Exists(fileName))
                    {

                        var newFileName = Path.GetFileName(fileName);
                        newFileName = new Random().Next(0, 1000000000).ToString() + newFileName;

                        if (!File.Exists(Path.Combine("./../../Assets/Images/Profile/" + fileName)))
                        {
                            File.Copy(fileName, Path.Combine("./../../Assets/Images/Profile/", newFileName));

                            // Update session
                            user.Image = newFileName;

                            // Update DB
                            _userDAO.SaveChanges();
                        }

                        // Update UI avatar
                        beWrapAavatar.BackgroundImage = ImageHelper.FromFile(fileName);
                    }
                }
            }
            else
            {
                MyImage.Show($"./../../Assets/Images/Profile/{user.Image}");
            }
        }

        #endregion
    }
}

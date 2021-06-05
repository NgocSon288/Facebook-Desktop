using Facebook.Common;
using Facebook.DAO;
using Facebook.Helper;
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
        private readonly IUserDAO _userDAO;

        public HeaderProfileUC(IUserDAO userDAO)
        {
            InitializeComponent();

            this._userDAO = userDAO;

            Load();
        }

        #region Methods

        new private void Load()
        {
            picImage.BackgroundImage = ImageHelper.GetImageByUser();
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_COLOR);

            lblName.Text = Constants.UserSession?.Name;
            lblName.Left = this.Width / 2 - lblName.Width / 2;
            lblName.Top = this.Height - pnlBottom.Height - lblName.Height;

            pnlBottom.Width = 300;
            pnlBottom.Height = 5;
            pnlBottom.BackColor = Color.Gray;
            pnlBottom.Left = this.Width / 2 - pnlBottom.Width / 2;
            pnlBottom.Top = this.Height - pnlBottom.Height;

            SetColor();
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn một hình ảnh (Nên chọn hình ảnh có kích thướng vuông)";
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";

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
                        Constants.UserSession.Avatar = newFileName;

                        // Update DB
                        _userDAO.SaveChanges();
                    }

                    // Update UI avatar
                    picAvatar.BackgroundImage = UIHelper.ClipToCircle(Image.FromFile(fileName), Constants.MAIN_BACK_COLOR);
                }
            }
        }

        /// <summary>
        /// Upload image khi click vào ảnh nền
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn một hình ảnh (1000 x 370)";
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";

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
                        Constants.UserSession.Image = newFileName;

                        // Update DB
                        _userDAO.SaveChanges();
                    }

                    // Update UI avatar
                    picImage.BackgroundImage = Image.FromFile(fileName);
                }
            }
        }

        #endregion
    }
}

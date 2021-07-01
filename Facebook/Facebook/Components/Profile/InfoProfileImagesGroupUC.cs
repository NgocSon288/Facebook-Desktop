using Facebook.Common;
using Facebook.DTO;
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

namespace Facebook.Components.Profile
{
    public partial class InfoProfileImagesGroupUC : UserControl
    {
        private string title;
        private List<MetadataImage> images;

        public InfoProfileImagesGroupUC(string title, object data, bool isUser = false)
        {
            InitializeComponent();

            if (!isUser)
            {
                var ps = data as List<Post>;

                images = ps.Select(p =>
                new MetadataImage()
                {
                    Path = $"./../../Assets/Images/Post/{p.Image}",
                    CreatedAt = p.CreatedAt,
                    Own = p.User.Name,
                    FromPost = p.Description
                }).ToList();
            }
            else
            {
                images = new List<MetadataImage>();
                var user = data as User;

                // Từ Image
                if (!string.IsNullOrEmpty(user.Image))
                {
                    images.Add(new MetadataImage()
                    {
                        Path = $"./../../Assets/Images/Profile/{user.Image}",
                        CreatedAt = user.ImageUpdatedTime.Value,
                        Own = user.Name,
                        FromPost = "Ảnh bìa"
                    });
                }

                // Từ Avatar
                if (!string.IsNullOrEmpty(user.Avatar))
                {
                    images.Add(new MetadataImage()
                    {
                        Path = $"./../../Assets/Images/Profile/{user.Avatar}",
                        CreatedAt = user.AvatarUpdatedTime.Value,
                        Own = user.Name,
                        FromPost = "Ảnh đại diện"
                    });
                }
            }

            this.title = title;

            Load();
        }

        #region Methods

        new private void Load()
        {
            lblTitle.Text = title;
            lblTitle.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            foreach (var item in images)
            {
                var itemUC = new InfoProfileImageItemUC(item);

                flpContent.Controls.Add(itemUC);
            }

            UpdateHeight();
        }

        private void UpdateHeight()
        {
            var n = images.Count;
            var con = flpContent.Controls[0];
            var height = ((n + 4) / 5) * con.Height;

            flpContent.Height = height;
            this.Height = flpContent.Top + flpContent.Height;
        }

        #endregion
    }
}

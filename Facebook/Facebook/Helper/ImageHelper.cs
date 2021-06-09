using Facebook.Common;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Helper
{
    public static class ImageHelper
    {
        public static Image FromFile(string path)
        {
            Image img = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    img = Image.FromStream(fs);
                }
                finally
                {
                    fs.Close();
                }
            }

            return img;
        }

        /// <summary>
        /// Lấy ra hình ảnh đã  được bo tròn theo user truyền vào
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Image GetAvatarByUser(Color color, User user = null)
        {
            try
            {
                if (user == null)
                {
                    user = Constants.UserSession;
                }

                var path = $"./../../Assets/Images/Profile/{user.Avatar}";

                if (!File.Exists(path))
                {
                    path = "./../../Assets/Images/Profile/avatar-default.jpg";
                }
                return UIHelper.ClipToCircle(new Bitmap(path), color);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy ra ảnh đại diện dựa vào user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Image GetImageByUser(User user = null)
        {
            if (user == null)
            {
                user = Constants.UserSession;
            }

            var path = $"./../../Assets/Images/Profile/{user.Image}";

            if (!File.Exists(path))
            {
                path = "./../../Assets/Images/Profile/image-default.jpg";
            }

            // Có thể làm bo góc 10px
            return new Bitmap(path);
        }
    }
}

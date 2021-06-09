using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Helper
{
    public static class UIHelper
    {
        public delegate void ExpressBlur();

        /// <summary>
        /// Cân thực hiện sau khi laod UI
        /// </summary>
        /// <param name="control"></param>
        /// <param name="border"></param>
        public static void BorderRadius(Control control, int border)
        {
            Bunifu.Framework.Lib.Elipse.Apply(control, border);
        }
        public static void BorderRadius(Form form, int border)
        {
            Bunifu.Framework.Lib.Elipse.Apply(form, border);
        }

        public static void SetBlur(Control root, ExpressBlur expressBlur)
        {

            if (root.GetType().ToString().Contains("TextBox"))
            {
                return;
            }

            root.Click += (o, s) => expressBlur();

            if (root.Controls != null && root.Controls.Count > 0)
            {
                foreach (Control item in root.Controls)
                {
                    SetBlur(item, expressBlur);
                }
            }
        }

        public static void ShowControl(Control control, Control content)
        {
            content.Controls.Clear();

            foreach (Control item in content.Controls)
            {
                item.Dispose();
            }

            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            content.BringToFront();

            content.Controls.Add(control);
        }

        public static void ShowCombackControl(Control parent)
        {
            parent.Controls.Clear();

            parent.SendToBack();
        }

        public static Image ClipToCircle(Image img, Color bg)
        {
            if (img.Width == img.Height)
            {
                return ClipToCircleEquals2(img, bg);
            }

            return ClipToCircleNoEquals(img, bg);
        }

        public static Image ClipToCircleEquals(Image srcImage, Color backGround)
        {
            Image dstImage = new Bitmap(srcImage.Width * 2, srcImage.Height * 2, srcImage.PixelFormat);

            using (Graphics g = Graphics.FromImage(dstImage))
            {
                RectangleF r = new RectangleF(0, 0, srcImage.Width, srcImage.Height);

                // enables smoothing of the edge of the circle (less pixelated)
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // fills background color
                using (Brush br = new SolidBrush(backGround))
                {   // To từ vị trí 0;0 đến width;height
                    g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                }

                // adds the new ellipse & draws the image again 
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(r);
                g.SetClip(path);
                g.DrawImage(srcImage, 0, 0);

                return dstImage;
            }
        }

        /// <summary>
        /// Hàm góc
        /// </summary>
        /// <param name="srcImage"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="backGround"></param>
        /// <returns></returns>
        public static Image ClipToCircleRoot(Image srcImage, PointF center, float radius, Color backGround)
        {
            Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);

            using (Graphics g = Graphics.FromImage(dstImage))
            {
                RectangleF r = new RectangleF(center.X - radius, center.Y - radius,
                                                         radius * 2, radius * 2);

                // enables smoothing of the edge of the circle (less pixelated)
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // fills background color
                using (Brush br = new SolidBrush(backGround))
                {
                    g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                }

                // adds the new ellipse & draws the image again 
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(r);
                g.SetClip(path);
                g.DrawImage(srcImage, 0, 0);

                return dstImage;
            }
        }

        /// <summary>
        /// Chuẩn men với các hình vuông
        /// </summary>
        /// <param name="srcImage"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="backGround"></param>
        /// <returns></returns>
        public static Image ClipToCircleEquals(Image srcImage, float radius, Color backGround)
        {
            Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);

            using (Graphics g = Graphics.FromImage(dstImage))
            {
                RectangleF r = new RectangleF(0, 0, radius * 4, radius * 4);

                // enables smoothing of the edge of the circle (less pixelated)
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // fills background color
                using (Brush br = new SolidBrush(backGround))
                {
                    g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                }

                // adds the new ellipse & draws the image again 
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(r);
                g.SetClip(path);
                g.DrawImage(srcImage, 0, 0);

                return dstImage;
            }
        }

        /// <summary>
        /// Không vuông
        /// </summary>
        /// <param name="srcImage"></param>
        /// <param name="backGround"></param>
        /// <returns></returns>
        public static Image ClipToCircleNoEquals(Image srcImage, Color backGround)
        {
            Image dstImage = new Bitmap(srcImage.Width, srcImage.Width, srcImage.PixelFormat);

            using (Graphics g = Graphics.FromImage(dstImage))
            {
                RectangleF r = new RectangleF(0, 0, dstImage.Width, dstImage.Height);

                // enables smoothing of the edge of the circle (less pixelated)
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // fills background color
                using (Brush br = new SolidBrush(backGround))
                {
                    g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                }

                // adds the new ellipse & draws the image again 
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(r);
                g.SetClip(path);
                g.DrawImage(srcImage, 0, 0);

                return dstImage;
            }
        }

        public static Image ClipToCircleEquals2(Image srcImage, Color backGround)
        {
            try
            {
                Image dstImage = new Bitmap(srcImage.Width * 2, srcImage.Height * 2, srcImage.PixelFormat);

                using (Graphics g = Graphics.FromImage(dstImage))
                {
                    RectangleF r = new RectangleF(0, 0, dstImage.Width, dstImage.Height);

                    // enables smoothing of the edge of the circle (less pixelated)
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    // fills background color
                    using (Brush br = new SolidBrush(backGround))
                    {
                        g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                    }

                    // adds the new ellipse & draws the image again 
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(r);
                    g.SetClip(path);
                    g.DrawImage(srcImage, 0, 0);

                    return dstImage;
                }
            }
            catch (Exception)
            {
                return null;
                return ClipToCircleEquals2(ImageHelper.FromFile("./../../Assets/Images/Profile/avatar-default.jpg"), backGround);
            }
        }

    }
}

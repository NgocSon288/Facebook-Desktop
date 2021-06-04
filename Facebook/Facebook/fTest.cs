using Facebook.Common;
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

namespace Facebook
{
    public partial class fTest : Form
    {
        public fTest()
        {
            InitializeComponent();

            Load();
        }

        new private void Load()
        {
            var conan = "202419701son-avatar.jpg";
            var conan2 = "602510629hoa-sen-thap-muoi.jpg";
            var conan3 = "conan.jpg";

            var path = "./../../Assets/Images/Profile/";
            pic1.BackgroundImage = UIHelper.ClipToCircle(new Bitmap(path + conan), Constants.MAIN_BACK_COLOR);
            pic2.BackgroundImage = UIHelper.ClipToCircle(new Bitmap(path + conan2), Constants.MAIN_BACK_COLOR);
            pic3.BackgroundImage = UIHelper.ClipToCircle(new Bitmap(path + conan3), Constants.MAIN_BACK_COLOR);
        }

        private Bitmap GetAvatarOrDefault()
        {
            var conan = "202419701son-avatar.jpg";
            var conan2 = "602510629hoa-sen-thap-muoi.jpg";
            var conan3 = "conan.jpg";
            var path = "./../../Assets/Images/Profile/";

            var a = File.Exists(path);

            return new Bitmap(path);
        }
    }
}

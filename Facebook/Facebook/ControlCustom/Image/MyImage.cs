using Facebook.ControlCustom.WrapperForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.ControlCustom.Image
{
    public static class MyImage
    {
        public static void Show(string path)
        {
            var fImageShow = new fImageShow(path);
            var fparent = new fParentClickHidden(fImageShow);

            fparent.ShowDialog();
        }
    }
}

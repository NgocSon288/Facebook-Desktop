using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Common
{
    public static class ExtensionIcon
    {
        public static IconChar GetIconByPath(string path)
        {
            switch (Path.GetExtension(path))
            {
                case ".docs":
                case ".docm":
                case ".docx":
                case ".dot":
                case ".dotx":
                    return IconChar.FileWord;

                case ".pdf":
                    return IconChar.FilePdf;

                case ".pot":
                case ".potm":
                case ".potx":
                case ".ppam":
                case ".pps":
                case ".ppsm":
                case ".ppsx":
                case ".ppt":
                case ".pptm":
                case ".pptx":
                    return IconChar.FilePowerpoint;


                case ".tif":
                case ".tiff":
                case ".png":
                case ".jpg":
                case ".jpeg":
                case ".gif":
                case ".bmp":
                    return IconChar.FileImage;

                case ".htm":
                case ".html":
                    return IconChar.FileCode;

                case ".txt":
                    return IconChar.FileAlt;

                default:
                    return IconChar.File;
            }
        }
    }
}

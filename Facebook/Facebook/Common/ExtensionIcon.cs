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
        public static List<ExtensionNameColor> ExtensionList = new List<ExtensionNameColor>()
        {
            new ExtensionNameColor(){Category = "Word",Icon = IconChar.FileWord, Exts = new List<string>(){"docs","docm","docx","dot","dotx" }},
            new ExtensionNameColor(){Category = "Excel",Icon = IconChar.FileExcel, Exts = new List<string>(){ "xls", "xlsx" }},
            new ExtensionNameColor(){Category = "Pdf",Icon = IconChar.FilePdf, Exts = new List<string>(){ "pdf" }},
            new ExtensionNameColor(){Category = "Code",Icon = IconChar.FileCode, Exts = new List<string>(){ "css", "htm", "html", "js", "part" }},
            new ExtensionNameColor(){Category = "Zip",Icon = IconChar.FileInvoice, Exts = new List<string>(){ "rar", "tar.gz", "zip" }},
            new ExtensionNameColor(){Category = "Powerpoint",Icon = IconChar.FilePowerpoint, Exts = new List<string>(){ "pot", "potm", "potx", "ppam", "pps", "ppsm", "ppsx", "ppt", "pptm", "pptx" }},
            new ExtensionNameColor(){Category = "Audio",Icon = IconChar.FileAudio, Exts = new List<string>(){ "aif", "m3u", "mp3", "ra", "wav", "wma" }},
            new ExtensionNameColor(){Category = "Image",Icon = IconChar.FileImage, Exts = new List<string>(){ "tif", "tiff", "png", "jpg", "jpeg", "gif", "bmp", "cur", "ico", "psd", "raw" }},
            new ExtensionNameColor(){Category = "Csv",Icon = IconChar.FileCsv, Exts = new List<string>(){ "csv" }},
            new ExtensionNameColor(){Category = "Video",Icon = IconChar.FileVideo, Exts = new List<string>(){ "avi", "flv", "mov", "mp4", "mpg", "wmv" }},
            new ExtensionNameColor(){Category = "Text",Icon = IconChar.FileAlt, Exts = new List<string>(){ "txt"}}
        };

        public static IconChar GetIconByPath(string path)
        {
            var ext = Path.GetExtension(path).Substring(1); // txt
            var en = ExtensionList.FirstOrDefault(f => f.Exts.Contains(ext));

            return en != null ? en.Icon : IconChar.File; ;

        }
    }

    public class ExtensionNameColor
    {
        public string Category { get; set; }

        public List<string> Exts { get; set; }

        public IconChar Icon { get; set; }
    }
}

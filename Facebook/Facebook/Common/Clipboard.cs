using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Common
{
    public class Clipboard
    {
        public bool IsFolder { get; set; }

        public Folder ParentFolder { get; set; }

        public Folder Folder { get; set; }

        public string FileName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model.Models
{
    [Table("Folders")]
    public class Folder
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? ParentID { get; set; }

        public string ChildrenID { get; set; }

        public string Files { get; set; }

        public string ShareList { get; set; }

        public bool IsPublic { get; set; }

        public int UserID { get; set; }

        public string ColorName { get; set; }

        public bool IsShareRoot { get; set; }
    }
}

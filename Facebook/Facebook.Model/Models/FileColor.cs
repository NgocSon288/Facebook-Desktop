using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model.Models
{
    [Table("FileColors")]
    public class FileColor
    {
        [Key]
        public int ID { get; set; }

        public string Extension { get; set; }

        public string ExtensionName { get; set; }

        public string ColorName { get; set; }
    }
}

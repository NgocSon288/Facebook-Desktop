using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Facebook.Model.Models
{
    [Table("MessageSettings")]
    public class MessageSetting
    {
        public int ID { get; set; }

        public string ThemeColor { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? UpdatedBy { get; set; }



        public User User1 { get; set; }

        public User User2 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model.Models
{
    [Table("Messages")]
    public class Message
    {
        public int ID { get; set; }

        public int SenderID { get; set; }

        public int ReceiverID { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string File { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

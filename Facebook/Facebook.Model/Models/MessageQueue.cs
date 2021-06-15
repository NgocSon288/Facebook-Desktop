using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model.Models
{
    [Table("MessageQueues")]
    public class MessageQueue
    {
        public int ID { get; set; }

        public int OwnID { get; set; }

        public int SenderID { get; set; }

        public int ReceiverID { get; set; }

        public bool isRead { get; set; }


        [ForeignKey("Message")]
        public int MessageID { get; set; }

        public Message Message { get; set; }
    }
}

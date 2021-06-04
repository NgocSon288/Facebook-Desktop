using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model.Models
{
    [Table("CommentFeedbacks")]
    public class CommentFeedback
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public string Like { get; set; }

        public DateTime CreatedAt { get; set; }


        //[ForeignKey("User")]
        //public int UserID { get; set; }

        [ForeignKey("Comment")]
        public int CommentID { get; set; }


        public User User { get; set; }

        public Comment Comment { get; set; }
    }
}

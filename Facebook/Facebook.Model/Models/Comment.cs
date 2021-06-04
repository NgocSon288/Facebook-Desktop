using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Like { get; set; }


        //[ForeignKey("User")]
        //public int UserID { get; set; }

        [ForeignKey("Post")]
        public int PostID { get; set; }


        public User User { get; set; }

        public Post Post { get; set; }

        public List<CommentFeedback> CommentFeedbacks { get; set; }
    }
}

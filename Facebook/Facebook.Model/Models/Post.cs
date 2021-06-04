using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model.Models
{
    [Table("Posts")]
    public class Post
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }      // Thời gian tạo hoăc là thời gian share

        public int? PostShared { get; set; }    // nếu khác null là có một bài viết được chia sẻ


        //[ForeignKey("User")]
        //public int CreatedBy { get; set; }  // Người tạo, hoặc share

        [ForeignKey("PostStatus")]
        public int PostStatusID { get; set; }


        public User User { get; set; }

        public PostStatus PostStatus { get; set; }

        public List<Comment> Comments { get; set; }
    }
}

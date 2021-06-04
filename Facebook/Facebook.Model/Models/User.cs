using Facebook.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model.Models
{
    [Table("Users")]
    public class User : Auditable
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }      // ảnh đại diện

        public string Image { get; set; }       // ảnh bìa


        [ForeignKey("Profile")]
        public int? ProfileID { get; set; }


        public Profile Profile { get; set; }

        public List<Post> Posts { get; set; }
    }
}

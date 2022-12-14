using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryitterWebAPI.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public string UrlImage { get; set; }

        [ForeignKey(("StudentId"))]
        public Student StudentId { get; set; }
    }
}

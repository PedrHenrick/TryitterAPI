using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TryitterWebAPI.Models
{
    public class Student
    {
        [Key]
        [JsonIgnore]
        public int StudentId { get; set; }
        
        [MaxLength(200)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string CurrentModule { get; set; }
        public string Status { get; set; }

        [StringLength(maximumLength: 10, MinimumLength = 5)]
        public string Password { get; set; }

        [JsonIgnore]
        public ICollection<Post>? Posts { get; set; }
    }
}

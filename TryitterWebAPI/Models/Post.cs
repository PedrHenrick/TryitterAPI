using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TryitterWebAPI.Models
{
    public class Post
    {
        [Key]
        [JsonIgnore]
        public int PostId { get; set; }

        [MaxLength(300)]
        [JsonIgnore]
        public string Description { get; set; }

        [JsonIgnore]
        public string UrlImage { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }
    }
}

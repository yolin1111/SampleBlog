using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SampleBlog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public int BlogId { get; set; }
        [JsonIgnore]
        public Blog Blogs { get; set; }
    }
}
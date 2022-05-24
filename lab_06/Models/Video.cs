using System.Collections.Generic;
namespace Lab_06.Models
{
    public class Video : BaseModel
    {
        public int VideoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Path { get; set; }
        public string EmbedHtml { get; set; }
        public User User { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

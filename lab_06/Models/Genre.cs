using System.Collections.Generic;
namespace Lab_06.Models
{
    public class Genre : BaseModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Video Video { get; set; }
    }
}

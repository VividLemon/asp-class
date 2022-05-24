using System.Collections.Generic;
using System;
namespace Lab_06.Models
{
    public class Genre : IBaseModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<VideoGenre> VideoGenres { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
namespace Lab_06.Models
{
    public class VideoGenre : IBaseModel
    {
        public int VideoGenreId { get; set; }
        public Video Video { get; set; }
        public Genre Genre { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

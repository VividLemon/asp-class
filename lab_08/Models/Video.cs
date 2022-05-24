using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Lab_06.Models
{
    public class Video : IBaseModel
    {
        public int VideoId { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        public string Path { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        public string EmbedHtml { get; set; }
        public User User { get; set; }
        public List<LikedVideo> LikedVideo { get; set; }
        public List<VideoGenre> VideoGenres { get; set; }
        public List<Comment> Comments { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}

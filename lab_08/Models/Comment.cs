using System;

namespace Lab_06.Models
{
    public class Comment : IBaseModel
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Video Video { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

namespace Lab_06.Models
{
    public class Comment : BaseModel
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Video Video { get; set; }
    }
}

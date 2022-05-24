using System;

namespace Lab_06.Models
{
    public class LikedVideo : IBaseModel
    {
        // TODO finish out this system. Video play should contain the like feature
        // And it should show the likes/dislikes count on the play, 
        // Plus it should check if the logged in person has it liked and show different
        // And it should also delete the like/dislike on click
        // and add it on click as well.
        public int LikedVideoId { get; set; }
        public bool IsLike { get; set; }
        public Video Video { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

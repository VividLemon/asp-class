using System.Collections.Generic;
namespace Lab_06.Models.ViewModels
{
    public class PlayVideoViewModel
    {
        public Video Video { get; set; }
        public User User { get; set; }
        public bool? IsLike { get; set; }
        // TODO at this point, 
        // Get Count off likedVideos where is liked or is disliked
        // Then check if the current user has one of the liked and change
        // View accordingly
    }
}

using System.Collections.Generic;
using Lab_06.Models;
namespace Lab_06.Models.ViewModels
{
    public class VideosIndexViewModels
    {
        public IEnumerable<Video> Videos { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SearchQuery { get; set; }
        public List<Video> OwnedVideos { get; set; }
    }
}

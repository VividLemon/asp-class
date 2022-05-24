using System.Linq;
namespace Lab_06.Models
{
    public interface IVideoRepository
    {
        IQueryable<Video> Videos { get; }
        IQueryable<Video> VideosWithUser { get; }
        IQueryable<Video> VideosGetAll { get; }
    }
}

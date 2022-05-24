using System.Linq;
namespace Lab_06.Models
{
    public interface IVideoGenreRepository
    {
        IQueryable<VideoGenre> VideoGenres { get; }
        IQueryable<VideoGenre> VideosWithGenre { get; }
    }
}

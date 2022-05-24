using Lab_06.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Lab_06.Models
{
    public class EFVideoGenreRepository : IVideoGenreRepository
    {
        private ApplicationDbContext Context;
        public EFVideoGenreRepository(ApplicationDbContext ctx)
        {
            Context = ctx;
        }
        public IQueryable<VideoGenre> VideoGenres => Context.VideoGenres;
        public IQueryable<VideoGenre> VideosWithGenre => this.VideoGenres
            .Include(el => el.Video)
            .Include(el => el.Genre);
    }
}

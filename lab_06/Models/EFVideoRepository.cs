using Lab_06.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Lab_06.Models
{
    public class EFVideoRepository : IVideoRepository
    {
        private ApplicationDbContext Context;
        public EFVideoRepository(ApplicationDbContext ctx)
        {
            Context = ctx;
        }
        public IQueryable<Video> Videos => Context.Videos;
        public IQueryable<Video> VideosWithUser => this.Videos
                .Include(el => el.User);

        public IQueryable<Video> VideosGetAll => this.Videos
            .Include(el => el.User)
            .Include(el => el.Comments).ThenInclude(el => el.User);
        // TODO Seed data. Controller View results for 11 & 12. Certain fields in models are nullable
    }
}

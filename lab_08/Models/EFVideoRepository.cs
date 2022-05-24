using Lab_06.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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
                .Include(el => el.User)
                .Include(el => el.VideoGenres)
                    .ThenInclude(el => el.Genre);

        public IQueryable<Video> VideosGetAll => this.Videos
            .Include(el => el.User)
            .Include(el => el.Comments).ThenInclude(el => el.User)
            .Include(el => el.VideoGenres)
                .ThenInclude(el => el.Genre);

        public async Task DeleteVideoAsync(int id)
        {
            Video video = await Context.Videos.FirstOrDefaultAsync(el => el.VideoId == id);
            if(video != null)
            {
                video.IsDeleted = true;
                Context.Update(video);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<Video> SaveVideoAsync(Video video)
        {
            if(video.VideoId == 0)
            {
                await Context.Videos.AddAsync(video);
            }
            else
            {
                video.UpdatedAt = System.DateTime.Now;
                Context.Videos.Update(video);
            }
            await Context.SaveChangesAsync();
            return video;
        }

        public async Task<Video> CreateVideoAsync(Video video)
        {
            await Context.Videos.AddAsync(video);
            await Context.SaveChangesAsync();
            return video;
        }

        // TODO Seed data. Controller View results for 11 & 12. Certain fields in models are nullable
    }
}

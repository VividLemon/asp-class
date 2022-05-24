using Lab_06.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab_06.Models
{
    public class EFLikedVideoRepository : ILikedVideoRepository
    {
        private ApplicationDbContext Context;
        public EFLikedVideoRepository(ApplicationDbContext ctx)
        {
            Context = ctx;
        }

        public IQueryable<LikedVideo> LikedVideos => Context.LikedVideos
            .Include(el => el.Video)
            .Include(el => el.User);
        public async Task<LikedVideo> SaveLikeAsync(LikedVideo likedVideo)
        {
            LikedVideo old = await Context.LikedVideos.FirstOrDefaultAsync(el => el.LikedVideoId == likedVideo.LikedVideoId);
            if (old == null)
            {
                await Context.LikedVideos.AddAsync(likedVideo);
            }
            else
            {
                Context.LikedVideos.Update(likedVideo);
            }
            await Context.SaveChangesAsync();
            return old ?? likedVideo;
        }
        public async Task DeleteLikeAsync(LikedVideo likedVideo)
        {
            Context.LikedVideos.Remove(likedVideo);
            await Context.SaveChangesAsync();
        }
    }
}

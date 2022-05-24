using System.Linq;
using System.Threading.Tasks;
namespace Lab_06.Models
{
    public interface ILikedVideoRepository
    {
        IQueryable<LikedVideo> LikedVideos { get; }
        Task DeleteLikeAsync(LikedVideo likedVideo);
        Task<LikedVideo> SaveLikeAsync(LikedVideo likedVideo);
    }
}

using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Lab_06.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        Task<List<Video>> GetOwnedContentAsync(string userId);
        Task<User> CreateUserAsync(User user);
    }
}

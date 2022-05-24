using Lab_06.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Lab_06.Models
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext Context;
        public EFUserRepository(ApplicationDbContext ctx)
        {
            Context = ctx;
        }
        public IQueryable<User> Users => Context.Users;

        public async Task<User> CreateUserAsync(User user)
        {
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
            return user;
        }

        public async Task<List<Video>> GetOwnedContentAsync(string userId)
        {
            // TODO First the creating orders feature must be implemented. Before that, a sign in feature must be created. 
            User user = await Context.Users
                .Include(el => el.Orders).ThenInclude(el => el.CartLines).ThenInclude(el => el.Video)
                    .FirstOrDefaultAsync(el => el.Id == userId);
            if(user == null)
            {
                return new List<Video>();
            }
            else
            {
                List<Video> ownedVideos = user.Orders
                .SelectMany(el => el.CartLines
                    .Select(element => element.Video))
                .ToList();
                return ownedVideos;
            }

        }
    }
}

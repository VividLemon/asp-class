using Lab_06.Data;
using System.Linq;
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
    }
}

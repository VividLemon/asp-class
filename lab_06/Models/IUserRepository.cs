using System.Linq;
namespace Lab_06.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}

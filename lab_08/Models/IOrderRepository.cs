using System.Linq;
using System.Threading.Tasks;
namespace Lab_06.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        Task SaveOrderAsync(Order order);
    }
}

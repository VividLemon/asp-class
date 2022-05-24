using System.Linq;
using Microsoft.EntityFrameworkCore;
using Lab_06.Data;
using System.Threading.Tasks;

namespace Lab_06.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;
        public EFOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Order> Orders => _context.Orders.Include(el => el.CartLines).ThenInclude(el => el.Video);

        public async Task SaveOrderAsync(Order order)
        {
            _context.AttachRange(order.CartLines.Select(el => el.Video));
            if (order.OrderId == 0)
            {
                await _context.Orders.AddAsync(order);
            }
            await _context.SaveChangesAsync();
        }
    }
}

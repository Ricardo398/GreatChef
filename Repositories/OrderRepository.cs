using Microsoft.EntityFrameworkCore;
using GreatChef.Data;
using GreatChef.Models;

namespace GreatChef.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.RestaurantId == restaurantId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetPendingByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.RestaurantId == restaurantId && o.Status == OrderStatus.Pending)
                .ToListAsync();
        }

        public async Task<Order?> GetWithItemsAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            return await _context.Orders
                .Where(o => o.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date)
        {
            return await _context.Orders
                .Where(o => o.CreatedAt.Date == date.Date)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdWithItemsAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
} 
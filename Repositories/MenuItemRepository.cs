using Microsoft.EntityFrameworkCore;
using GreatChef.Data;
using GreatChef.Models;

namespace GreatChef.Repositories
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MenuItem>> GetByRestaurantIdAsync(int restaurantId)
        {
            return await _context.MenuItems
                .Where(m => m.RestaurantId == restaurantId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetAvailableByRestaurantIdAsync(int restaurantId)
        {
            return await _context.MenuItems
                .Where(m => m.RestaurantId == restaurantId && m.IsAvailable)
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsByRestaurantAsync(int restaurantId)
        {
            return await _context.MenuItems
                .Where(m => m.RestaurantId == restaurantId)
                .ToListAsync();
        }

        public async Task<MenuItem?> GetByIdWithRestaurantAsync(int id)
        {
            return await _context.MenuItems
                .Include(m => m.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
} 
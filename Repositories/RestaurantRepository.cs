using Microsoft.EntityFrameworkCore;
using GreatChef.Data;
using GreatChef.Models;

namespace GreatChef.Repositories
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Restaurant?> GetWithMenuItemsAsync(int id)
        {
            return await _context.Restaurants
                .Include(r => r.MenuItems)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Restaurant>> GetAllWithMenuItemsAsync()
        {
            return await _context.Restaurants
                .Include(r => r.MenuItems)
                .ToListAsync();
        }

        public async Task<Restaurant?> GetFirstAsync()
        {
            return await _context.Restaurants.FirstOrDefaultAsync();
        }
    }
} 
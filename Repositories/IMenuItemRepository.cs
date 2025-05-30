using GreatChef.Models;

namespace GreatChef.Repositories
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        Task<IEnumerable<MenuItem>> GetByRestaurantIdAsync(int restaurantId);
        Task<IEnumerable<MenuItem>> GetAvailableByRestaurantIdAsync(int restaurantId);
        Task<IEnumerable<MenuItem>> GetMenuItemsByRestaurantAsync(int restaurantId);
        Task<MenuItem?> GetByIdWithRestaurantAsync(int id);
    }
} 
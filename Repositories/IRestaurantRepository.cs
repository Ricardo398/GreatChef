using GreatChef.Models;

namespace GreatChef.Repositories
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<Restaurant?> GetWithMenuItemsAsync(int id);
        Task<IEnumerable<Restaurant>> GetAllWithMenuItemsAsync();
        Task<Restaurant?> GetFirstAsync();
    }
} 
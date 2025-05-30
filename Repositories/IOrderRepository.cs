using GreatChef.Models;

namespace GreatChef.Repositories
{
    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }

    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date);
        Task<Order?> GetByIdWithItemsAsync(int id);
    }
} 
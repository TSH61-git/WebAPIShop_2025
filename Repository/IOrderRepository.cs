using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order> AddOrder(Order oredr);
    }
}
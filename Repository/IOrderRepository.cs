using Entities;

namespace Repository
{
    public interface IOrderRepository
    {

        Task<Order> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<Order?> GetByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order> AddOrder(Order oredr);
        Task<bool> UpdateOrderStatusAsync(int orderId, string status);
    }
}
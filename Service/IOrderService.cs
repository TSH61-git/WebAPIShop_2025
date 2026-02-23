using DTOs;
using Entities;

namespace Service
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDTO>> GetOrdersByUserIdAsync(int userId);

        Task<OrderReadDTO> addOrder(OrderCreateDTO orderDto);
    }
}
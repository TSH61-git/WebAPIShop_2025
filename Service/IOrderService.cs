using DTOs;
using Entities;

namespace Service
{
    public interface IOrderService
    {
        Task<OrderReadDTO> addOrder(OrderCreateDTO orderDto);
    }
}
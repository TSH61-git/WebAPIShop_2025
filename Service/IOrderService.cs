using Entities;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> addOrder(Order order);
    }
}
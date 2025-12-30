using Entities;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyWebApiShopContext _context;

        public OrderRepository(MyWebApiShopContext context)
        {
            _context = context;
        }

        async public Task<Order> AddOrder(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
                throw new InvalidOperationException("Order must have at least one item.");

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}

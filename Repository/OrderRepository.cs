using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyWebApiShopContext _context;
        private readonly ILogger<UserRepository> _logger; 

        public OrderRepository(MyWebApiShopContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems) 
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems) 
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        async public Task<Order> AddOrder(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
                throw new InvalidOperationException("Order must have at least one item.");
            var productIds = order.OrderItems.Select(oi => oi.ProductId).ToList();

            var products = await _context.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync();

            decimal totalSum = 0;
            foreach (var item in order.OrderItems)
            {
                var product = products.FirstOrDefault(p => p.ProductId == item.ProductId);
                if (product != null)
                {
                    totalSum += (product.Price * item.Quantity);
                }
            }
            if (order.OrderSum != totalSum)
                _logger.LogError("SECURITY ALERT: Order sum mismatch! User {UserId} attempted to pay {ClientSum} but actual total is {ServerSum}.",
                         order.UserId, order.OrderSum ,totalSum);
            order.OrderSum = totalSum;
            //
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }


        public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return false;

            order.Status = status;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

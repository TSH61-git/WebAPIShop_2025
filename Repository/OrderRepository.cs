using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyWebApiShopContext _context;

        public OrderRepository(MyWebApiShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems) // טעינת פריטי ההזמנה (Eager Loading)
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
                { }
                //קיים שינוי ע"י המשתמש צריך להוסיף כתיבה ללוגר
            order.OrderSum = totalSum;
            //
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}

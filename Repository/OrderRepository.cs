using Entities;
using Repository.Models;
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

        async public Task<Order> AddOrder(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
                throw new InvalidOperationException("Order must have at least one item.");
            // 2. חישוב המחיר - שליפת כל המזהים של המוצרים שנשלחו בהזמנה
            var productIds = order.OrderItems.Select(oi => oi.ProductId).ToList();

            // 3. שליפה מהירה של המחירים מה-DB עבור כל המוצרים הרלוונטיים
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

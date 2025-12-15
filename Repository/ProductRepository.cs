using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System.Text.Json;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyWebApiShopContext _context;

        public ProductRepository(MyWebApiShopContext context)
        {
            _context = context;
        }

        async public Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

    }
}

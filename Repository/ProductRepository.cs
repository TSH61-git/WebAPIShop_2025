using Entities;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System.Text.Json;
using System.Linq;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyWebApiShopContext _context;

        public ProductRepository(MyWebApiShopContext context)
        {
            _context = context;
        }

        public async Task<(List<Product> Items, int TotalCount)> GetProducts(int position, int skip, ProductSearchParams parameters)
        {

            var query = _context.Products.Where(product =>
            ((parameters.Desc == null) ? (true) : (product.Description.Contains(parameters.Desc)))
            && ((parameters.MinPrice == null) ? (true) : (product.Price >= parameters.MinPrice))
            && ((parameters.MaxPrice == null) ? (true) : (product.Price <= parameters.MaxPrice))
            && ((parameters.CategoryIDs == null || parameters.CategoryIDs.Count == 0) ? (true) : (parameters.CategoryIDs.Contains((int)product.CategoryId))))
            .OrderBy(product => product.Price);

            List<Product> products = await query.Skip((position - 1) * skip)
            .Take(skip).Include(product => product.Category).ToListAsync();
            var total = await query.CountAsync();
            return (products, total);
        }
    }
}

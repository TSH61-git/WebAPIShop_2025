using DTOs;
using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<Product?> GetProductById(int id);
        Task<(List<Product> Items, int TotalCount)> GetProducts(int position, int skip, ProductSearchParams? parameters);
        Task<bool> UpdateProductAsync(Product product);
    }
}
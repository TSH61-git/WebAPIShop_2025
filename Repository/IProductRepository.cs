using DTOs;
using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<(List<Product> Items, int TotalCount)> GetProducts(int position, int skip, ProductSearchParams parameters);
    }
}
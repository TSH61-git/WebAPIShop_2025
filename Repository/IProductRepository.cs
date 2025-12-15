using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
    }
}
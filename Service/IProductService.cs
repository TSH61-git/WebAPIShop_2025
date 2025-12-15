using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}
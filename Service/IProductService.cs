using DTOs;
using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProducts();
    }
}
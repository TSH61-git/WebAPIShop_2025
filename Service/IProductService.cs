using DTOs;
using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<PageResponseDTO<ProductDTO>> GetProducts(int position, int skip, ProductSearchParams parameters);
    }
}
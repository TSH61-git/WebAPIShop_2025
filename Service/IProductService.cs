using DTOs;
using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<ProductDTO> AddProductAsync(ProductDTO productDto);
        Task<bool> DeleteProductAsync(int id);
        Task<ProductDTO?> GetProductById(int id);
        Task<PageResponseDTO<ProductDTO>> GetProducts(int position, int skip, ProductSearchParams parameters);
        Task<bool> UpdateProductAsync(Product product);
    }
}
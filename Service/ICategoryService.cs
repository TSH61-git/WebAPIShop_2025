using Entities;

namespace Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
    }
}
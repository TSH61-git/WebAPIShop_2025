using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryrepository;

        public CategoryService(ICategoryRepository categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _categoryrepository.GetCategories();
        }

    }
}

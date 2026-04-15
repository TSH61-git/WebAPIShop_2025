using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<ActionResult<IEnumerable<List<CategoryDTO>>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }

    }
}

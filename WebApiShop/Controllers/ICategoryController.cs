using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{
    public interface ICategoryController
    {
        Task<ActionResult<IEnumerable<List<CategoryDTO>>>> Get();

    }
}
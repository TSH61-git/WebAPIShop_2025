using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{
    public interface IBranchController
    {
        Task<ActionResult<IEnumerable<BranchDTO>>> Get([FromQuery] string? query);
    }
}
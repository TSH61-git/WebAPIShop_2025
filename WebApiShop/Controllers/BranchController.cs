using DTOs;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase, IBranchController
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        // GET: api/<BranchController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchDTO>>> Get([FromQuery] string? query)
        {
            var branches = await _branchService.GetBranches(query);
            if (branches == null)
                return NotFound();

            return Ok(branches);
        }

    }
}

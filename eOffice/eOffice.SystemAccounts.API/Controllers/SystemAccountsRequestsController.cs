using eOffice.SystemAccounts.Models;
using eOffice.SystemAccounts_Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace eOffice.SystemAccounts.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemAccountsRequestsController : ControllerBase
    {
        private readonly ISystemAccountsRequestService _requestService;

        public SystemAccountsRequestsController(ISystemAccountsRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _requestService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var result = _requestService.GetById(id);

            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] SystemAccountsRequestPatchModel model)
        {
            _requestService.Update(model);

            return Ok();
        }
    }
}
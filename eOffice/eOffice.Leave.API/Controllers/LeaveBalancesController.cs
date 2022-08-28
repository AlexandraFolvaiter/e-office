using eOffice.Leave.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eOffice.Leave.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveBalancesController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeaveBalancesController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet("details/{id:guid}")]
        public IActionResult GetByonboardingId(Guid id)
        {
            var result = _leaveService.GetByOnboardingId(id);

            return Ok(result);
        }
    }
}
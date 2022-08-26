using eOffice.Onboarding.Models;
using eOffice.Onboarding.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eOffice.Onboarding.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnboardingsController : ControllerBase
    {
        private readonly IOnboardingService _onboardingService;

        public OnboardingsController(IOnboardingService onboardingService)
        {
            _onboardingService = onboardingService;
        }

        [HttpGet("{userId:Guid}")]
        public IActionResult GetAllByUserId(Guid userId)
        {
            var result = _onboardingService.GetAllByUserId(userId);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] OnboardingModel model)
        {
            _onboardingService.Add(model);
            return Ok();
        }
    }
}
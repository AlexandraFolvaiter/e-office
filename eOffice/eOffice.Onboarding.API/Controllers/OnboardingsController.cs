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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }


        //public IActionResult GetById()
        //{
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult Add()
        {
            _onboardingService.Add(new Models.OnboardingModel());
            return Ok();
        }
    }
}
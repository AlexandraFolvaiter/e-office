using eOffice.Onboarding.Models;

namespace eOffice.Services
{
    public interface IOnboardingService
    {
        Task AddOnboarding(OnboardingModel model);
    }
}

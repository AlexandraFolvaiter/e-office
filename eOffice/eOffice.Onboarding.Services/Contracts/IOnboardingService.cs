using eOffice.Onboarding.Models;

namespace eOffice.Onboarding.Services.Contracts
{
    public interface IOnboardingService
    {
        IList<OnboardingGetModel> GetAllByUserId(Guid userId);
        void Add(OnboardingModel onboardingModel);
    }
}

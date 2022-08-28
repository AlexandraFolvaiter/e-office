using eOffice.Onboarding.Models;

namespace eOffice.Onboarding.Services.Contracts
{
    public interface IOnboardingService
    {
        IList<OnboardingGetModel> GetAllByUserId(Guid userId);
        OnboardingGetModel GetById(Guid id);
        void Add(OnboardingModel onboardingModel);
    }
}

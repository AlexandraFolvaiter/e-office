using eOffice.Onboarding.Models;

namespace eOffice.Services.Contracts
{
    public interface IOnboardingService
    {
        Task<IList<OnboardingGetModel>> GetAll(Guid userId);
        Task<OnboardingGetModel> GetById(Guid id);
        Task AddOnboarding(OnboardingModel model);
    }
}

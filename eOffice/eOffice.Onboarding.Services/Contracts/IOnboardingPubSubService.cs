using eOffice.Common.Models;

namespace eOffice.Onboarding.Services.Contracts
{
    public interface IOnboardingPubSubService
    {
        void Update(OnboardUpdateMessage message);
    }
}

using eOffice.Common.Models;
using eOffice.Onboarding.DataAccess.Repositories.Contracts;
using eOffice.Onboarding.Services.Contracts;

namespace eOffice.Onboarding.Services.Implementation
{
    public class OnboardingPubSubService : IOnboardingPubSubService
    {
        private readonly IOnboardingRepository _repository;

        public OnboardingPubSubService(IOnboardingRepository repository)
        {
            _repository = repository;
        }

        public void Update(OnboardUpdateMessage message)
        {
            var entity = _repository.GetById(message.OnboardingId);

            if(message.UpdateType == UpdateType.SystemAccountsRequest)
            {
                entity.IsSystemAccountsRequestCreated = message.UpdateValue;
            }

            if (message.UpdateType == UpdateType.LeaveOnboardingRequest)
            {
                entity.IsLeaveRequestCreated = message.UpdateValue;
            }

            _repository.Update(entity);
        }
    }
}

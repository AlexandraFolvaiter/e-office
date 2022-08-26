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

            switch (message.UpdateType)
            {
                case UpdateType.SystemAccountsRequest:
                    entity.IsSystemAccountsRequestCreated = message.UpdateValue;
                    break;
                case UpdateType.LeaveOnboardingRequest:
                    entity.IsLeaveRequestCreated = message.UpdateValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _repository.Update(entity);
        }
    }
}

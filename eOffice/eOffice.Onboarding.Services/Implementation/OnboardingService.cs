using eOffice.Common.Redis;
using eOffice.Onboarding.DataAccess.Repositories.Contracts;
using eOffice.Onboarding.Models;
using eOffice.Onboarding.Services.Contracts;
using eOffice.Onboarding.Services.Mappers;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace eOffice.Onboarding.Services.Implementation
{
    public class OnboardingService : IOnboardingService
    {
        private readonly ISubscriber _databaseSubscriber;
        private readonly IOnboardingRepository _repository;

        public OnboardingService(QueueMessagesConnection queueMessagesConnection, IOnboardingRepository repository)
        {
            _databaseSubscriber = queueMessagesConnection.GetSubscriber();
            _repository = repository;
        }

        public void Add(OnboardingModel onboardingModel)
        {
            var name = $"{onboardingModel.SystemAccount.FirstName} {onboardingModel.SystemAccount.LastName}";
            var onboardingEntity = new DataAccess.Entities.Onboarding(onboardingModel.UserId, name);

            _repository.Add(onboardingEntity);

            // onboard system accounts
            var systemAccountRequest = onboardingModel.SystemAccount.ToEntity(onboardingEntity.Id);
            var systemAccountDetails = JsonConvert.SerializeObject(systemAccountRequest);
            _databaseSubscriber.Publish(RedisChannelName.SystemAccountsChannel, new RedisValue(systemAccountDetails));

            // onboard leave
            _databaseSubscriber.Publish(RedisChannelName.LeaveChannel, new RedisValue("leave message"));
        }

        public IList<OnboardingGetModel> GetAllByUserId(Guid userId)
        {
            return _repository
                .GetAllByUserId(userId)
                .Select(o => o.ToModel())
                .ToList();
        }
    }
}

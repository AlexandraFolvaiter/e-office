using eOffice.Common.Redis;
using eOffice.Onboarding.Models;
using eOffice.Onboarding.Services.Contracts;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace eOffice.Onboarding.Services.Implementation
{
    public class OnboardingService : IOnboardingService
    {
        private readonly ISubscriber _databaseSubscriber;
        private readonly IDatabase _onboardingsDatabase;

        public OnboardingService(QueueMessagesConnection queueMessagesConnection)
        {
            _onboardingsDatabase = queueMessagesConnection.GetConnection();
            _databaseSubscriber = queueMessagesConnection.GetSubscriber();
        }
        
        public void Add(OnboardingModel onboardingModel)
        {
            // TODO: move to repository
            //var userId = Guid.Parse("7ba0f49c-8f7e-4f90-b514-f920cbdc74ff");
            //var entity = new DataAccess.Onboarding(userId);
            //var key = string.Format(RedisKeys.Onboarding, entity.Id);

            //_onboardingsDatabase.StringSet(key, JsonConvert.SerializeObject(entity));

            //var aa = _onboardingsDatabase.StringGet(key);
            //var asssa = _onboardingsDatabase.HashKeys("*");

            // onboard system accounts
            var systemAccountDetails = JsonConvert.SerializeObject(onboardingModel.SystemAccount);
            _databaseSubscriber.Publish(RedisChannelName.SystemAccountsChannel, new RedisValue(systemAccountDetails));

            // onboard leave
            _databaseSubscriber.Publish(RedisChannelName.LeaveChannel, new RedisValue("leave message"));
        }
    }
}

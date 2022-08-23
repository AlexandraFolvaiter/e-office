using eOffice.Common.Redis;
using eOffice.Onboarding.Models;
using eOffice.Onboarding.Services.Contracts;
using StackExchange.Redis;

namespace eOffice.Onboarding.Services.Implementation
{
    public class OnboardingService : IOnboardingService
    {
        private readonly ISubscriber _databaseSubscriber;

        public OnboardingService(QueueMessagesConnection queueMessagesConnection)
        {
            _databaseSubscriber = queueMessagesConnection.GetSubscriber();
        }
        
        public void Add(OnboardingModel onboardingModel)
        {
            //var database = new QueueMessagesConnection().GetConnection();

            //database.StringSet("test", "chiar am inserat");

            _databaseSubscriber.Publish(RedisChannelName.SystemAccountsChannel, new RedisValue("aici va fi un json transformat in string"));
            _databaseSubscriber.Publish(RedisChannelName.LeaveChannel, new RedisValue("leave message"));
        }
    }
}

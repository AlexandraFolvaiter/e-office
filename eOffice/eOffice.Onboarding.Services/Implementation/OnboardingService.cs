using eOffice.Onboarding.DataAccess.Connections;
using eOffice.Onboarding.Models;
using eOffice.Onboarding.Services.Contracts;

namespace eOffice.Onboarding.Services.Implementation
{
    public class OnboardingService : IOnboardingService
    {
        
        public void Add(OnboardingModel onboardingModel)
        {
            var database = new QueueMessagesConnection().GetConnection();

            database.StringSet("test", "chiar am inserat");

            database.Publish("account_insert", new StackExchange.Redis.RedisValue("aici va fi un json transformat in string"));
        }
    }
}

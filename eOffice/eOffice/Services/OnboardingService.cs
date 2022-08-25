using eOffice.Onboarding.Models;
using Newtonsoft.Json;

namespace eOffice.Services
{
    public class OnboardingService : IOnboardingService
    {
        private readonly HttpClient _httpClient;

        public OnboardingService()
        {
            _httpClient = new HttpClient();
        }
        public Task AddOnboarding(OnboardingModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // TODO: add these details to appsettingsjson
            return _httpClient.PostAsync("https://localhost:7237/Onboardings", httpContent);
        }
    }
}

using eOffice.Onboarding.Models;
using eOffice.Services.Contracts;
using Newtonsoft.Json;

namespace eOffice.Services.Implementations
{
    public class OnboardingService : IOnboardingService
    {
        private readonly HttpClient _httpClient;

        public OnboardingService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IList<OnboardingGetModel>> GetAll(Guid userId)
        {
            // TODO: add these details to appsettingsjson
            var response = await _httpClient.GetAsync($"https://localhost:7237/Onboardings/{userId}");
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IList<OnboardingGetModel>>(responseBody);

            return result;
        }

        public async Task<OnboardingGetModel> GetById(Guid id)
        {
            // TODO: add these details to appsettingsjson
            var response = await _httpClient.GetAsync($"https://localhost:7237/Onboardings/Details/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<OnboardingGetModel>(responseBody);

            return result;
        }

        public Task AddOnboarding(OnboardingModel model)
        {
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // TODO: add these details to appsettingsjson
            return _httpClient.PostAsync("https://localhost:7237/Onboardings", httpContent);
        }
    }
}

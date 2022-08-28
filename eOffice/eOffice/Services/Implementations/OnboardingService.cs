using eOffice.Onboarding.Models;
using eOffice.Services.Contracts;

namespace eOffice.Services.Implementations
{
    public class OnboardingService : IOnboardingService
    {
        private readonly CustomHttpClient _httpClient;
        private readonly string _baseUrl;

        public OnboardingService(IConfiguration configuration)
        {
            _httpClient = new CustomHttpClient();
            _baseUrl = configuration["Services:OnboardingService"];
        }

        public async Task<IList<OnboardingGetModel>> GetAll(Guid userId)
        {
            var url = $"{_baseUrl}/{userId}";
            var result = await _httpClient.Get<IList<OnboardingGetModel>>(url);

            return result;
        }

        public async Task<OnboardingGetModel> GetById(Guid id)
        {
            var url = $"{_baseUrl}/Details/{id}";

            var result = await _httpClient.Get<OnboardingGetModel>(url);

            return result;
        }

        public Task AddOnboarding(OnboardingModel model)
        {
            return _httpClient.Post(_baseUrl, model);
        }
    }
}

using eOffice.Services.Contracts;
using eOffice.SystemAccounts.Models;
using Newtonsoft.Json;

namespace eOffice.Services.Implementations
{
    public class SystemAccountsRequestService : ISystemAccountsRequestService
    {
        private readonly HttpClient _httpClient;

        public SystemAccountsRequestService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IList<SystemAccountsRequestGetModel>> GetAll()
        {
            // TODO: add these details to appsettingsjson
            var response = await _httpClient.GetAsync($"https://localhost:7064/SystemAccountsRequests");
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IList<SystemAccountsRequestGetModel>>(responseBody);

            return result;
        }

        public async Task<SystemAccountsRequestGetModel> GetById(Guid id)
        {
            // TODO: add these details to appsettingsjson
            var response = await _httpClient.GetAsync($"https://localhost:7064/SystemAccountsRequests/{id}");
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SystemAccountsRequestGetModel>(responseBody);

            return result;
        }

        public async Task<SystemAccountsRequestGetModel> GetByOnboardingId(Guid onboardingId)
        {
            // TODO: add these details to appsettingsjson
            var response = await _httpClient.GetAsync($"https://localhost:7064/SystemAccountsRequests/details/{onboardingId}");
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SystemAccountsRequestGetModel>(responseBody);

            return result;
        }

        public Task Patch(SystemAccountsRequestPatchModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // TODO: add these details to appsettingsjson
            return _httpClient.PatchAsync("https://localhost:7064/SystemAccountsRequests", httpContent);
        }
    }
}

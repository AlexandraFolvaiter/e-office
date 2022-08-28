using eOffice.Services.Contracts;
using eOffice.SystemAccounts.Models;

namespace eOffice.Services.Implementations
{
    public class SystemAccountsRequestService : ISystemAccountsRequestService
    {
        private readonly CustomHttpClient _httpClient;
        private readonly string _baseUrl;

        public SystemAccountsRequestService(IConfiguration config)
        {
            _httpClient = new CustomHttpClient();
            _baseUrl = config["Services:SystemAccountsRequestService"];
        }

        public async Task<IList<SystemAccountsRequestGetModel>> GetAll()
        {
            var result = await _httpClient.Get<IList<SystemAccountsRequestGetModel>>(_baseUrl);

            return result;
        }

        public async Task<SystemAccountsRequestGetModel> GetById(Guid id)
        {
            var url = $"{_baseUrl}/{id}";
            var result = await _httpClient.Get<SystemAccountsRequestGetModel>(url);

            return result;
        }

        public async Task<SystemAccountsRequestGetModel> GetByOnboardingId(Guid onboardingId)
        {
            var url = $"{_baseUrl}/details/{onboardingId}";
            var result = await _httpClient.Get<SystemAccountsRequestGetModel>(url);

            return result;
        }

        public Task Patch(SystemAccountsRequestPatchModel model)
        {
            return _httpClient.Patch(_baseUrl, model);
        }
    }
}

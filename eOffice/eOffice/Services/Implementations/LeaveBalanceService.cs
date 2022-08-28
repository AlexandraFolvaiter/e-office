using eOffice.Onboarding.Models;
using eOffice.Services.Contracts;
using eOffice.SystemAccounts.Models;
using Newtonsoft.Json;

namespace eOffice.Services.Implementations;

public class LeaveBalanceService : ILeaveBalanceService
{
    private readonly HttpClient _httpClient;

    public LeaveBalanceService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<LeaveBalanceModel> GetByOnboardingId(Guid onboardingId)
    {
        // TODO: add these details to appsettingsjson
        var response = await _httpClient.GetAsync($"https://localhost:7031/LeaveBalances/details/{onboardingId}");
        string responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<LeaveBalanceModel>(responseBody);

        return result;
    }
}
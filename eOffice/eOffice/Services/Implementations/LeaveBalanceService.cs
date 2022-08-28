using eOffice.Onboarding.Models;
using eOffice.Services.Contracts;

namespace eOffice.Services.Implementations;

public class LeaveBalanceService : ILeaveBalanceService
{
    private readonly CustomHttpClient _httpClient;
    private readonly string _baseUrl;
    public LeaveBalanceService(IConfiguration config)
    {
        _httpClient = new CustomHttpClient();
        _baseUrl = config["Services:LeaveBalanceService"];
    }

    public async Task<LeaveBalanceModel> GetByOnboardingId(Guid onboardingId)
    {
        var url = $"{_baseUrl}/details/{onboardingId}";

        var result = await _httpClient.Get<LeaveBalanceModel>(url);

        return result;
    }
}
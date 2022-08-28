using eOffice.Onboarding.Models;

namespace eOffice.Services.Contracts;

public interface ILeaveBalanceService
{
    Task<LeaveBalanceModel> GetByOnboardingId(Guid onboardingId);
}
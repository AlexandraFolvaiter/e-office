using eOffice.Leave.Models;

namespace eOffice.Leave.Services.Contracts;

public interface ILeaveService
{
    LeaveBalanceModel GetByOnboardingId(Guid onboardingId);
    void Add(LeaveBalanceModel model);
}
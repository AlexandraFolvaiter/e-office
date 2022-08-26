using eOffice.Leave.Models;

namespace eOffice.Leave.Services.Contracts;

public interface ILeaveService
{
    void Add(LeaveBalanceModel model);
}
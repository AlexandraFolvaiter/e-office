using eOffice.Leave.DataAccess.Entities;

namespace eOffice.Leave.DataAccess.Repositories;

public interface ILeaveRepository
{
    void AddLeave(LeaveBalance leave);
}
using eOffice.Leave.DataAccess.Entities;

namespace eOffice.Leave.DataAccess.Repositories;

public interface ILeaveRepository
{
    IQueryable<LeaveBalance> GetAll();
    void AddLeave(LeaveBalance leave);
}
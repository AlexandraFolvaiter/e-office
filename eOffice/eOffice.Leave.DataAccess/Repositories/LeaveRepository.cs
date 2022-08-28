using eOffice.Leave.DataAccess.Connections;
using eOffice.Leave.DataAccess.Entities;

namespace eOffice.Leave.DataAccess.Repositories;

public class LeaveRepository : ILeaveRepository
{
    private readonly DatabaseContext _context;

    public LeaveRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<LeaveBalance> GetAll()
    {
        return _context.LeaveBalances;
    }

    public void AddLeave(LeaveBalance leave)
    {
        _context.LeaveBalances.Add(leave);
        _context.SaveChanges();
    }
}
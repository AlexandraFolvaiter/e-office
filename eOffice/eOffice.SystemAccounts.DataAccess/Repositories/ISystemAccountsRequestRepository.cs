using eOffice.Leave.DataAccess.Entities;

namespace eOffice.SystemAccounts.DataAccess.Repositories
{
    public interface ISystemAccountsRequestRepository
    {
        IQueryable<SystemAccountsRequest> GetAll();
        SystemAccountsRequest GetById(Guid id);
        void Add(SystemAccountsRequest request);
        void Update(SystemAccountsRequest request);
    }
}

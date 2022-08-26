using eOffice.Leave.DataAccess.Entities;
using eOffice.Onboarding.DataAccess.Connections;

namespace eOffice.SystemAccounts.DataAccess.Repositories
{
    public class SystemAccountsRequestRepository : ISystemAccountsRequestRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SystemAccountsRequestRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<SystemAccountsRequest> GetAll()
        {
            return _databaseContext.SystemAccountsRequests;
        }

        public SystemAccountsRequest GetById(Guid id)
        {
            return GetAll().FirstOrDefault(sys => sys.Id.Equals(id));
        }

        public void Add(SystemAccountsRequest request)
        {
            _databaseContext.Add(request);
            _databaseContext.SaveChanges();
        }

        public void Update(SystemAccountsRequest request)
        {
            _databaseContext.Update(request);
            _databaseContext.SaveChanges();
        }
    }
}


using eOffice.SystemAccounts.Models;

namespace eOffice.SystemAccounts_Services.Implementations
{
    public interface ISystemAccountsRequestService
    {
        IList<SystemAccountsRequestGetModel> GetAll();
        SystemAccountsRequestGetModel GetById(Guid id);
        void Add(string model);
        void Update(SystemAccountsRequestPatchModel model);
    }
}

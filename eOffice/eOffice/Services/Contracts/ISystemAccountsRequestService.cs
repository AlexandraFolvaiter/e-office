using eOffice.Onboarding.Models;
using eOffice.SystemAccounts.Models;

namespace eOffice.Services.Contracts
{
    public interface ISystemAccountsRequestService
    {
        Task<IList<SystemAccountsRequestGetModel>> GetAll();
        Task<SystemAccountsRequestGetModel> GetById(Guid id);
        Task Patch(SystemAccountsRequestPatchModel model);
    }
}


using eOffice.SystemAccounts.Models;

namespace eOffice.SystemAccounts.Services.Contracts
{
    public interface ISystemAccountsRequestService
    {
        IList<SystemAccountsRequestGetModel> GetAll();
        SystemAccountsRequestGetModel GetById(Guid id);
        SystemAccountsRequestGetModel GetByOnboardingId(Guid onboardingId);
        void Add(string model);
        void Update(SystemAccountsRequestPatchModel model);
    }
}

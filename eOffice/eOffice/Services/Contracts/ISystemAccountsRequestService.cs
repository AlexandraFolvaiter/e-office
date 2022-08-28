using eOffice.SystemAccounts.Models;

namespace eOffice.Services.Contracts
{
    public interface ISystemAccountsRequestService
    {
        Task<IList<SystemAccountsRequestGetModel>> GetAll();
        Task<SystemAccountsRequestGetModel> GetById(Guid id);
        Task<SystemAccountsRequestGetModel> GetByOnboardingId(Guid onboardingId);
        Task Patch(SystemAccountsRequestPatchModel model);
    }
}

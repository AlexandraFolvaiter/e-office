using eOffice.SystemAccounts.DataAccess.Repositories;
using eOffice.SystemAccounts.Models;
using eOffice.SystemAccounts_Services.Mappers;
using Newtonsoft.Json;

namespace eOffice.SystemAccounts_Services.Implementations
{
    public class SystemAccountsRequestService : ISystemAccountsRequestService
    {
        private readonly ISystemAccountsRequestRepository _systemAccountsRequestRepository;

        public SystemAccountsRequestService(ISystemAccountsRequestRepository systemAccountsRequestRepository)
        {
            _systemAccountsRequestRepository = systemAccountsRequestRepository;
        }

        public IList<SystemAccountsRequestGetModel> GetAll()
        {
            return _systemAccountsRequestRepository
                .GetAll()
                .Select(a => a.ToModel()).ToList();
        }

        public SystemAccountsRequestGetModel GetById(Guid id)
        {
            return _systemAccountsRequestRepository
                .GetById(id).ToModel();
        }

        public void Add(string model)
        {
            var modelObject = JsonConvert.DeserializeObject<SystemAccountsRequestModel>(model);
            var entity = modelObject.ToEntity();

            _systemAccountsRequestRepository.Add(entity);
        }
    }
}

using eOffice.Common.Models;
using eOffice.Common.Redis;
using eOffice.Leave.DataAccess.Entities;
using eOffice.SystemAccounts.DataAccess.Repositories;
using eOffice.SystemAccounts.Models;
using eOffice.SystemAccounts_Services.Mappers;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace eOffice.SystemAccounts_Services.Implementations
{
    public class SystemAccountsRequestService : ISystemAccountsRequestService
    {
        private readonly ISystemAccountsRequestRepository _systemAccountsRequestRepository;
        private readonly ISubscriber _pubSubSubscriber;

        public SystemAccountsRequestService(ISystemAccountsRequestRepository systemAccountsRequestRepository, QueueMessagesConnection connection)
        {
            _systemAccountsRequestRepository = systemAccountsRequestRepository;
            _pubSubSubscriber = connection.GetSubscriber();
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

        public void Update(SystemAccountsRequestPatchModel model)
        {
            var entity = _systemAccountsRequestRepository.GetById(model.Id);
            entity.ResponseMessage = model.ResponseMessage;
            entity.IsCompleted = true;

            _systemAccountsRequestRepository.Update(entity);


            var onboardingUpdateMessage = new OnboardUpdateMessage
            {
                UpdateType = UpdateType.SystemAccountsRequest,
                OnboardingId = entity.OnboardingId,
                UpdateValue = true
            };

            var updateDetails = JsonConvert.SerializeObject(onboardingUpdateMessage);
            _pubSubSubscriber.Publish(RedisChannelName.OnboardingChannel, new RedisValue(updateDetails));
        }
    }
}

using eOffice.Common.Models;
using eOffice.Common.Redis;
using eOffice.Leave.DataAccess.Repositories;
using eOffice.Leave.Models;
using eOffice.Leave.Services.Contracts;
using eOffice.Leave.Services.Mapper;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace eOffice.Leave.Services.Implementations;

public class LeaveService : ILeaveService
{
    private readonly ILeaveRepository _repository;
    private readonly ISubscriber _subPubConnection;

    public LeaveService(ILeaveRepository repository, QueueMessagesConnection connection)
    {
        _repository = repository;
        _subPubConnection = connection.GetSubscriber();
    }

    public LeaveBalanceModel GetByOnboardingId(Guid onboardingId)
    {
        return _repository
            .GetAll()
            .FirstOrDefault(l => l.OnboardingId.Equals(onboardingId))
            .ToModel();
    }

    public void Add(LeaveBalanceModel model)
    {
        var entity = model.ToEntity();
        _repository.AddLeave(entity);

        var message = new OnboardUpdateMessage
        {
            OnboardingId = model.OnboardingId,
            UpdateType = UpdateType.LeaveOnboardingRequest,
            UpdateValue = true
        };

        var messageAsString = JsonConvert.SerializeObject(message);
        _subPubConnection.Publish(RedisChannelName.OnboardingChannel, messageAsString);
    }
}
using eOffice.Leave.DataAccess.Entities;
using eOffice.SystemAccounts.Models;

namespace eOffice.SystemAccounts_Services.Mappers
{
    public static class SystemAccountRequestMapper
    {
        public static SystemAccountsRequest ToEntity(this SystemAccountsRequestModel model)
        {
            return new SystemAccountsRequest
            {
                OnboardingId = model.OnboardingId,
                FirstName =  model.FirstName,
                LastName = model.LastName,
                CreateEOfficeAccount = model.CreateEOfficeAccount,
                CreateEmail = model.CreateEmail,
                Message = model.Message,
                BirthDate = model.BirthDate
            };
        }

        public static SystemAccountsRequestGetModel ToModel(this SystemAccountsRequest entity)
        {
            return new SystemAccountsRequestGetModel
            {
                Id = entity.Id,
                OnboardingId = entity.OnboardingId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CreateEOfficeAccount = entity.CreateEOfficeAccount,
                CreateEmail = entity.CreateEmail,
                Message = entity.Message,
                BirthDate = entity.BirthDate,
                IsCompleted = entity.IsCompleted,
                ResponseMessage = entity.ResponseMessage
            };
        }
    }
}

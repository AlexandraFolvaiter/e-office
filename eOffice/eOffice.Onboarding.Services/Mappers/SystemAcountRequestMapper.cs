using eOffice.Onboarding.DataAccess.Entities;
using eOffice.Onboarding.Models;

namespace eOffice.Onboarding.Services.Mappers
{
    internal static class SystemAcountRequestMapper
    {
        public static SystemAccountsRequest ToEntity(this SystemAccountModel model, Guid onboardingId)
        {
            return new SystemAccountsRequest
            {
                OnboardingId = onboardingId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                CreateEmail = model.CreateEmail,
                CreateEOfficeAccount = model.CreateEOfficeAccount,
                Message = model.Message
            };
        }
    }
}

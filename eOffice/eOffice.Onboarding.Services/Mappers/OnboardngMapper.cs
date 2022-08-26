using eOffice.Onboarding.Models;

namespace eOffice.Onboarding.Services.Mappers
{
    public static class OnboardngMapper
    {
        public static OnboardingGetModel ToModel(this DataAccess.Entities.Onboarding onboarding)
        {
            return new OnboardingGetModel
            {
                Id = onboarding.Id,
                Name = onboarding.Name,
                IsLeaveRequestCreated = onboarding.IsLeaveRequestCreated,
                IsSystemAccountsRequestCreated = onboarding.IsSystemAccountsRequestCreated,
                CreatedDate = onboarding.CreatedDate
            };
        }
    }
}

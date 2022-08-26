using eOffice.Onboarding.DataAccess.Entities;
using eOffice.Onboarding.Models;

namespace eOffice.Onboarding.Services.Mappers;

public static class LeaveMapper
{
    public static LeaveBalance ToEntity(this LeaveBalanceModel model, Guid onboardingId)
    {
        return new LeaveBalance
        {
            OnboardingId = onboardingId,
            DaysOff = model.DaysOff,
            LearningDays = model.LearningDays,
            UnpaidDaysOff = model.UnpaidDaysOff
        };
    }
}
using eOffice.Leave.DataAccess.Entities;
using eOffice.Leave.Models;

namespace eOffice.Leave.Services.Mapper;

public static class LeaveMapper
{
    public static LeaveBalance ToEntity(this LeaveBalanceModel model)
    {
        return new LeaveBalance
        {
            OnboardingId = model.OnboardingId,
            DaysOff = model.DaysOff,
            LearningDays = model.LearningDays,
            UnpaidDaysOff = model.UnpaidDaysOff
        };
    }
    public static LeaveBalanceModel ToModel(this LeaveBalance model)
    {
        return new LeaveBalanceModel
        {
            OnboardingId = model.OnboardingId,
            DaysOff = model.DaysOff,
            LearningDays = model.LearningDays,
            UnpaidDaysOff = model.UnpaidDaysOff
        };
    }
}
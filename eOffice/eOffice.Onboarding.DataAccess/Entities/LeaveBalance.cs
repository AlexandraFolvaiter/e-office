namespace eOffice.Onboarding.DataAccess.Entities
{
    public class LeaveBalance
    {
        public Guid OnboardingId { get; set; }
        public int DaysOff { get; set; }
        public int UnpaidDaysOff { get; set; }
        public int LearningDays { get; set; }
    }
}

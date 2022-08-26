namespace eOffice.Leave.Models
{
    public class LeaveBalanceModel
    {
        public Guid OnboardingId { get; set; }
        public int DaysOff { get; set; }
        public int UnpaidDaysOff { get; set; }
        public int LearningDays { get; set; }
    }
}

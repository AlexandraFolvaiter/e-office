namespace eOffice.Leave.DataAccess.Entities
{
    public class LeaveBalance
    {
        public Guid Id { get; set; }
        public Guid OnboardingId { get; set; }
        public int DaysOff { get; set; }
        public int UnpaidDaysOff { get; set; }
        public int LearningDays { get; set; }

        public LeaveBalance()
        {
            Id = Guid.NewGuid();
        }
    }
}

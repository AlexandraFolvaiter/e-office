namespace eOffice.Onboarding.Models
{
    public class OnboardingModel
    {
        public Guid UserId { get; set; }

        public SystemAccountModel SystemAccount { get; set; } = new SystemAccountModel();

        public LeaveBalanceModel Leave { get; set; } = new LeaveBalanceModel();
    }
}
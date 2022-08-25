namespace eOffice.Onboarding.Models
{
    public class OnboardingModel
    {
        public Guid UserId { get; set; }

        public SystemAccountModel SystemAccount { get; set; } = new SystemAccountModel();

        // leave details
        // leave details: sick leave, daysoff, etc
    }
}
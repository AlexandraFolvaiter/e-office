namespace eOffice.Onboarding.Models
{
    public class OnboardingGetModel
    {
        public Guid Id { get; set; }

        public bool IsSystemAccountsRequestCreated { get; set; }

        public bool IsLeaveRequestCreated { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsComplete => IsSystemAccountsRequestCreated && IsLeaveRequestCreated;
    }
}

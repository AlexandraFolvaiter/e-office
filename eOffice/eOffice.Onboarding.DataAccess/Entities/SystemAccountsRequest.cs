namespace eOffice.Onboarding.DataAccess.Entities
{
    public class SystemAccountsRequest
    {
        public Guid OnboardingId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool CreateEOfficeAccount { get; set; }
        public bool CreateEmail { get; set; }
        public string? Message { get; set; }
    }
}
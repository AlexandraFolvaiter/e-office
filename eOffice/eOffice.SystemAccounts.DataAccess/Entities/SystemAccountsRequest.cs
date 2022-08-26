namespace eOffice.Leave.DataAccess.Entities
{
    public class SystemAccountsRequest
    {
        public Guid Id { get; set; }
        public Guid OnboardingId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool CreateEOfficeAccount { get; set; }
        public bool CreateEmail { get; set; }
        public string? Message { get; set; }
        public string? ResponseMessage { get; set; }
        public bool IsCompleted { get; set; }

        public SystemAccountsRequest()
        {
            Id = Guid.NewGuid();
        }
        
    }
}

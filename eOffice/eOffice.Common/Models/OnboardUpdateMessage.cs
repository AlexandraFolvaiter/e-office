namespace eOffice.Common.Models
{
    public class OnboardUpdateMessage
    {
        // enum TypeUpdate
        public Guid OnboardingId { get; set; }
        public bool UpdateValue { get; set; }
        public string UpdateMessage { get; set; }
    }
}

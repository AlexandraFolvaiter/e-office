namespace eOffice.Common.Models
{
    public class OnboardUpdateMessage
    {
        public UpdateType UpdateType { get; set; }
        public Guid OnboardingId { get; set; }
        public bool UpdateValue { get; set; }
        public string UpdateMessage { get; set; }
    }
}

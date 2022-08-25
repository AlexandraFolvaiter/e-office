namespace eOffice.Onboarding.DataAccess
{
    public class Onboarding
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public bool IsSystemAccountsRequestCreated { get; set; }

        public bool IsLeaveRequestCreated { get; set; }

        public Onboarding(Guid userId, bool isSystemAccounsRequesttreated = false, bool isLeaveRequestCreated = false)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            IsSystemAccountsRequestCreated = isSystemAccounsRequesttreated;
            IsLeaveRequestCreated = isLeaveRequestCreated;
        }

        public Onboarding()
        {

        }
    }
}
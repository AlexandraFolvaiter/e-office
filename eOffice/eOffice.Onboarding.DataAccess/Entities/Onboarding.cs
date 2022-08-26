namespace eOffice.Onboarding.DataAccess.Entities
{
    public class Onboarding
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public bool IsSystemAccountsRequestCreated { get; set; }

        public bool IsLeaveRequestCreated { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public Onboarding(Guid userId, string name, bool isSystemAccounsRequesttreated = false, bool isLeaveRequestCreated = false)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            IsSystemAccountsRequestCreated = isSystemAccounsRequesttreated;
            IsLeaveRequestCreated = isLeaveRequestCreated;
            CreatedDate = DateTime.Now;
        }

        public Onboarding()
        {

        }
    }
}
using eOffice.Onboarding.DataAccess.Connections;
using eOffice.Onboarding.DataAccess.Repositories.Contracts;

namespace eOffice.Onboarding.DataAccess.Repositories
{
    public class OnboardingRepository : IOnboardingRepository
    {
        private readonly DatabaseContext _context;

        public OnboardingRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Entities.Onboarding onboarding)
        {
            _context.Onboardings.Add(onboarding);
            _context.SaveChanges();
        }

        public IQueryable<Entities.Onboarding> GetAllByUserId(Guid userId)
        {
            return _context
                .Onboardings
                .Where(o => o.UserId.Equals(userId));
        }
    }
}

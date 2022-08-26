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
        public IQueryable<Entities.Onboarding> GetAllByUserId(Guid userId)
        {
            return _context
                .Onboardings
                .Where(o => o.UserId.Equals(userId));
        }
        public Entities.Onboarding GetById(Guid id)
        {
            return _context
                .Onboardings
                .FirstOrDefault(o => o.Id.Equals(id));
        }

        public void Add(Entities.Onboarding onboarding)
        {
            _context.Onboardings.Add(onboarding);
            _context.SaveChanges();
        }

        public void Update(Entities.Onboarding onboarding)
        {
            _context.Onboardings.Update(onboarding);
            _context.SaveChanges();
        }
    }
}

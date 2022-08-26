namespace eOffice.Onboarding.DataAccess.Repositories.Contracts
{
    public interface IOnboardingRepository
    {
        IQueryable<Entities.Onboarding> GetAllByUserId(Guid userId);
        Entities.Onboarding GetById(Guid id);
        void Add(Entities.Onboarding onboarding);
        void Update(Entities.Onboarding onboarding);
    }
}

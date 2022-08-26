namespace eOffice.Onboarding.DataAccess.Repositories.Contracts
{
    public interface IOnboardingRepository
    {
        IQueryable<Entities.Onboarding> GetAllByUserId(Guid userId);
        void Add(Entities.Onboarding onboarding);
    }
}

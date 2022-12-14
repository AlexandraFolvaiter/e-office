using Microsoft.EntityFrameworkCore;

namespace eOffice.Onboarding.DataAccess.Connections
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) => Database.Migrate();

        public DbSet<Entities.Onboarding> Onboardings { get; set; }
    }
}

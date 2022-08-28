using eOffice.Leave.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace eOffice.SystemAccounts.DataAccess.Connections
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) => Database.Migrate();

        public DbSet<SystemAccountsRequest> SystemAccountsRequests { get; set; }
    }
}

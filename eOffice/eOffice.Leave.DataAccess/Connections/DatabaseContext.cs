using eOffice.Leave.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace eOffice.Leave.DataAccess.Connections
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) => Database.Migrate();

        public DbSet<LeaveBalance> LeaveBalances{ get; set; }
    }
}

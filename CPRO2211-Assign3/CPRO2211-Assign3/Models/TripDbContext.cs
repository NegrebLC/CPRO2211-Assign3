using Microsoft.EntityFrameworkCore;

namespace CPRO2211_Assign3.Models
{
    public class TripDbContext : DbContext
    {
        public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
    }
}

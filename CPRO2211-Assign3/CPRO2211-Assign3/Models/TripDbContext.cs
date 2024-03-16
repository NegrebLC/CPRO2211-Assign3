using Microsoft.EntityFrameworkCore;

namespace CPRO2211_Assign3.Models
{
    public class TripDbContext : DbContext
    {
        public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "Paris",
                    StartDate = new DateTime(2023, 4, 1),
                    EndDate = new DateTime(2023, 4, 7),
                    Accommodation = "Hotel Paris",
                    AccommodationPhone = "(403) 403-4034",
                    AccommodationEmail = "paris@hotel.com",
                    ThingToDo1 = "Visit the Eiffel Tower",
                    ThingToDo2 = "Explore the Louvre",
                    ThingToDo3 = "Walk along the Seine"
                },
                new Trip
                {
                    TripId = 2,
                    Destination = "New York",
                    StartDate = new DateTime(2023, 5, 15),
                    EndDate = new DateTime(2023, 5, 20),
                    ThingToDo1 = "See the Statue of Liberty",
                    ThingToDo2 = "Visit Central Park",
                    ThingToDo3 = "Explore Times Square"
                },
                new Trip
                {
                    TripId = 3,
                    Destination = "Tokyo",
                    StartDate = new DateTime(2023, 6, 10),
                    EndDate = new DateTime(2023, 6, 15),
                    Accommodation = "Tokyo Inn",
                    AccommodationPhone = "(405) 405-4056",
                    AccommodationEmail = "contact@tokyoinn.jp",
                    ThingToDo1 = "Visit Tokyo Tower"
                }
            );
        }
    }
}

using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<TripBag> TripBags { get; set; }

        public DbSet<TripElement> TripElements { get; set; }

        public DbSet<DayOfWork> DayOfWorks { get; set; }
    }
}
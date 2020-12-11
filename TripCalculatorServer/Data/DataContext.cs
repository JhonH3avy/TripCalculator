using Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<TripBag> TripBags { get; set; }

        public DbSet<DayOfWork> DayOfWorks { get; set; }

        public async Task<int> SaveAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataContext
    {
        Task<int> SaveAsync();

        DbSet<AppUser> Users { get; set; }

        DbSet<Trip> Trips { get; set; }

        DbSet<TripBag> TripBags { get; set; }

        DbSet<DayOfWork> DayOfWorks { get; set; }
    }
}
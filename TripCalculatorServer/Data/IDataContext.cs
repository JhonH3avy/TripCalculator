using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public interface IDataContext
    {
        DbSet<AppUser> Users { get; set; }

        DbSet<Trip> Trips { get; set; }

        DbSet<TripBag> TripBags { get; set; }

        DbSet<DayOfWork> DayOfWorks { get; set; }
    }
}
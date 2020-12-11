using System.Threading.Tasks;
using Entities;

namespace Services.Interfaces
{
    public interface ITripService
    {
        Task AddTripAsync(Trip trip);
    }
}
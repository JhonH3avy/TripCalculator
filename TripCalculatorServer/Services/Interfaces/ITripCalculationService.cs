using System.Threading.Tasks;
using Entities;

namespace Services.Interfaces
{
    public interface ITripCalculationService
    {
        Task<Trip> CalculateTripAsync(DayOfWork dow);
    }
}
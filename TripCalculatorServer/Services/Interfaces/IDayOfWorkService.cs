using System.Threading.Tasks;
using Entities;

namespace Services.Interfaces
{
    public interface IDayOfWorkService
    {
        Task AddDayOfWorkAsync(DayOfWork dow);
    }
}
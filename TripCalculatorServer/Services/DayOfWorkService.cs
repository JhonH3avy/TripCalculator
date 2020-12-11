using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Services
{
    public class DayOfWorkService : BaseService, IDayOfWorkService
    {
        public DayOfWorkService(IDataContext context, ILogger<IBaseService> logger) : base(context, logger)
        {
        }

        public async Task AddDayOfWorkAsync(DayOfWork dow)
        {
            await _context.DayOfWorks.AddAsync(dow);
        }
    }
}
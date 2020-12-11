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

        public async Task<DayOfWork> AddDayOfWorkAsync(DayOfWork dow)
        {
            var result = await _context.DayOfWorks.AddAsync(dow);
            await _context.SaveAsync();
            return result.Entity;
        }
    }
}
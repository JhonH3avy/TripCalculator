using Data;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Services
{
    public class BaseService : IBaseService
    {
        protected readonly IDataContext _context;
        protected readonly ILogger<IBaseService> _logger;
        public BaseService(IDataContext context, ILogger<IBaseService> logger)
        {
            _logger = logger;
            _context = context;
        }
    }
}
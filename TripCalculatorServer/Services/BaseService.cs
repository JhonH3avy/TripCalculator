using Data;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Services
{
    public class BaseService : IBaseService
    {
        protected readonly DataContext _context;
        protected readonly ILogger<IBaseService> _logger;
        public BaseService(DataContext context, ILogger<IBaseService> logger)
        {
            _logger = logger;
            _context = context;
        }
    }
}
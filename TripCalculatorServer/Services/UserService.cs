using System.Linq;
using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IDataContext context, ILogger<IBaseService> logger) : base(context, logger)
        {
        }

        public AppUser GetUserByIdentityNumber(string userIdentityNumber)
        {
            return _context.Users.FirstOrDefault(u => u.IdentityNumber == userIdentityNumber);
        }

        public async Task<AppUser> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task AddUserAsync(AppUser user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
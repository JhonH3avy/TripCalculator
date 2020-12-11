using System.Linq;
using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<AppUser> AddUserAsync(AppUser user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveAsync();
            return result.Entity;
        }
    }
}
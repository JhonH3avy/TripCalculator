using System.Threading.Tasks;
using Entities;

namespace Services.Interfaces
{
    public interface IUserService
    {
        AppUser GetUserByIdentityNumber(string userIdentityNumber);

        Task<AppUser> GetUserByIdAsync(int userId);

        Task<AppUser> AddUserAsync(AppUser user);
    }
}
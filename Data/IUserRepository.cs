using LoginApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace LoginApp.Data
{
    public interface IUserRepository
    {
        Task<User> GetUserbyUsernameAsync(string email);
        Task AddUserAsync(User user);
    }
}

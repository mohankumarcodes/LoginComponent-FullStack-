using LoginApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace LoginApp.Data
{
    public class UserRepository :IUserRepository // Implements IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }   
            
        public async Task<User> GetUserbyUsernameAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email== email);
        }

        public async Task AddUserAsync(User model)
        {
            _context.Users.Add(model);
           await _context.SaveChangesAsync();
        }
    }
}

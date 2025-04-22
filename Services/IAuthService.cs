using LoginApp.Models;
namespace LoginApp.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(RegisterModel model);
        Task<string>Authenticate(string email, string password);
    }
}

using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(User user);
        Task<(string Token, string Role, string Username, string Email, string Password)> AuthenticateUser(string email, string password);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> UpdateUserAsync(User user);
        Task<User> UpdateUserAsync(int id, User updatedUser);
    }
}

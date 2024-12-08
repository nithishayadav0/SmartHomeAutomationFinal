using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserById(int id);
        public Task<List<User>> GetAllUsersAsync();

        public Task<User> UpdateUserAsync(User user);
        Task<User> UpdateUserAsync(int id, User updatedUser);
    }
}

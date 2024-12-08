using SmartHomeAutomation.Data;
using SmartHomeAutomation.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartHomeAutomation.Repositories
{
   
        public class UserRepository : IUserRepository
        {
            private readonly SmartHomeDbContext _context;

            public UserRepository(SmartHomeDbContext context)
            {
                _context = context;
            }

            public async Task AddUser(User user)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetUserById(int id)
            {
                return await _context.Users.FindAsync(id);
            }
        public async Task<List<User>> GetAllUsersAsync()
        {
            // Retrieve all users from the database
            return await _context.Users.ToListAsync();
        }
        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUserAsync(int id, User updatedUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return null;  // Return null if the user is not found
            }

            // Update the user data
            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(updatedUser.Password);
            user.Role = updatedUser.Role;
            user.IsActive = updatedUser.IsActive;

           

            await _context.SaveChangesAsync();  // Save changes asynchronously

            return user;  // Return the updated user object
        }
    }

    
}

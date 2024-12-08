using SmartHomeAutomation.Repositories;
using SmartHomeAutomation.Models;
namespace SmartHomeAutomation.Services
{
    
        public class UserService : IUserService
        {
            private readonly IUserRepository _userRepository;
            private readonly JWTTOKENService _jwtTokenService;

            public UserService(IUserRepository userRepository, JWTTOKENService jwtTokenService)
            {
                _userRepository = userRepository;
                _jwtTokenService = jwtTokenService;
            }

            // Registers a new user
            public async Task<bool> RegisterUser(User user)
            {
                // Check if the user already exists
                var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
                if (existingUser != null)
                {
                    throw new Exception("User already exists.");
                }

                // Hash the user's password before saving
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                // Add the user to the database
                await _userRepository.AddUser(user);
                return true;
            }

        // Authenticates a user and returns a JWT token

        //public async Task<(string Token, string Role)> AuthenticateUser(string email, string password)
        //{
        //    // Retrieve the user by email
        //    var user = await _userRepository.GetUserByEmail(email);

        //    // Check if user is null
        //    if (user == null)
        //    {
        //        throw new UnauthorizedAccessException("Invalid credentials.");
        //    }

        //    // Verify password
        //    if (!VerifyPassword(password, user.Password))
        //    {
        //        throw new UnauthorizedAccessException("Invalid credentials.");
        //    }

        //    // Generate a JWT token
        //    var token = _jwtTokenService.GenerateToken(user.UserId, user.Username, user.Email, user.Role);

        //    return (token, user.Role); // Return both token and role as a tuple
        //}


        // Verifies a plaintext password against a hashed password
        public async Task<(string Token, string Role, string Username, string Email, string Password)> AuthenticateUser(string email, string password)
        {
            // Retrieve the user by email
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            // Verify password
            if (!VerifyPassword(password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            // Generate a JWT token
            var token = _jwtTokenService.GenerateToken(user.UserId, user.Username, user.Email, user.Role);

            // Return token, role, and user details as a tuple
            return (token, user.Role, user.Username, user.Email, password);
        }

        private bool VerifyPassword(string password, string hashedPassword)
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }



        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }
        public async Task<User> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUserAsync(user);
        }
        public async Task<User> UpdateUserAsync(int id, User updatedUser)
        {
            return await _userRepository.UpdateUserAsync(id, updatedUser);
        }

    }

  }


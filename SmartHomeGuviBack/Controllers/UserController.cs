using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Models;
using SmartHomeAutomation.Services;

namespace SmartHomeAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //user Register
        [HttpPost("register")]

        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                await _userService.RegisterUser(user);
                return Ok(new { message = "User Registered Successfully!!!." });
            }
            catch (Exception excep)
            {
                return BadRequest(excep.Message);
            }
        }




        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] UserLoginDTO loginReq)
        //{
        //    try
        //    {
        //        // Authenticate the user and get both token and role
        //        var authResponse = await _userService.AuthenticateUser(loginReq.Email, loginReq.Password);
        //        Console.Write(authResponse);
        //        // Return the token and role as part of the response
        //        return Ok(new { token = authResponse.Token, role = authResponse.Role });

        //    }
        //    catch (UnauthorizedAccessException ex)
        //    {
        //        return Unauthorized(new { message = ex.Message });
        //    }
        //}
        //u
       
        
         
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginReq)
        {
            try
            {
                // Authenticate the user
                var authResponse = await _userService.AuthenticateUser(loginReq.Email, loginReq.Password);

             
                return Ok(new
                {
                    token = authResponse.Token,
                    role = authResponse.Role,
                    username = authResponse.Username,
                    email = authResponse.Email,
                    password = authResponse.Password,
                   
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
        //[HttpGet("all-users")]
        //public async Task<IActionResult> GetAllUsers()
        //{
        //    var users = await _userService.GetAllUsersAsync();

        //    // If no users found
        //    if (users == null || !users.Any())
        //    {
        //        return NotFound("No users found.");
        //    }

        //    // Filter users with the role "Homeowner"
        //    var homeownerUsers = users.Where(u => u.Role.Equals("Homeowner", StringComparison.OrdinalIgnoreCase)).ToList();

        //    // If no homeowners found
        //    if (!homeownerUsers.Any())
        //    {
        //        return NotFound("No homeowners found.");
        //    }

        //    // Select only the necessary fields: Username, Email, and Role
        //    var userDtos = homeownerUsers.Select(u => new
        //    {
        //        u.Username,
        //        u.Email,
        //        u.Role,
        //        u.IsActive
        //    }).ToList();

        //    return Ok(userDtos);
        //}

        [HttpGet("all-users")]
        [Authorize(Roles = "Administrator,DeviceTechnician")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            // If no users found
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            // Filter users with the role "Homeowner" and IsActive = true
            var homeownerUsers = users
                .Where(u => u.Role.Equals("Homeowner", StringComparison.OrdinalIgnoreCase) )
                .ToList();

            // If no active homeowners found
            if (!homeownerUsers.Any())
            {
                return NotFound("No active homeowners found.");
            }

            // Select only the necessary fields: Username, Email, and Role
            var userDtos = homeownerUsers.Select(u => new
            {
                u.Username,
                u.Email,
                u.Role,
                u.IsActive
            }).ToList();

            return Ok(userDtos);
        }
        [HttpGet("all-tech")]
        [Authorize(Roles = "Administrator,DeviceTechnician")]


         //To get All technicinans
        public async Task<IActionResult> GetAlltech()
        {
            var users = await _userService.GetAllUsersAsync();

            // If no users found
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            // Filter users with the role "Homeowner" and IsActive = true
            var homeownerUsers = users
                .Where(u => u.Role.Equals("DeviceTechnician", StringComparison.OrdinalIgnoreCase) )
                .ToList();

            // If no active homeowners found
            if (!homeownerUsers.Any())
            {
                return NotFound("No active homeowners found.");
            }

            // Select only the necessary fields: Username, Email, and Role
            var userDtos = homeownerUsers.Select(u => new
            {
                u.Username,
                u.Email,
                u.Role,
                u.IsActive
            }).ToList();

            return Ok(userDtos);
        }

        

        // to update the user status
        [HttpPut("update-status/{userEmail}")]
        [Authorize(Roles = "Administrator,Guest,Homeowner")]
        public async Task<IActionResult> UpdateUserStatus(string userEmail, [FromBody] UpdateUserStatusDto updateUserStatusDto)
        {
            // Ensure the IsActive field is provided
            if (updateUserStatusDto == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid request data.");
            }

            // Get the user by email
            var user = await _userService.GetUserByEmailAsync(userEmail);
            if (user == null)
            {
                return NotFound($"User with email {userEmail} not found.");
            }

            // Update the user's IsActive status
            user.IsActive = updateUserStatusDto.IsActive;

            // Save the changes
            var updatedUser = await _userService.UpdateUserAsync(user);
            if (updatedUser == null)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }

            // Return updated user data
            return Ok(new
            {
                updatedUser.Username,
                updatedUser.Email,
                updatedUser.Role,
                updatedUser.IsActive
            });
        }
       
        

        //To get All User Roles
        
        [HttpGet("all-usersRoles")]
        [Authorize("All")]
        public async Task<IActionResult> GetAllUserRoles()
        {
            var users = await _userService.GetAllUsersAsync();

            // If no users found
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            // Select only necessary fields: Username, Email, Role, IsActive
            var userDtos = users.Select(u => new
            {
                u.Username,
                u.Email,
                u.Role,
                u.IsActive
            }).ToList();

            return Ok(userDtos);
        }
        
        
        // Update the user 
        [HttpPut]
        [Authorize(Roles = "Administrator,Homeowner")]
        public async Task<IActionResult> UpdateUser([FromBody] User updatedUser)

        {
            var id = GetUserIdFromClaims();
            if (id ==null)
            {
                return BadRequest("please login.");
            }

            var updated = await _userService.UpdateUserAsync(id, updatedUser);
            if (updated == null)
            {
                return NotFound("User not found.");
            }

            return NoContent();  // Successfully updated
        }
       
        
        //Getting User Id from JWT token
        private int GetUserIdFromClaims()
        {
            var userIdClaim = User?.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId; // Return the parsed userId
            }
            throw new Exception("User ID not found in token claims."); // Throw exception for debugging
        }


    }
}

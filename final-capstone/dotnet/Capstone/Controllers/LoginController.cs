using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserDAO userDAO;
        private readonly IApplicationDAO appDAO;

        public LoginController(ITokenGenerator _tokenGenerator, IPasswordHasher _passwordHasher, IUserDAO _userDAO, IApplicationDAO _appDAO)
        {
            tokenGenerator = _tokenGenerator;
            passwordHasher = _passwordHasher;
            userDAO = _userDAO;
            appDAO = _appDAO;
        }

        [HttpPost]
        public IActionResult Authenticate(LoginUser userParam)
        {
            // Default to bad username/password message
            IActionResult result = Unauthorized(new { message = "Username or password is incorrect" });

            // Get the user by username
            User user = userDAO.GetUser(userParam.Username);

            // If we found a user and the password hash matches
            if (user != null && passwordHasher.VerifyHashMatch(user.PasswordHash, userParam.Password, user.Salt))
            {
                // Create an authentication token
                string token = tokenGenerator.GenerateToken(user.UserId, user.Username, user.Role);

                // Create a ReturnUser object to return to the client
                LoginResponse retUser = new LoginResponse() { User = new ReturnUser() { UserId = user.UserId, Username = user.Username, Role = user.Role }, Token = token, IsFirstLogin =user.IsFirstLogin };

                // Switch to 200 OK
                result = Ok(retUser);
            }

            return result;
        }
        [HttpPost("/apply")]
        public IActionResult Apply(Application app)
        {
            IActionResult result;

            User existingUser = userDAO.GetUser(app.Username);
            if (existingUser != null && app !=null)
            {
                return Conflict(new { message = "Username already taken. Please choose a different username." });
            }

            bool success = appDAO.AddApplication(app);
            if(success)
            {
                result = Created(app.Username, null); //values aren't read on client
            }
            else
            {
                result = BadRequest(new { message = "An error occurred and user was not created." });
            }

            return result;
        }

        [HttpPut("/users")]
        public IActionResult UpdatePasswordAndInitialLogin(LoginUser user)
        {

            bool loginUpdateSuccess = userDAO.UpdateUserLoginStatus(user.Username);
            bool passwordUpdated = userDAO.UpdatePassword(user);
            if (loginUpdateSuccess && passwordUpdated)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(new { message = "An error occurred and user was not updated." });
            }

        }
        [HttpGet("/users")]
        public IActionResult GetAllUsers()
        {
            List<User> allUsers = userDAO.GetAllUsers();
            if (allUsers == null)
            {
                return BadRequest(new { message = "An error occurred." });
            }
            else
            {
                return Ok(allUsers);
            }
        }
    }
}

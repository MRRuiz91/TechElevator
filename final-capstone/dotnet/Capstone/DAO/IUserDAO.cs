using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role);
        bool UpdateUserLoginStatus(string username);
        int GetNewestUserId();
        List<User> GetAllUsers();
        bool UpdatePassword(LoginUser user);
    }
}

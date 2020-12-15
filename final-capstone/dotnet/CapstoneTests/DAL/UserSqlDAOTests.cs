using Capstone.DAO;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.DAL
{
    [TestClass]
    public class UserSqlDAOTests: AnimalDAOTests
    {
        [TestMethod]
        public void GetUserByUsernameTest()
        {
            IUserDAO dao = new UserSqlDAO(ConnectionString);
            User u = dao.GetUser("mark");
            Assert.IsNotNull(u);

        }

        [TestMethod]
        public void UpdateUserLoginStatusTest()
        {
            IUserDAO dao = new UserSqlDAO(ConnectionString);
            
            bool u = dao.UpdateUserLoginStatus(dao.GetNewestUserId());
            Assert.IsTrue(u);

        }
        [TestMethod]
        public void GetAllUsersTest()
        {
            IUserDAO dao = new UserSqlDAO(ConnectionString);
            List<User> allUsers = dao.GetAllUsers();
            Assert.AreEqual(2, allUsers.Count);
        }
    }


}

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
    }
}

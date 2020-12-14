using Capstone.DAO;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.DAL
{
    [TestClass]
    public class ApplicationSqlDAOTests :ApplicationDAOTests
    {
        [TestMethod]
        public void GetAppByUsernameTests()
        {
            IApplicationDAO dao = new ApplicationSqlDAO(ConnectionString);

            Application app = dao.GetApplicationsByUsername("catluvr");
            Assert.AreEqual(dao.GetNewestApplicationId(), app.ApplicationId);
        }

        [TestMethod]
        public void AddApplicationTests()
        {
            IApplicationDAO dao = new ApplicationSqlDAO(ConnectionString);

            Application app = new Application();
            app.Username = "dogluvr";
            app.Phone = "555-555-5555";
            app.Email = "dogluvr@woof.com";
            app.PromptResponse = "I LOVE DOGS!!!1";
            app.FirstName = "John";
            app.LastName = "Smith";
            app.Status = 1;
            bool isSuccessful = dao.AddApplication(app);
            Assert.IsTrue(isSuccessful);
        }

        [TestMethod]
        public void ApproveVolunteerApplicationTest()
        {
            IApplicationDAO appDao = new ApplicationSqlDAO(ConnectionString);
            IUserDAO userDao = new UserSqlDAO(ConnectionString);

            Application app = appDao.GetApplicationsByUsername("catluvr");
            ReturnUser updateSuccessful = appDao.ApproveVolunteerApplication(app);
            User user = userDao.AddUser("catluvr", "password123", "user");

            Assert.IsNotNull(updateSuccessful);
            Assert.IsNotNull(user);

        }
    }
}

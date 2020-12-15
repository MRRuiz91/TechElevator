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
        public void GetPendingApplicationsTest()
        {
            ApplicationSqlDAO dao = new ApplicationSqlDAO(ConnectionString);
            List<Application> pendingApps = dao.GetPendingApplications();
            Assert.AreEqual(2, pendingApps.Count);
        }

        [TestMethod]
        public void AddApplicationTests()
        {
            IApplicationDAO dao = new ApplicationSqlDAO(ConnectionString);

            Application app = new Application();
            app.Username = "dogluvr2";
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
            MiniApp mini = new MiniApp();
            Application app = appDao.GetApplicationsByUsername("catluvr");
            mini.Username = app.Username;
            mini.Status = 2;
            mini.ApplicationId = app.ApplicationId;
            ReturnUser updateSuccessful = appDao.ApproveVolunteerApplication(mini);
            User user = userDao.AddUser("catluvr", "password123", "user");

            Assert.IsNotNull(updateSuccessful);
            Assert.IsNotNull(user);

        }
        [TestMethod]
        public void RejectVolunteerApplicationTest()
        {
            IApplicationDAO dao = new ApplicationSqlDAO(ConnectionString);
            Application app = dao.GetApplicationsByUsername("brotato");
            MiniApp mini = new MiniApp();
            mini.Username = app.Username;
            mini.Status = 3;
            mini.ApplicationId = app.ApplicationId;
            bool success = dao.RejectVolunteerApplication(mini);
        }

        [TestMethod]
        public void AddApplicationTestHappyPath()
        {
            //Arrange
            IApplicationDAO dao = new ApplicationSqlDAO(ConnectionString);
            Application app = new Application();
            app.Username = "test";
            app.Phone = "123-456-7890";
            app.Email = "test@test.com";
            app.FirstName = "bob";
            app.LastName = "thorton";
            app.PromptResponse = "Testy test test test";

            //Act
            bool result = dao.AddApplication(app);

            //Assert
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void AddApplicationTestEmptyValues()
        {
            IApplicationDAO dao = new ApplicationSqlDAO(ConnectionString);
            Application app = new Application();
            app.Username = "test";
            app.Phone = "";
            app.Email = "test@test.com";
            app.PromptResponse = "Testy test test test";

            //Act
            bool result = dao.AddApplication(app);

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}

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
            Assert.AreEqual(1, app.ApplicationId);
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
    }
}

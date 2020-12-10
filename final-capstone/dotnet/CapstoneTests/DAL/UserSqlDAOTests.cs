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

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
            IUserDAO dao = new UserSqlDAO(ConnectionString);
            Application app = new Application();
            app.Username = "test";
            app.Phone = "123-456-7890";
            app.Email = "test@test.com";
            app.PromptResponse = "Testy test test test";

            //Act
            bool result = dao.AddApplication(app);

            //Assert
            Assert.AreEqual(true, result);
        }

    }
}

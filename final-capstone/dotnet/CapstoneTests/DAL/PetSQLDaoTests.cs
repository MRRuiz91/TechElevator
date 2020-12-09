using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAO;
using Capstone.Models;

namespace CapstoneTests.DAL
{
    [TestClass]
    public class PetSQLDaoTests: AnimalDAOTests
    {
        [TestMethod]
        public void GetAllPetTest()
        {
            //Arrange
            IPetDAO dao = new PetSqlDAO(ConnectionString);

            //Act
            IList<Pet> pet = dao.GetAllPets();

            //Assert
            Assert.AreEqual(3, pet.Count);
        }
    }
}

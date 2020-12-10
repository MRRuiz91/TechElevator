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
            IList<Pet> pet = dao.GetAvailablePets();

            //Assert
            Assert.AreEqual(3, pet.Count);
        }
        [TestMethod]
        public void AddAPet_ShouldIncreaseCount()
        {
            IPetDAO dao = new PetSqlDAO(ConnectionString);
            int startingRowCount = GetRowCount("pets");
            AddNewPet(dao);
            int endingRowCount = GetRowCount("pets");
            Assert.AreNotEqual(startingRowCount, endingRowCount);
        }
        private Pet AddNewPet(IPetDAO dao)
        {
            Pet pet = new Pet();
            pet.Breed = "calico";
            pet.Age = "5";
            pet.Name = "Flora";
            pet.Picture = "";
            pet.IsAdopted = true;
            pet.ArrivalDate = "unknown";
            pet.AdoptionDate = "02/24/15";
            pet.AdoptedBy = "Matt Jorgensen";
            dao.AddAPet(pet);
            return pet;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class PetController : ControllerBase
    {
        private readonly IPetDAO PetDao;

        public PetController(IPetDAO _petDao)
        {
            PetDao = _petDao;
        }

        [HttpGet("pets")]
        public List<Pet> GetAvailablePets()
        {
            //petDao = new PetSqlDAO();
            return PetDao.GetAvailablePets();
        }

        [HttpPost("pets")]
        public bool AddNewPet(Pet pet)
        {
            return PetDao.AddAPet(pet);
        }

    }
}

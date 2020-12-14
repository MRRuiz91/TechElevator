using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetDAO PetDao;
        private readonly IApplicationDAO AppDao;
        public PetController(IPetDAO _petDao, IApplicationDAO _appDao)
        {
            PetDao = _petDao;
            AppDao = _appDao;
        }

        [HttpGet("pets")]
        public List<Pet> GetAvailablePets()
        {
            //petDao = new PetSqlDAO();
            return PetDao.GetAvailablePets();
        }

        [HttpGet("pets/all")]
        public List<Pet> GetEveryPet()
        {
            return PetDao.GetEveryPetEver();
        }

        [HttpPost("pets")]
        public ActionResult<bool> AddNewPet(Pet pet)
        {
            bool result = PetDao.AddAPet(pet);

            if (result == false)
            {
                return NotFound();
            }
            else
            {
                return Created($"/pets/{pet.PetId}", result);
            }
            
        }
        [HttpPut("pets/{petToUpdate.id}")]
        public ActionResult<bool> UpdatePetById (Pet petToUpdate)
        {
            Pet existing = PetDao.GetPetById((int)petToUpdate.PetId);
            if (existing == null) //we didn't find anything matching that id
            {
                return NotFound("pet not found");
            }
            bool result = PetDao.UpdatePetListing(petToUpdate);
            return Ok(result);
           
        }

        [HttpPut("pets/app")]

        public ActionResult<ReturnUser> UpdateApplicationStatus(Application appToUpdate)
        {
            Application existing = AppDao.GetApplicationsByUsername(appToUpdate.Username);
            if (existing == null)
            {
                return NotFound("Application Not Found");
            }

            ReturnUser returnUser = AppDao.ApproveVolunteerApplication(appToUpdate);
            return returnUser;


        }
    }
}

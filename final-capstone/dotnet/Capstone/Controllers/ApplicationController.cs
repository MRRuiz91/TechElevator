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
    public class ApplicationController :ControllerBase
    {
        private readonly IPetDAO PetDao;
        private readonly IApplicationDAO AppDao;
        public ApplicationController(IApplicationDAO _appDao)
        {
            AppDao = _appDao;
        }
        [HttpGet("applications")]
        public IActionResult GetPendingApplications()
        {
            return Ok(AppDao.GetPendingApplications());
        }

        [HttpPut("applications")]//ask front end about URL

        public IActionResult UpdateApplicationStatus(MiniApp appToUpdate)
        {
            
            Application existing = AppDao.GetApplicationsByUsername(appToUpdate.Username);
            if (existing == null)
            {
                return NotFound("Application Not Found");
            }
            ReturnUser returnUser = null;
            if (appToUpdate.Status == 2)
            {
                returnUser = AppDao.ApproveVolunteerApplication(appToUpdate);
                return Ok(returnUser);
            }
            else
            {
                AppDao.RejectVolunteerApplication(appToUpdate);
                return NoContent();
            }
        }
    }
}

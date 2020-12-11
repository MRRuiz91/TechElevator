using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IApplicationDAO
    {
        Application GetApplicationsByUsername(string username);
        bool AddApplication(Application app);
        int GetNewestApplicationId();
    }
}

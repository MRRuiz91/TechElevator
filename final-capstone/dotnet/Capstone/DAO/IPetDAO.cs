﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IPetDAO
    {
        List<Pet> GetAvailablePets();

        bool AddAPet(Pet petToAdd);
        Pet GetPetById(int id);
        bool UpdatePetListing(Pet petToUpdate);
        List<Pet> GetEveryPetEver();
    }
}

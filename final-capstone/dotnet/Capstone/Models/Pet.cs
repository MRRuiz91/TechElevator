using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Pet
    {
        public int? PetId { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public bool IsAdopted { get; set; } = false;
        public string ArrivalDate { get; set; }
        public string AdoptionDate { get; set; } = null;
        public string AdoptedBy { get; set; } = null;
    }
}

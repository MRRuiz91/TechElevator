using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PetSqlDAO : IPetDAO
    {
        private readonly string connectionString;
        public PetSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Pet> GetAllPets()
        {
            List<Pet> allPets = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM pets WHERE isAdopted = 0", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Pet p = GetPetFromReader(reader);
                        allPets.Add(p);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return allPets;
        }

        private Pet GetPetFromReader(SqlDataReader reader)
        {
            Pet p = new Pet();
            p.PetId = Convert.ToInt32(reader["pet_id"]);
            p.Name = Convert.ToString(reader["pet_name"]);
            p.Age = Convert.ToInt32(reader["pet_age"]);
            p.Picture = Convert.ToString(reader["picture"]);
            p.IsAdopted = Convert.ToBoolean(reader["is_adopted"]);
            p.ArrivalDate = Convert.ToString(reader["arrival_date"]);
            p.AdoptionDate= Convert.ToString(reader["adoption_date"]);
            p.AdoptedBy = Convert.ToString(reader["adopted_by"]);
            p.Breed = Convert.ToString(reader["breed"]);

            return p;
        }
    }
}

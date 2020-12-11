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

        public List<Pet> GetAvailablePets()
        {
            List<Pet> allPets = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT pet_id, breed, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by FROM pets WHERE is_adopted = 0", conn);
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
            p.Breed = reader.IsDBNull(1) ? "" : Convert.ToString(reader["breed"]);
            p.Age = reader.IsDBNull(2) ? "" : Convert.ToString(reader["pet_age"]);
            p.Name = Convert.ToString(reader["pet_name"]);
            p.Picture = reader.IsDBNull(4) ? "" : Convert.ToString(reader["pet_image"]);
            p.IsAdopted = Convert.ToBoolean(reader["is_adopted"]);
            p.ArrivalDate = Convert.ToString(reader["arrival_date"]);
            p.AdoptionDate= Convert.ToString(reader["adoption_date"]);
            p.AdoptedBy = Convert.ToString(reader["adopted_by"]);

            return p;
        }

        public bool UpdatePetListing(Pet petToUpdate)
        {
            bool success = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE pets SET breed = @breed, pet_age = @age, pet_name = @name, pet_image = @picture, is_adopted = @isAdopted, " +
                                                    "arrival_date = @arrivalDate, adoption_date = @adoptionDate, adopted_by = @adoptedBy WHERE pet_id = @petId", conn);
                    cmd.Parameters.AddWithValue("@petId", petToUpdate.PetId);
                    cmd.Parameters.AddWithValue("@breed", petToUpdate.Breed);
                    cmd.Parameters.AddWithValue("@age", petToUpdate.Age);
                    cmd.Parameters.AddWithValue("@name", petToUpdate.Name);
                    cmd.Parameters.AddWithValue("@picture", petToUpdate.Picture);
                    cmd.Parameters.AddWithValue("@isAdopted", petToUpdate.IsAdopted);
                    cmd.Parameters.AddWithValue("@arrivalDate", petToUpdate.ArrivalDate);
                    cmd.Parameters.AddWithValue("@adoptionDate", petToUpdate.AdoptionDate);
                    cmd.Parameters.AddWithValue("@adoptedBy", petToUpdate.AdoptedBy);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        success = true;
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return success;
        }

        public Pet GetPetById(int id)
        {
            Pet returnedPet = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT pet_id, breed, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by " + 
                                                    "FROM pets WHERE pet_id = @petId", conn);
                    cmd.Parameters.AddWithValue("@petId", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnedPet = GetPetFromReader(reader);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return returnedPet;
        }

        public bool AddAPet(Pet petToAdd)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO pets (breed, pet_age, pet_name, pet_image, is_adopted, arrival_date) " +
                                                    "VALUES (@breed, @age, @name, @img, @isAdopted, @arrivalDate);", conn);
                    cmd.Parameters.AddWithValue("@breed", petToAdd.Breed);
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(petToAdd.Age));
                    cmd.Parameters.AddWithValue("@name", petToAdd.Name);
                    cmd.Parameters.AddWithValue("@img", petToAdd.Picture);
                    int adoptedBoolToInt = petToAdd.IsAdopted == false ? 0 : 1;
                    cmd.Parameters.AddWithValue("@isAdopted", adoptedBoolToInt);
                    cmd.Parameters.AddWithValue("@arrivalDate", petToAdd.ArrivalDate);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    
                    if (rowsAffected > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return result;


        }
        public int GetNewestPetId()
        {
            int newPetId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MAX(pet_id) from pets", conn);
                    newPetId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return newPetId;
        }
    }
}

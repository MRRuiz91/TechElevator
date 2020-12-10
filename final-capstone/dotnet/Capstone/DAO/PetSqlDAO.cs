﻿using Capstone.Models;
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
                    SqlCommand cmd = new SqlCommand("SELECT pet_id, breed, pet_age, pet_name, pet_image, arrival_date FROM pets WHERE is_adopted = 0", conn);
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
            p.Breed = reader.IsDBNull(1) ? null : Convert.ToString(reader["breed"]); 
            p.Age = reader.IsDBNull(2) ? null : Convert.ToString(reader["pet_age"]);
            p.Picture = reader.IsDBNull(4) ? null : Convert.ToString(reader["pet_image"]);
            //p.IsAdopted = Convert.ToBoolean(reader["is_adopted"]);
            p.ArrivalDate = Convert.ToString(reader["arrival_date"]);
            //p.AdoptionDate= Convert.ToString(reader["adoption_date"]);
            //p.AdoptedBy = Convert.ToString(reader["adopted_by"]);

            return p;
        }

        public bool AddAPet(Pet petToAdd)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO pets (breed, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by )" +
                                                    "VALUES (@breed, @age, @name, @img, @isAdopted, @arrivalDate, @adoptionDate, @adoptedBy);", conn);
                    cmd.Parameters.AddWithValue("@breed", petToAdd.Breed);
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(petToAdd.Age));
                    cmd.Parameters.AddWithValue("@name", petToAdd.Name);
                    cmd.Parameters.AddWithValue("@img", petToAdd.Picture);
                    int adoptedBoolToInt = petToAdd.IsAdopted == false ? 0 : 1;
                    cmd.Parameters.AddWithValue("@isAdopted", adoptedBoolToInt);
                    cmd.Parameters.AddWithValue("@arrivalDate", petToAdd.ArrivalDate);
                    cmd.Parameters.AddWithValue("@adoptionDate", petToAdd.AdoptionDate);
                    cmd.Parameters.AddWithValue("@adoptedBy", petToAdd.AdoptedBy);
                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());
                   // cmd = new SqlCommand("SELECT MAX(pet_id) FROM pets", conn);
                    
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
       
    }
}

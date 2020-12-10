using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        public UserSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt, user_role FROM users WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUser;
        }


        public User AddUser(string username, string password, string role)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "INSERT INTO users (username, password_hash, salt, user_role) VALUES (@username, @password_hash, @salt, @user_role)",
                            conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.Parameters.AddWithValue("@user_role", role);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetUser(username);
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["user_role"]),
            };

            return u;
        }
        public Application GetApplicationsByUsername(string username)
        {
            Application returnApp = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT application_id, username, email, phone_number, prompt_response, first_name, last_name, status FROM applications WHERE username = @username AND status = 1", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnApp = GetApplicationFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnApp;
        }

        bool IUserDAO.AddApplication(Application app)
        {
            bool result = false;
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "INSERT INTO applications (username, email, phone_number, prompt_response, first_name, last_name, status) VALUES (@username, @email, @phone_number, @prompt_response, @first_name, @last_name, @status)",
                            conn);
                    cmd.Parameters.AddWithValue("@username", app.Username);
                    cmd.Parameters.AddWithValue("@email", app.Email);
                    cmd.Parameters.AddWithValue("@phone_number", app.Phone);
                    cmd.Parameters.AddWithValue("@prompt_response", app.PromptResponse);
                    cmd.Parameters.AddWithValue("@first_name", app.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", app.LastName);
                    cmd.Parameters.AddWithValue("@status", app.Status);
                    
                    rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        result = true;
                        
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return result;
        }
        private Application GetApplicationFromReader(SqlDataReader reader)
        {
            Application a = new Application()
            {
                ApplicationId = Convert.ToInt32(reader["application_id"]),
                Username = Convert.ToString(reader["username"]),
                Email = Convert.ToString(reader["email"]),
                Phone = Convert.ToString(reader["phone_number"]),
                PromptResponse = Convert.ToString(reader["prompt_response"]),
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
                Status = Convert.ToInt32(reader["status"])
            };

            return a;
        }
    }
}

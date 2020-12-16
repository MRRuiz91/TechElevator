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

                    SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt, user_role, first_name, last_name, email, phone_number, is_first_login FROM users WHERE username = @username", conn);
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
            ApplicationSqlDAO appDao = new ApplicationSqlDAO(connectionString);
            Application a = appDao.GetApplicationsByUsername(username);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "INSERT INTO users (username, password_hash, salt, user_role, first_name, last_name, email, phone_number, is_first_login) " +
                            " VALUES (@username, @password_hash, @salt, @user_role, @first_name, @last_name, @email, @phone_number, 1)",
                            conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.Parameters.AddWithValue("@user_role", role);
                    cmd.Parameters.AddWithValue("@first_name", a.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", a.LastName);
                    cmd.Parameters.AddWithValue("@email", a.Email);
                    cmd.Parameters.AddWithValue("@phone_number", a.Phone);
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
                FirstName = reader.IsDBNull(5) ? "" : Convert.ToString(reader["first_name"]),
                LastName = reader.IsDBNull(6) ? "" : Convert.ToString(reader["last_name"]),
                Email = reader.IsDBNull(7) ? "" : Convert.ToString(reader["email"]),
                Phone = reader.IsDBNull(8) ? "" : Convert.ToString(reader["phone_number"]),
                IsFirstLogin = reader.IsDBNull(9) ? false : Convert.ToBoolean(reader["is_first_login"])
            };

            return u;
        }
        public int GetUserIdFromUsername(string username)
        {
            int userId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT user_id FROM users WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    //SqlDataReader reader = cmd.ExecuteReader();

                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return userId;
        }

        public bool UpdateUserLoginStatus(string username)
        {
            bool success = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE users SET is_first_login = 0 WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    success = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return success;

        }

        public int GetNewestUserId()
        {
            int newUserId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MAX(user_id) from users", conn);
                    newUserId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return newUserId;

        }

        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt, user_role, first_name, last_name, email, phone_number, is_first_login FROM users", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = GetUserFromReader(reader);
                        allUsers.Add(user);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return allUsers;
        }

        public bool UpdatePassword(LoginUser user)
        {
            bool success = false;
            PasswordHasher pwHash = new PasswordHasher();
            PasswordHash newHash = pwHash.ComputeHash(user.Password);
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE users SET password_hash=@hash, salt = @salt WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@hash", newHash.Password);
                    cmd.Parameters.AddWithValue("@salt", newHash.Salt);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    success = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return success;
        }
        /*        public PasswordHash ComputeHash(string plainTextPassword)
        {
            //Create the hashing provider
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(plainTextPassword, 8, WorkFactor);

            //Get the Hashed Password
            byte[] hash = rfc.GetBytes(20);

            //Set the SaltValue
            string salt = Convert.ToBase64String(rfc.Salt);

            //Return the Hashed Password
            return new PasswordHash(Convert.ToBase64String(hash), salt);
        }*/
    }
}

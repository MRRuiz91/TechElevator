using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class ApplicationSqlDAO:IApplicationDAO
    {
        private readonly string connectionString;
        public ApplicationSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Application GetApplicationsByUsername(string username)
        {
            Application returnApp = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT application_id, username, email, phone_number, prompt_response, first_name, last_name, status " +
                                                    "FROM applications WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnApp = GetApplicationFromReader(reader);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }

            return returnApp;
        }
        public int GetNewestApplicationId()
        {
            int newAppId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MAX(application_id) from applications", conn);
                    newAppId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return newAppId;
        }
        public List<Application> GetPendingApplications()
        {
            List<Application> returnApps = new List<Application>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT application_id, username, email, phone_number, prompt_response, first_name, last_name, status " +
                                                    "FROM applications WHERE status = 1", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Application pendingApp = GetApplicationFromReader(reader);
                        returnApps.Add(pendingApp);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return returnApps;
        }

        public bool AddApplication(Application app)
        {
            bool result = false;
            int rowsAffected = 0;
            if (GetApplicationsByUsername(app.Username)==null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd =
                            new SqlCommand(
                                "INSERT INTO applications (username, email, phone_number, prompt_response, first_name, last_name, status) VALUES " +
                                "(@username, @email, @phone_number, @prompt_response, @first_name, @last_name, @status)",
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

        public ReturnUser ApproveVolunteerApplication(MiniApp app)
        {
            ReturnUser returned = new ReturnUser();
            UserSqlDAO u = new UserSqlDAO(connectionString);
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "UPDATE applications SET status=2 WHERE application_id = @app_id", conn);
                    cmd.Parameters.AddWithValue("@app_id", app.ApplicationId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            u.AddUser(app.Username, "password123", "user");
            returned.Username = app.Username;
            returned.Role = "user";
            returned.UserId = u.GetUserIdFromUsername(app.Username);
            return returned;
        }
        public bool RejectVolunteerApplication(MiniApp appToUpdate)
        {
            bool result = false;
            int rowsAffected = 0;
            ReturnUser returned = new ReturnUser();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE applications SET status=3 WHERE application_id = @app_id", conn);
                    cmd.Parameters.AddWithValue("@app_id", appToUpdate.ApplicationId);
                    rowsAffected=cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
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

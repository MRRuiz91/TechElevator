using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Transactions;

namespace CapstoneTests.DAL
{
    public class ApplicationDAOTests
    {
        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=Final_Capstone;Trusted_Connection=True;";
        private TransactionScope transaction;
        protected int NewApplicationID { get; private set; }
        [TestInitialize]
        public void Setup()
        {
            // Begin the transaction
            transaction = new TransactionScope();

            // Get the SQL Script to run
            string sql = File.ReadAllText("test-script.sql");

            // Execute the script
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // If there is a row to read
                if (reader.Read())
                {
                    this.NewApplicationID = Convert.ToInt32(reader["application_id"]);
                }
            }

        }
        [TestCleanup]
        public void Cleanup()
        {
            // Roll back the transaction
            transaction.Dispose();

        }

        /// <summary>
        /// Gets the row count for a table.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        //protected int GetRowCount(string table)
        //{
        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
        //        int count = Convert.ToInt32(cmd.ExecuteScalar());
        //        return count;
        //    }
        //}
    }
}


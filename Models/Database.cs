﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace mentorMentee.Models
{
    public static class Database
    {
        private static string connectionString = "Server=tcp:mentor-mentee.database.windows.net,1433;Initial Catalog=mentorMentee_DB;Persist Security Info=False;User ID=mentor_mentee;Password=(MSAD12345);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //TEST CONNECTION
        public static async Task<bool> TestConnectionAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        
        //TEST TO INSERT DATA
        public static async Task<bool> InsertDataAsync(string dataToInsert)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO TestTable (TestData) VALUES (@TestData)";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@TestData", dataToInsert);

                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}

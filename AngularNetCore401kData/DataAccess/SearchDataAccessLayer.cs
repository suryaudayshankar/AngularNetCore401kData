using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection.PortableExecutable;


namespace AngularNetCore401kData.DataAccess
{
    public class SearchDataAccessLayer
    {
        private readonly string _connectionString;

        public SearchDataAccessLayer()
        {
            if (Program.RasConnectionString != null) _connectionString = Program.RasConnectionString;
        }

        public List<string> GetStates(string country)
        {
            /*var states = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Select DISTINCT Cst_StName as STATES FROM USCensus_State", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            states.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return states;*/

            var states = new List<string>();
            SqlDataReader reader;
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("exec dt_CNB_GetStatesAndProvinces '" + country + "'");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    states.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
            }


            return states;
        }
    }

}

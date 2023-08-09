using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace AngularNetCore401kData.DataAccess
{
    public class SearchDataAccessLayer
    {
        private readonly string _connectionString;

        public SearchDataAccessLayer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("RasConnection");
        }

        public List<string> GetStates(string country)
        {
            var states = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT StateName FROM States WHERE Country = @country", connection))
                {
                    command.Parameters.AddWithValue("@country", country);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            states.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return states;
        }
    }

}

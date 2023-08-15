using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection.PortableExecutable;
using System.Data;
using AngularNetCore401kData.Models;

namespace AngularNetCore401kData.DataAccess
{
    public class SearchDataAccessLayer
    {
        private readonly string _connectionString;

        public SearchDataAccessLayer()
        {
            if (Program.ConnectionString != null) _connectionString = Program.ConnectionString;
        }

        public List<string> GetStates(string country)
        {
            var states = new List<string>();
            SqlDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    /* using (SqlCommand command = new SqlCommand("exec dt_CNB_GetStatesAndProvinces '" + country + "'", connection)) 
                     {
                         reader = command.ExecuteReader();
                         while (reader.Read())
                         {
                             states.Add(reader.GetString(0));
                         }
                     }*/

                    // Create a command for the stored procedure
                    SqlCommand command = new SqlCommand("dt_CNB_GetStatesAndProvinces", connection);

                    // Specify that the command is a stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the country parameter
                    command.Parameters.AddWithValue("@country", country);

                    // Execute the command
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        states.Add(reader.GetString(0));
                    }
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


        public List<string> GetCounties(string state)
        {
            var counties = new List<string>();
            SqlDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("exec dt_CNB_GetCountyList '" + state + "'", connection))
                    {
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            counties.Add(reader.GetString(1));
                        }
                    }

                    /* // Create a command for the stored procedure
                     SqlCommand command = new SqlCommand("exec dt_CNB_GetCountyList", connection);

                     command.CommandType = CommandType.StoredProcedure;                 
                     command.Parameters.AddWithValue("@state", state);

                     reader = command.ExecuteReader();

                     while (reader.Read())
                     {
                         counties.Add(reader.GetString(1));
                     }*/
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

            return counties;

        }

        public List<string> GetResults(SearchCriteria criteria)
        {
            var results = new List<string>();
            SqlDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(" Select distinct lcl_ID  From (SELECT *, 0.000000 as Zip_Lat, 0.000000 as Zip_Long FROM v_CNB_lc_frmCnb_Search)" + GetSqlCriteria(criteria), connection))
                    {
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            results.Add(reader.GetString(0));
                        }
                    }

                  
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

            return results;
        }

      

        private string GetSqlCriteria(SearchCriteria criteria)
        {
            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(criteria.Country))
            {
                conditions.Add($"Country='{criteria.Country}'");
            }

            if (!string.IsNullOrEmpty(criteria.State))
            {
                conditions.Add($"St_Code='{criteria.State}'");
            }

            if (!string.IsNullOrEmpty(criteria.County))
            {
                conditions.Add($"County LIKE '{criteria.County}%'");
            }

            if (!string.IsNullOrEmpty(criteria.City))
            {
                conditions.Add($"Zip_City LIKE '{criteria.City}%'");
            }

            if (!string.IsNullOrEmpty(criteria.PostalCode))
            {
                conditions.Add($"Zip_Code='{criteria.PostalCode}'");
            }

            if (criteria.Local != null && criteria.Local.Any())
            {
                string localList = string.Join(",", criteria.Local);
                conditions.Add($"Lcl_ID IN({localList})");
            }

            string where = conditions.Any() ? "WHERE " + string.Join(" AND ", conditions) : string.Empty;

            return $"{A where} Option (MaxDOP 1)";
        }

    }
    
}

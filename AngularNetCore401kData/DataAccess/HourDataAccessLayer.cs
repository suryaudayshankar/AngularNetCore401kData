using AngularNetCore401kData.Interfaces;
using AngularNetCore401kData.Models;
using System.Data;
using System.Data.SqlClient;

namespace AngularNetCore401kData.DataAccess
{
    public class HourDataAccessLayer : IHour
    {
        private readonly string? _connectionString;
        private readonly string? _rasConnection;
        
        //public HourDataAccessLayer(IConfiguration configuration)
        //{
        //    _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        //    _rasConnection = configuration["ConnectionStrings:RasConnection"];
        //}
        public HourDataAccessLayer()
        {
            if (Program.ConnectionString != null) _connectionString = Program.ConnectionString;
            
            if (Program.RasConnectionString != null) _rasConnection = Program.RasConnectionString;
        }
        

        //To View all employees details
        //public IEnumerable<HourGrid> GetPotentialHours(string employerAccount, DateOnly workMonth, int reportId)
        //{
        //       try
        //       {
        //           List<HourGrid> listHours = new();

        //           using var con = new SqlConnection(_connectionString);


        //           var cmd = new SqlCommand("dt_ad_K401_ang_GetPotentialData", con)
        //           {
        //               CommandType = CommandType.StoredProcedure
                  
        //           };
        //           cmd.Parameters.AddWithValue("@Mhrs_Rpt_ID", reportId);
        //           cmd.Parameters.AddWithValue("@Mhrs_WorkDate", workMonth);
        //           cmd.Parameters.AddWithValue("@Emp_Acct", employerAccount);

        //           con.Open();
        //           var reader = cmd.ExecuteReader();


        //           while (reader.Read())
        //           {
        //               var hourGrid = new HourGrid();
        //               {
        //                  hourGrid.HoursID = reader.GetInt32(0);
        //                   hourGrid.Selected = reader.GetBoolean(1);
        //                   hourGrid.MemberName = reader.GetString(2);
        //                   hourGrid.Mbr_PrimarySSN = reader.GetString(3);
        //                   hourGrid.Mhrs_Hours = reader.GetDecimal(4);
        //               }


        //               listHours.Add(hourGrid);
        //           }



        //           con.Close();
        //           return listHours;
        //       }
        //       catch
        //       {
        //           throw;
        //       }
        //}


        public IEnumerable<Hour> Get( int reportId)
        { //5710834 called from controller
            try
            {
                List<Hour> listHours = new();

                using var con = new SqlConnection(_rasConnection);


                var cmd = new SqlCommand("dt_ad_K401_ang_GetPotentialData", con)
                {
                    CommandType = CommandType.StoredProcedure
                  
                };
               
                cmd.Parameters.AddWithValue("@Emp_Acct", DBNull.Value);
                cmd.Parameters.AddWithValue("@Mhrs_WorkDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@Mhrs_Rpt_ID", reportId);
            
                
                con.Open();
                var reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    var hour = new Hour();
                    {
                      
                        
                       
                        
                        hour.isChecked = false;
                        hour.memberName = reader.GetString(1);
                        hour.ssn = reader.GetString(2);
                        hour.kHours = reader.GetDecimal(3);
                        hour.kAmount = reader.GetDecimal(4);
                        hour.flex = reader.GetDecimal(5);
                        hour.fullLocal = reader.GetString(6);
                        hour.workDate = reader.GetDateTime(7);
                        hour.kRate = reader.GetDecimal(8);
                        hour.flexRate = reader.GetDecimal(9);
                        hour.entryDate = reader.GetDateTime(10);
                        hour.empAccountNum = reader.GetString(11);
                        hour.empId = reader.GetInt32(12);
                        hour.mhrsId = reader.GetInt32(13);
                        hour.mbrId = reader.GetInt32(14);


                    }

                    listHours.Add(hour);
                }



                con.Close();
                return listHours;
            }


            catch
            {
                throw;
            }
        }
          public IEnumerable<Hour> Get(string employerAccount, string workMonth)
        {
            try
            {
                List<Hour> listHours = new();

                using var con = new SqlConnection(_rasConnection);


                var cmd = new SqlCommand("dt_ad_K401_ang_GetPotentialData", con)
                {
                    CommandType = CommandType.StoredProcedure
                  
                };
                
                
                cmd.Parameters.AddWithValue("@Emp_Acct", employerAccount);
                cmd.Parameters.AddWithValue("@Mhrs_WorkDate", workMonth);
                cmd.Parameters.AddWithValue("@Mhrs_Rpt_ID", 0);

               
                
                con.Open();
                var reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    var hour = new Hour();
                    {
                        hour.isChecked = false;
                        hour.memberName = reader.GetString(1);
                        hour.ssn = reader.GetString(2);
                        hour.kHours = reader.GetDecimal(3);
                        hour.kAmount = reader.GetDecimal(4);
                        hour.flex = reader.GetDecimal(5);
                        hour.fullLocal = reader.GetString(6);
                        hour.workDate = reader.GetDateTime(7);
                        hour.kRate = reader.GetDecimal(8);
                        hour.flexRate = reader.GetDecimal(9);
                        hour.entryDate = reader.GetDateTime(10);
                        hour.empAccountNum = reader.GetString(11);
                        hour.empId = reader.GetInt32(12);
                        hour.mhrsId = reader.GetInt32(13);
                        hour.mbrId = reader.GetInt32(14);

                    }

 







                    listHours.Add(hour);
                }



                con.Close();
                return listHours;
            }


            catch
            {
                throw;
            }
        }



    public IEnumerable<Hour> GetAllHours(string reportNumber)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Hour> GetAllHours(string employerAccount, DateOnly workMonth)
    {
        throw new NotImplementedException();
    }

    Hour IHour.GetHourData(int id)
    {
        throw new NotImplementedException();
    }








    //To Add new employee record 
    public int AddHour(Hour hour)
        {
            try
            {
                using var con = new SqlConnection(_connectionString);
                var cmd = new SqlCommand("spAddEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                //cmd.Parameters.AddWithValue("@Name", employee.Name);
                //cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                //cmd.Parameters.AddWithValue("@Department", employee.Department);
                //cmd.Parameters.AddWithValue("@City", employee.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch
            {
                throw;
            }
        }

         
        public int UpdateHour(Hour hours)
        {
            try
            {
                using var con = new SqlConnection(_connectionString);
                var sqlCommand = new SqlCommand("spUpdateEmployee");
                using (var cmd = sqlCommand)
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@EmpId", employee.EmployeeId);
                    //cmd.Parameters.AddWithValue("@Name", employee.Name);
                    //cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    //cmd.Parameters.AddWithValue("@Department", employee.Department);
                    //cmd.Parameters.AddWithValue("@City", employee.City);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                return 1;
            }
            catch
            {
                throw;
            }
        }
 
        public Hour GetHourData(int id)
        {
            try
            {
                var hour = new Hour();

                using var con = new SqlConnection(_connectionString);
                var sqlQuery = "SELECT * FROM tblHours WHERE HoursID= " + id;
                var cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //employee.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                    //employee.Name = rdr["Name"].ToString();
                    //employee.Gender = rdr["Gender"].ToString();
                    //employee.Department = rdr["Department"].ToString();
                    //employee.City = rdr["City"].ToString();
                }

                return hour;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular employee
        public int DeleteHour(int id)
        {
            try
            {
                using SqlConnection con = new SqlConnection(_connectionString);
                var cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@HoursID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch
            {
                throw;
            }
        }


        //public List<City> GetCities()
        //{
        //    try
        //    {
        //        List<City> lstCity = new List<City>();

        //        using SqlConnection con = new SqlConnection(_connectionString);
        //        SqlCommand cmd = new SqlCommand("spGetCityList", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        con.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            City city = new City();

        //            city.CityId= Convert.ToInt32(rdr["CityID"]);
        //            city.CityName = rdr["CityName"].ToString();
        //            lstCity.Add(city);
        //        }
        //        con.Close();
        //        return lstCity;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}

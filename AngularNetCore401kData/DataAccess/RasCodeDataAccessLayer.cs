//using AngularNetCore401kData.Interfaces;
using AngularNetCore401kData.Models;
using System.Data;
using System.Data.SqlClient;
using AngularNetCore401kData.Interfaces;

namespace AngularNetCore401kData.DataAccess
{
    //https://www.learnrxjs.io/learn-rxjs/operators/transformation/partition

    public class RasCodeDataAccessLayer: IRasCode
    {
       private readonly string? _connectionString;
        private readonly string? _rasConnection;


        public RasCodeDataAccessLayer()
        {
             if (Program.ConnectionString != null) _connectionString = Program.ConnectionString;
            
            if (Program.RasConnectionString != null) _rasConnection = Program.RasConnectionString;
        }


        public IEnumerable <RasSelectCode> Get( string codeType)
        {
           
            try
            {
                List<RasSelectCode> listCodes = new();

                using var con = new SqlConnection(_rasConnection);
                var cmd = new SqlCommand("dt_ad_K401_ang_GetCodes", con)

                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@List", codeType);
            
                con.Open();
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    var code = new RasSelectCode();
                    {
                        code.codeId = reader.GetInt32(0);
                        code.codeType = reader.GetString(1);
                        code.codeValue = reader.GetString(2);
                        code.codeDescription = reader.GetString(3);

                    }

                    listCodes.Add(code);
                }

                con.Close();
                return listCodes;
            }
            catch
            {
                throw;
            }
        }

    }
}

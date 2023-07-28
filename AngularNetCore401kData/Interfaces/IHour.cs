using AngularNetCore401kData.Models;

namespace AngularNetCore401kData.Interfaces
{
    public interface IHour
    {

        //IEnumerable<HourGrid> GetPotentialHours(string employerAccount, DateOnly workMonth, int reportId);
        //IEnumerable<Hour> GetAllHours(int id);
        //IEnumerable<Hour> GetAllHours(string reportNumber);
         IEnumerable<Hour> Get(string employerAccount, string workMonth);
         IEnumerable<Hour> Get( int reportId);
        int AddHour(Hour hour);
        int UpdateHour(Hour hour);
        Hour GetHourData(int id);
        int DeleteHour(int id);
       // List<City> GetCities();
    }
}

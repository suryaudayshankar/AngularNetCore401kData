//using AngularNetCore401kData.DataAccess;
using AngularNetCore401kData.Interfaces;
using AngularNetCore401kData.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Configuration;
//using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularNetCore401kData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HourController : ControllerBase
    {
         private readonly IHour _tempHour;
        

        public HourController(IHour hourValue)
        {
            _tempHour = hourValue;
        }

        // [Route("Index/{employerAccount}/{workMonth}/{reportId}")]
        [HttpGet]
        [Route("Get/{id}")]
       public IEnumerable <Hour> Get(int id)
       {
           // id = 5710834;

             return _tempHour.Get( id);
        }




        [HttpGet]
        [Route("Get/{employerAccount}/{workMonth}")]
        public IEnumerable<Hour> GetByAccountWorkMonth(string employerAccount, string workMonth)
        {


            return _tempHour.Get(employerAccount,workMonth);
        }

        [HttpPost]
        [Route("Create")]
        public int Create([FromBody] Hour hour)
        {
            return _tempHour.AddHour(hour);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public Hour Details(int id)
        {
            return _tempHour.GetHourData(id);
        }

        [HttpPut]
        [Route("Edit")]
        public int Edit([FromBody]Hour hour)
        {
            return _tempHour.UpdateHour(hour);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            return _tempHour.DeleteHour(id);
        }

        //[HttpGet]
        //[Route("GetCityList")]
        //public IEnumerable<City> Details()
        //{
        //    return objemployee.GetCities();
        //}
    }
}

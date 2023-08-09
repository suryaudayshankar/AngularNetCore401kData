using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularNetCore401kData.Interfaces;
using AngularNetCore401kData.Models;
using Microsoft.AspNetCore.Cors;
using AngularNetCore401kData.DataAccess;

namespace AngularNetCore401kData.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]*/
    /*    [EnableCors("AllowSpecificOrigin")]*/
    /*public class StatesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string country)
        {
            // Replace with actual logic to get states for the given country from your database
            // You might use something like:
            // var states = _context.States.Where(s => s.Country == country).ToList();
            return new List<string> { "State 1", "State 2" };
        }
    }*/

    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : ControllerBase
    {
        private readonly SearchDataAccessLayer _searchDataAccessLayer;

        public StatesController(SearchDataAccessLayer searchDataAccessLayer)
        {
            _searchDataAccessLayer = searchDataAccessLayer;
        }

        [HttpGet]
        public IActionResult GetStates(string country)
        {
            var states = _searchDataAccessLayer.GetStates(country);
            return Ok(states);
        }
    }


    [Route("api/[controller]")]
    [ApiController]
 /*   [EnableCors("AllowSpecificOrigin")]*/
    public class CountiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string state)
        {
            // Replace with actual logic to get counties for the given state from your database
            // You might use something like:
            // var counties = _context.Counties.Where(c => c.State == state).ToList();
            return new List<string> { "County 1", "County 2" };
        }
    }
}


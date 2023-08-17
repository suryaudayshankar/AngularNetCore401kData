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
    [EnableCors("CorsPolicy")]

    public class SearchController : ControllerBase
    {
        private readonly SearchDataAccessLayer _searchDataAccessLayer;

        public SearchController(SearchDataAccessLayer searchDataAccessLayer)
        {
            _searchDataAccessLayer = searchDataAccessLayer;
        }

        [HttpGet]
        [Route("states/{country}")]
        public IActionResult GetStates(string country)
        {
            var states = _searchDataAccessLayer.GetStates(country);
            return Ok(states);
        }

        [HttpGet]
        [Route("counties/{state}")]
        
        public ActionResult<IEnumerable<string>> Get(string state)
        {
            var counties = _searchDataAccessLayer.GetCounties(state);
            return Ok(counties);
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Search([FromBody] SearchCriteria criteria)
        {
            var results = _searchDataAccessLayer.GetResults(criteria);
            return Ok(results);
        }

    }
}



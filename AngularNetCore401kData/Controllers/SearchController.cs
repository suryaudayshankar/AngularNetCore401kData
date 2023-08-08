using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularNetCore401kData.Interfaces;
using AngularNetCore401kData.Models;

namespace AngularNetCore401kData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string country)
        {
            // Replace with actual logic to get states for the given country from your database
            // You might use something like:
            // var states = _context.States.Where(s => s.Country == country).ToList();
            return new List<string> { "State 1", "State 2" };
        }
    }

    [Route("api/[controller]")]
    [ApiController]
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


using AngularNetCore401kData.Interfaces;
using AngularNetCore401kData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularNetCore401kData.Controllers;
[Route("[controller]")]
[ApiController]
public class CodeController : ControllerBase
{
    //make sure to add to proxy.conf.js
    //context: [
    //"/hour",
    //"/code"
   
    private readonly IRasCode _tempCode;
    //private readonly HourDataAccessLayer _tempHour = new();

    public CodeController(IRasCode rasCode)
    {
        _tempCode = rasCode;
    }

    [HttpGet]
    [Route("Get/{codeValue}")]
    public IEnumerable <RasSelectCode> Get(string codeValue)
    {
        return _tempCode.Get(codeValue);
    }


}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TwitterBackEnd.Data;

namespace TwitterBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Backend is aan het draaien...";
        }

        
    }
}

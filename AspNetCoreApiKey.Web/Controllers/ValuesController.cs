using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApiKey.Web.Filters;
using AspNetCoreApiKey.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApiKey.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeApiKey]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        //[ServiceFilter(typeof(AuthorizeApiKeyWithDIAttribute))]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

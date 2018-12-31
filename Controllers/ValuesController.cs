using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWithSecurity.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Value> Get()
        {
            return new Value[] { new Value { Id = 1, Title = "Toast is great" }, new Value { Id = 2, Title = "Use Vegemite" } };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Value> Get(int id)
        {
            return new Value { Id = id, Title = $"value {id}" };
        }

        // POST api/values
        [HttpPost]
        [Produces(typeof(Value))]
        public ActionResult Post([FromBody] Value value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { id = value.Id }, value);
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
    public class Value
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}

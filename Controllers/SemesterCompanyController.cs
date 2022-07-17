using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterCompanyController : ControllerBase
    {
        // GET: api/SemesterCompany
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // POST: api/SemesterCompany
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SemesterCompany/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/SemesterCompany/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestConnection3.DBContexts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestConnection3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyDBContext _context;

        public StudentController(MyDBContext dBContext)
        {
            _context = dBContext;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Students.ToList());
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

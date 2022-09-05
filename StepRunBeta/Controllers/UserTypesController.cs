using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using StepRunBeta.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StepRun.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        // GET: api/<UserTypesController>
        [HttpGet]
        public IEnumerable<UserTypeApi> Get()
        {
            return dbContext.UserTypes.ToList().Select(s => (UserTypeApi)s);
        }

        private readonly RunBeta2Context dbContext;
        public UserTypesController(RunBeta2Context dbContext) 
        {
            this.dbContext = dbContext;
        }

        // GET api/<UserTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypeApi>> Get(int id)
        {
            var type = await dbContext.UserTypes.FindAsync(id);
            if (type == null)
                return NotFound();
            return Ok((UserTypeApi)type);
        }

        // POST api/<UserTypesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

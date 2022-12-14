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
        public async Task<ActionResult<long>> Post([FromBody] UserTypeApi typeApi)
        {
            var newType = (UserType)typeApi;
            await dbContext.UserTypes.AddAsync(newType);
            await dbContext.SaveChangesAsync();
            return Ok(newType.Id);
        }

        // PUT api/<UserTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] UserTypeApi typeApi)
        {
            var oldType = await dbContext.UserTypes.FindAsync(id);
            if (oldType == null)
                return NotFound();
            dbContext.Entry(oldType).CurrentValues.SetValues(typeApi);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<UserTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldType = await dbContext.UserTypes.FindAsync(id);
            if (oldType == null)
                return NotFound();
            dbContext.UserTypes.Remove(oldType);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

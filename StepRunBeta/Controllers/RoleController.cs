using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using StepRunBeta.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StepRunBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<RoleTypeApi> Get()
        {
            return dbContext.Roles.ToList().Select(s => (RoleTypeApi)s);
        }

        private readonly RunBeta2Context dbContext;
        public RoleController(RunBeta2Context dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleTypeApi>> Get(int id)
        {
            var type = await dbContext.Roles.FindAsync(id);
            if (type == null)
                return NotFound();
            return Ok((RoleTypeApi)type);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] RoleTypeApi typeApi)
        {
            var newType = (Role)typeApi;
            await dbContext.Roles.AddAsync(newType);
            await dbContext.SaveChangesAsync();
            return Ok(newType.Id);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] RoleTypeApi typeApi)
        {
            var oldType = await dbContext.Roles.FindAsync(id);
            if (oldType == null)
                return NotFound();
            dbContext.Entry(oldType).CurrentValues.SetValues(typeApi);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldType = await dbContext.Roles.FindAsync(id);
            if (oldType == null)
                return NotFound();
            dbContext.Roles.Remove(oldType);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

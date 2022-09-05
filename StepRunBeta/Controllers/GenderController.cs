using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using StepRunBeta.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StepRunBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        // GET: api/<GenderController>
        [HttpGet]
        public IEnumerable<GenderApi> Get()
        {
            return dbContext.Genders.ToList().Select(s => (GenderApi)s);
        }

        private readonly RunBeta2Context dbContext;
        public GenderController(RunBeta2Context dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET api/<GenderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenderApi>> Get(int id)
        {
            var type = await dbContext.Genders.FindAsync(id);
            if (type == null)
                return NotFound();
            return Ok((GenderApi)type);
        }

        // POST api/<GenderController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] GenderApi typeApi)
        {
            var newType = (Gender)typeApi;
            await dbContext.Genders.AddAsync(newType);
            await dbContext.SaveChangesAsync();
            return Ok(newType.Id);
        }

        // PUT api/<GenderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] GenderApi typeApi)
        {
            var oldType = await dbContext.Genders.FindAsync(id);
            if (oldType == null)
                return NotFound();
            dbContext.Entry(oldType).CurrentValues.SetValues(typeApi);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<GenderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldType = await dbContext.Genders.FindAsync(id);
            if (oldType == null)
                return NotFound();
            dbContext.Genders.Remove(oldType);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

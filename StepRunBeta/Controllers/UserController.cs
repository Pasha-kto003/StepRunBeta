using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using StepRunBeta.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StepRunBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RunBeta2Context dbContext;
        public UserController(RunBeta2Context dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<UserApi> Get()
        {
            return dbContext.Users.ToList().Select(s => {
                var passport = dbContext.Passports.FirstOrDefault(p => p.Id == s.PassportId);
                return CreateUserApi(s, passport);
            });
        }

        private UserApi CreateUserApi(User user, Passport passport)
        {
            var clientApi = (UserApi)user;
            clientApi.Passport = (PassportApi)passport;
            return clientApi;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserApi>> Get(long? id)
        {
            var client = await dbContext.Users.FindAsync(id);
            var passport = await dbContext.Passports.FindAsync(client.PassportId);
            return CreateUserApi(client, passport);
        }

        // POST api/<UserController>
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] UserApi userApi)
        {
            Passport passport = (Passport)userApi.Passport;
            await dbContext.Passports.AddAsync(passport);
            await dbContext.SaveChangesAsync();
            User newUser = (User)userApi;
            newUser.PassportId = passport.Id;
            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return Ok(newUser.Id);
        }

        // PUT api/<UserController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] UserApi userApi)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            Passport passport = (Passport)userApi.Passport;
            if (passport.Id == 0)
                return BadRequest("Неверный паспорт");
            User newClient = (User)userApi;
            dbContext.Entry(user).CurrentValues.SetValues(newClient);
            user.Passport = passport;
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<UserController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var oldUser = await dbContext.Users.FindAsync(id);
            if (oldUser == null)
                return NotFound();
            dbContext.Users.Remove(oldUser);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

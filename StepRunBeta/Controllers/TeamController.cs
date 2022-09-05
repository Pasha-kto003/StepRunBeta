using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using StepRunBeta.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StepRunBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        // GET: api/<TeamController>
        [HttpGet]
        public IEnumerable<TeamApi> Get()
        {
            return dbContext.Teams.ToList().Select(s =>
            {
                var users = dbContext.TeamUsers.Where(t => t.TeamId == s.Id).Select(t => (UserApi)t.User).ToList();
                var cross = dbContext.TeamUsers.FirstOrDefault(t => t.TeamId == s.Id);
                var roles = dbContext.TeamUsers.Where(t => t.RoleId == cross.RoleId).Select(t => (RoleTypeApi)t.Role).ToList();
                return CreateTeamApi(s, users, roles);
            });
        }

        private readonly RunBeta2Context dbContext;
        public TeamController(RunBeta2Context dbContext)
        {
            this.dbContext = dbContext;
        }

        private TeamApi CreateTeamApi(Team team, List<UserApi> users, List<RoleTypeApi> roles)
        {
            var result = (TeamApi)team;
            result.Users = users;
            result.Roles = roles;
            return result;
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamApi>> Get(long id)
        {
            var team = await dbContext.Teams.FindAsync(id);
            var user = dbContext.TeamUsers.Where(t => t.TeamId == id).Select(t => (UserApi)t.User).ToList();
            var cross = dbContext.TeamUsers.FirstOrDefault(t => t.TeamId == team.Id);
            var role = dbContext.TeamUsers.Where(t => t.RoleId == cross.RoleId).Select(t => (RoleTypeApi)t.Role).ToList();
            return CreateTeamApi(team, user, role);
        }

        // POST api/<TeamController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TeamApi newTeam)
        {
            foreach (var users in newTeam.Users)
                if (users.Id == 0)
                    return BadRequest($"{users.UserName} не существует");
            var team = (Team)newTeam;
            var role = new Role();
            await dbContext.Teams.AddAsync(team);
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync();
            await dbContext.TeamUsers.AddRangeAsync(newTeam.Users.Select(s => new TeamUser
            {
                TeamId = team.Id,
                UserId = s.Id,
                RoleId = role.Id
            }));
            await dbContext.SaveChangesAsync();
            return Ok(team.Id);
        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TeamApi editTeam)
        {
            foreach (var users in editTeam.Users)
                if (users.Id == 0)
                    return BadRequest($"Продукт {users.UserName} не существует");
            var team = (Team)editTeam;
            var role = new Role();
            var oldTeam = await dbContext.Teams.FindAsync(id);
            if (oldTeam == null)
                return NotFound();
            dbContext.Entry(oldTeam).CurrentValues.SetValues(team);
            var userRemove = dbContext.TeamUsers.Where(s => s.TeamId == id).ToList();
            dbContext.TeamUsers.RemoveRange(userRemove);
            await dbContext.TeamUsers.AddRangeAsync(editTeam.Users.Select(s => new TeamUser
            {
                TeamId = team.Id,
                UserId = s.Id,
                RoleId = role.Id
            }));
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var oldTeam = await dbContext.Teams.FindAsync(id);
            if (oldTeam == null)
            {
                return NotFound();
            }
            var users = dbContext.TeamUsers.Where(s => s.TeamId == id).ToList();
            dbContext.TeamUsers.RemoveRange(users);
            dbContext.Teams.Remove(oldTeam);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

using ModelsApi;

namespace StepRunBeta.DB
{
    public partial class Team
    {
        public static explicit operator TeamApi(Team team)
        {
            return new TeamApi
            {
                Id = team.Id,
                DateOfCreate = team.DateOfCreate,
                Description = team.Description,
                TeamName = team.TeamName,
                Logo = team.Logo,
                Private = team.Private
            };
        }

        public static explicit operator Team(TeamApi team)
        {
            return new Team
            {
                Id = team.Id,
                DateOfCreate = team.DateOfCreate,
                Description = team.Description,
                TeamName = team.TeamName,
                Logo = team.Logo,
                Private = team.Private
            };
        }
    }
}

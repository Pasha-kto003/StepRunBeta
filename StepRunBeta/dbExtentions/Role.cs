using ModelsApi;

namespace StepRunBeta.DB
{
    public partial class Role
    {
        public static explicit operator RoleTypeApi(Role role)
        {
            return new RoleTypeApi
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }

        public static explicit operator Role(RoleTypeApi role)
        {
            return new Role
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }
    }
}

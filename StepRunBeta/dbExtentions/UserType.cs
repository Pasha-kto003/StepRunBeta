using ModelsApi;

namespace StepRunBeta.DB
{
    public partial class UserType
    {
        public static explicit operator UserTypeApi(UserType userType)
        {
            return new UserTypeApi
            {
                Id = userType.Id,
                TypeName = userType.TypeName
            };
        }
        public static explicit operator UserType(UserTypeApi userType)
        {
            return new UserType
            {
                Id = userType.Id,
                TypeName = userType.TypeName
            };
        }
    }
}

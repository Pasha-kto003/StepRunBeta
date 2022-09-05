using ModelsApi;

namespace StepRunBeta.DB
{
    public partial class User
    {
        public static explicit operator UserApi(User user)
        {
            return new UserApi
            {
                Id = user.Id,
                Email = user.Email,
                PhotoScreen = user.PhotoScreen,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Password = user.Password,
                PassPortId = user.PassportId,
                UserName = user.Username,
                UserTypeId = user.UserTypeId,
                GenderId = user.GenderId,
                RoleId = user.RoleId,
                Telephone = user.Telephone
            };
        }

        public static explicit operator User(UserApi user)
        {
            return new User
            {
                Id = user.Id,
                Email = user.Email,
                PhotoScreen = user.PhotoScreen,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Password = user.Password,
                PassportId = user.PassPortId,
                Username = user.UserName,
                UserTypeId = user.UserTypeId,
                GenderId = user.GenderId,
                RoleId = user.RoleId,
                Telephone = user.Telephone
            };
        }
    }
}

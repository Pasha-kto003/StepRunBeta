namespace ModelsApi
{
    public class UserApi : ApiBaseType
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public DateTime? DateOfBirth { get; set; }
        public string? PhotoScreen { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public long? PassPortId { get; set; }
        public long? GenderId { get; set; }
        public long? UserTypeId { get; set; }
        public long? RoleId { get; set; }
        public PassportApi Passport { get; set; }
    }
}
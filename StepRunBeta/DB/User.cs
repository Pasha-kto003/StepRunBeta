using System;
using System.Collections.Generic;

namespace StepRunBeta.DB
{
    public partial class User
    {
        public long Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public string? Telephone { get; set; }
        public long? PassportId { get; set; }
        public string? PhotoScreen { get; set; }
        public long? UserTypeId { get; set; }
        public long? GenderId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long? RoleId { get; set; }

        public virtual Gender? Gender { get; set; }
        public virtual Passport? Passport { get; set; }
        public virtual Role? Role { get; set; }
        public virtual UserType? UserType { get; set; }
    }
}

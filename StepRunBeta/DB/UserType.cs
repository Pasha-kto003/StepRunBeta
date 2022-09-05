using System;
using System.Collections.Generic;

namespace StepRunBeta.DB
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}

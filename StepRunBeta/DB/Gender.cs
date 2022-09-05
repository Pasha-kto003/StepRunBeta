using System;
using System.Collections.Generic;

namespace StepRunBeta.DB
{
    public partial class Gender
    {
        public Gender()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string GenderName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}

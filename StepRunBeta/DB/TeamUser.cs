using System;
using System.Collections.Generic;

namespace StepRunBeta.DB
{
    public partial class TeamUser
    {
        public long UserId { get; set; }
        public long TeamId { get; set; }
        public long RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

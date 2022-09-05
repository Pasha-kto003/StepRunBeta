using System;
using System.Collections.Generic;

namespace StepRunBeta.DB
{
    public partial class Role
    {
        public long Id { get; set; }
        public string RoleName { get; set; } = null!;
    }
}

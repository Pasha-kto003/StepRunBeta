using System;
using System.Collections.Generic;

namespace StepRunBeta.DB
{
    public partial class Team
    {
        public long Id { get; set; }
        public string? TeamName { get; set; }
        public string? Logo { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public bool? Private { get; set; }
        public string? Description { get; set; }
    }
}

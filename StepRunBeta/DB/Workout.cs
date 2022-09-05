using System;
using System.Collections.Generic;

namespace StepRunBeta.DB
{
    public partial class Workout
    {
        public long Id { get; set; }
        public string WorkoutName { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace StepRunBeta.DB
{
    public partial class ExerciseWorkout
    {
        public long WorkoutId { get; set; }
        public long ExerciseId { get; set; }
        public long? PropertyId { get; set; }

        public virtual Exercise Exercise { get; set; } = null!;
        public virtual Property? Property { get; set; }
        public virtual Workout Workout { get; set; } = null!;
    }
}

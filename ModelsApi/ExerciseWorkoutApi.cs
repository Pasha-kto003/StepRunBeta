
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class ExerciseWorkoutApi : ApiBaseType
    {
        public long WorkoutId { get; set; }
        public long ExerciseId { get; set; }
        public long? PropertyId { get; set; }
    }
}

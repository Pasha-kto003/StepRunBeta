using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class WorkOutApi : ApiBaseType
    {
        public string WorkoutName { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}

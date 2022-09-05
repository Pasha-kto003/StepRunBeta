using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class TeamApi : ApiBaseType
    {
        public string TeamName { get; set; }
        public byte[] Logo { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string Description { get; set; }
        public bool? Private { get; set; }

    }
}

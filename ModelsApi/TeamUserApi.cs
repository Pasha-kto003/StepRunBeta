using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class TeamUserApi : ApiBaseType
    {
        public long? UserId { get; set; }
        public long? TeamId { get; set; }
        public long? RoleId { get; set; }

    }
}

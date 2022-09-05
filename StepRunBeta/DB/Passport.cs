using System;
using System.Collections.Generic;

namespace StepRunBeta.DB
{
    public partial class Passport
    {
        public Passport()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Series { get; set; } = null!;
        public string Number { get; set; } = null!;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

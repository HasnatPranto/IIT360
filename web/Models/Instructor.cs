using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Routine = new HashSet<Routine>();
        }

        public string InstructorId { get; set; }
        public string InstructorMail { get; set; }
        public string InstructorName { get; set; }

        public virtual ICollection<Routine> Routine { get; set; }
    }
}

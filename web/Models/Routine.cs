using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Routine
    {
        public int RoutineId { get; set; }
        public DateTime Date { get; set; }
        public string CourseCode { get; set; }
        public TimeSpan BeginTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Semester { get; set; }
        public string Dayname { get; set; }
        public string FkInstructorId { get; set; }
        public virtual Instructor FkInstructor { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            FacultyPublication = new HashSet<FacultyPublication>();
            ProjectScholarship = new HashSet<ProjectScholarship>();
            Research = new HashSet<Research>();
        }

        public string FacultyId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public string Links { get; set; }
        public string Status { get; set; }
        public string AboutMe { get; set; }
        public string Teachings { get; set; }
        public int? FkFacultyImage { get; set; }

        public virtual Image FkFacultyImageNavigation { get; set; }
        public virtual ICollection<FacultyPublication> FacultyPublication { get; set; }
        public virtual ICollection<ProjectScholarship> ProjectScholarship { get; set; }
        public virtual ICollection<Research> Research { get; set; }
    }
}

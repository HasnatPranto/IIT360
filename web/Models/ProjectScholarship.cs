using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class ProjectScholarship
    {
        public int ProjectId { get; set; }
        public string ProScholType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FkFacultyProject { get; set; }

        public virtual Faculty FkFacultyProjectNavigation { get; set; }
    }
}

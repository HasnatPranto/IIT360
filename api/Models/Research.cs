using System;
using System.Collections.Generic;

namespace IIT360_api.Models
{
    public partial class Research
    {
        public int ResearchId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FkFacultyResearch { get; set; }

        public virtual Faculty FkFacultyResearchNavigation { get; set; }
    }
}

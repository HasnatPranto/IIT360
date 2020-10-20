using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Academic
    {
        public Academic()
        {
            AcademicDocument = new HashSet<AcademicDocument>();
        }

        public int AcademicId { get; set; }
        public string AcademicSection { get; set; }
        public string Programs { get; set; }
        public string AcademicInfo { get; set; }
        public string AcademicAdmission { get; set; }

        public virtual ICollection<AcademicDocument> AcademicDocument { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Publication
    {
        public Publication()
        {
            FacultyPublication = new HashSet<FacultyPublication>();
            PublicationDocument = new HashSet<PublicationDocument>();
        }

        public int PublicationId { get; set; }
        public string Title { get; set; }
        public string PubType { get; set; }
        public int PubYear { get; set; }

        public virtual ICollection<FacultyPublication> FacultyPublication { get; set; }
        public virtual ICollection<PublicationDocument> PublicationDocument { get; set; }
    }
}

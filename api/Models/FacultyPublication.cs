using System;
using System.Collections.Generic;

namespace IIT360_api.Models
{
    public partial class FacultyPublication
    {
        public int FacPubId { get; set; }
        public string FkFacultyFacpub { get; set; }
        public int FkPublicationFacpub { get; set; }

        public virtual Faculty FkFacultyFacpubNavigation { get; set; }
        public virtual Publication FkPublicationFacpubNavigation { get; set; }
    }
}

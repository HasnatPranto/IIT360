using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class AcademicDocument
    {
        public int AcDocId { get; set; }
        public string Note { get; set; }
        public int FkAcademicAcdoc { get; set; }
        public int FkDocumentAcdoc { get; set; }

        public virtual Academic FkAcademicAcdocNavigation { get; set; }
        public virtual Document FkDocumentAcdocNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Document
    {
        public Document()
        {
            AcademicDocument = new HashSet<AcademicDocument>();
            Notice = new HashSet<Notice>();
            PublicationDocument = new HashSet<PublicationDocument>();
        }

        public int DocumentId { get; set; }
        public string PdfName { get; set; }
        public byte[] Pdf { get; set; }

        public virtual ICollection<AcademicDocument> AcademicDocument { get; set; }
        public virtual ICollection<Notice> Notice { get; set; }
        public virtual ICollection<PublicationDocument> PublicationDocument { get; set; }
    }
}

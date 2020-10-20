using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class PublicationDocument
    {
        public int PubDocId { get; set; }
        public int FkPublicationPubdoc { get; set; }
        public int FkDocumentPubdoc { get; set; }

        public virtual Document FkDocumentPubdocNavigation { get; set; }
        public virtual Publication FkPublicationPubdocNavigation { get; set; }
    }
}

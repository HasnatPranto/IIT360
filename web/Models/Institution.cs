using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Institution
    {
        public int InstitutionId { get; set; }
        public string InstHeader { get; set; }
        public string InstDescription { get; set; }
        public int FkInstImage { get; set; }

        public virtual Image FkInstImageNavigation { get; set; }
    }
}

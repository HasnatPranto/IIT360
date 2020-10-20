using System;
using System.Collections.Generic;

namespace IIT360_api.Models
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public string HeadingText { get; set; }
        public string DirectorName { get; set; }
        public string ActFrom { get; set; }
        public string ActTo { get; set; }
        public int RohTable { get; set; }
    }
}

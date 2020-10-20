using System;
using System.Collections.Generic;

namespace IIT360_api.Models
{
    public partial class Industry
    {
        public int IndustryId { get; set; }
        public sbyte Featured { get; set; }
        public string IndustryName { get; set; }
        public int IndIcon { get; set; }
        public string IndLink { get; set; }

        public virtual Image IndIconNavigation { get; set; }
    }
}

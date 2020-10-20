using System;
using System.Collections.Generic;

namespace IIT360_api.Models
{
    public partial class Staff
    {
        public int StaffsId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int FkStaffImage { get; set; }

        public virtual Image FkStaffImageNavigation { get; set; }
    }
}

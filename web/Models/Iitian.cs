using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Iitian
    {
        public string IitianName { get; set; }
        public string IitianMail { get; set; }
        public string SemesterCi { get; set; }
        public sbyte? Connected { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}

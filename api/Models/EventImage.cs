using System;
using System.Collections.Generic;

namespace IIT360_api.Models
{
    public partial class EventImage
    {
        public int IdeventImage { get; set; }
        public string Caption { get; set; }
        public int FkEventEvemge { get; set; }
        public int FkImageEvemge { get; set; }

        public virtual Event FkEventEvemgeNavigation { get; set; }
        public virtual Image FkImageEvemgeNavigation { get; set; }
    }
}

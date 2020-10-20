using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Event
    {
        public Event()
        {
            EventImage = new HashSet<EventImage>();
        }

        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Venue { get; set; }

        public virtual ICollection<EventImage> EventImage { get; set; }
    }
}

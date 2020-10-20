using System;
using System.Collections.Generic;

namespace IIT360_api.Models
{
    public partial class Achievement
    {
        public int AchievementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public string Venue { get; set; }
        public int FkAchievementImage { get; set; }
        public string ImageCaption { get; set; }

        public virtual Image FkAchievementImageNavigation { get; set; }
    }
}

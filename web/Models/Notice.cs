using System;
using System.Collections.Generic;

namespace IIT360_Web.Models
{
    public partial class Notice
    {
        public int NoticeId { get; set; }
        public string Title { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public int FkNoticeDocument { get; set; }

        public virtual Document FkNoticeDocumentNavigation { get; set; }
    }
}

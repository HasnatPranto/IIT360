using System;
using System.Collections.Generic;

namespace IIT360_api.Models
{
    public partial class Image
    {
        public Image()
        {
            Achievement = new HashSet<Achievement>();
            EventImage = new HashSet<EventImage>();
            Faculty = new HashSet<Faculty>();
            Industry = new HashSet<Industry>();
            Institution = new HashSet<Institution>();
            Staff = new HashSet<Staff>();
        }

        public int ImageId { get; set; }
        public byte[] Img { get; set; }
        public string ImgName { get; set; }

        public virtual ICollection<Achievement> Achievement { get; set; }
        public virtual ICollection<EventImage> EventImage { get; set; }
        public virtual ICollection<Faculty> Faculty { get; set; }
        public virtual ICollection<Industry> Industry { get; set; }
        public virtual ICollection<Institution> Institution { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}

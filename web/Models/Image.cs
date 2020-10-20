using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IIT360_Web.Models
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
        [Required]
        public byte[] Img { get; set; }
        [Required]
        public string ImgName { get; set; }
        public virtual ICollection<Achievement> Achievement { get; set; }
        public virtual ICollection<EventImage> EventImage { get; set; }
        public virtual ICollection<Faculty> Faculty { get; set; }
        public virtual ICollection<Industry> Industry { get; set; }
        public virtual ICollection<Institution> Institution { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}

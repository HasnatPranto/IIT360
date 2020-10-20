using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json;
using static IIT360_api.Controllers.RoutinesController;

namespace IIT360_api.Models
{

    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
    public partial class Routine
    {
        public int RoutineId { get; set; }

        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime Date { get; set; }
        public string CourseCode { get; set; }
        public TimeSpan BeginTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Semester { get; set; }
        public string Dayname { get; set; }
        public string FkInstructorId { get; set; }

        [JsonIgnore]
        public virtual Instructor FkInstructor { get; set; }

    }
}

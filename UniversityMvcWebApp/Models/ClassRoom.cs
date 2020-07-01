using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMvcWebApp.Models
{
    public class ClassRoom
    {

        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int DayId { get; set; }

        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public int Type { get; set; }
    }
}
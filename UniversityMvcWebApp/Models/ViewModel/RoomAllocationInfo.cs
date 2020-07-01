using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMvcWebApp.Models.ViewModel
{
    public class RoomAllocationInfo
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string RoomNo { get; set; }
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Type { get; set; }

        public string TotalSchedule { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMvcWebApp.Models.ViewModel
{
    public class CourseInfo
    {

        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string Semester { get; set; }
        public string CourseTeacherName { get; set; }
        public int DepartmentId { get; set; }
        public int Type { get; set; }


    }
}
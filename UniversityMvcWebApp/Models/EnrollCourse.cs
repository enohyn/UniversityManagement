using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace UniversityMvcWebApp.Models
{
    public class EnrollCourse
    {
        [Required]

        public int StudentId { get; set; }
        public string RegNo { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string DepartmentName { get; set; }
        [Required]

        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]

        [DataType(DataType.Date)]
        public string FullDate { get; set; }
        public int GradeId { get; set; }
       


        
    }
}
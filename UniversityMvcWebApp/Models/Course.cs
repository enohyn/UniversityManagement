using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace UniversityMvcWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input Course Code")]

        [MinLength(5, ErrorMessage = "Course Code Should be Minimum 5 Character")]

        public string Code { get; set; }
        [Required(ErrorMessage = "Please Input Course Name")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please Input Course Credit")]
        [Range(.5, 5)]
        public double Credit { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Select a Department Name")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select a Semester")]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        public int Type { get; set; }

        
    }
}
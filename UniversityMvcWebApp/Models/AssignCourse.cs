using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityMvcWebApp.Models
{
    public class AssignCourse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select a Department Name")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select a Teacher Name")]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        [Display(Name = "Credit Be Taken")]
        public double CreditBeTaken { get; set; }
        [Display(Name = "Credit Left")]
        public double CreditLeft { get; set; }
        [Required(ErrorMessage = "Please Select a Course Code")]
        [Display(Name = "Course Code")]
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]

        public string CourseName { get; set; }
        [Display(Name = "Course Credit")]

        public double CourseCredit { get; set; }
        

        public int Type { get; set; }

    }
}
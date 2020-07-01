using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityMvcWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please Enter Date")]

        [DataType(DataType.Date)]
        public string FullDate { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityMvcWebApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Input Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Input an Email")]
        [EmailAddress(ErrorMessage = "Please Provide a Valid E-mail Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Input a Contact Number")]
        public string ContactNo { get; set; }
        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Please Select a Teacher Designation")]
        public string DesignationId { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select a Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Provide Credit to be Taken")]
        public double CreditBeTaken { get; set; }
        public double CreditLeft { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityMvcWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Input Department Code")]
        [StringLength(7, ErrorMessage = "Your Department Code Should be Maximum 5 Character"), MinLength(2, ErrorMessage = "Your Department Code Should be Minimum 2 Character")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Input Department Name")]
        public string Name { get; set; }

    }
}
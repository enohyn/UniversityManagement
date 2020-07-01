using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Manager
{
    public class EnrollCourseManager
    {
        private EnrollCourseGateway aEnrollCourseGateway;

        public EnrollCourseManager()
        {
            aEnrollCourseGateway=new EnrollCourseGateway();
        }

        public string Save(EnrollCourse aAssignCourse)
        {
            if (aEnrollCourseGateway.IsExistsCourse(aAssignCourse))
            {
                return "Course Already Enrolled of That Student";
            }
            else
            {
                int rowAffect = aEnrollCourseGateway.Save(aAssignCourse);
                if (rowAffect == 1)
                {
                    return "Course Enrolled Succesfuly";
                }
                else
                {
                    return "Course Enrolled Failed";
                }
            }


            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Manager
{
    public class AssignCourseManager
    {
        private AssignCourseGateway aAssignCourseGateway;

        public AssignCourseManager()
        {
            aAssignCourseGateway=new AssignCourseGateway();
        }

        public string Save(AssignCourse aAssignCourse)
        {
            if (aAssignCourseGateway.IsExistsAssignCourse(aAssignCourse.CourseId))
            {
                return "Course had Assign Already";
            }
            else
            {
                int rowAffect = aAssignCourseGateway.Save(aAssignCourse);

                if (rowAffect == 1)
                {
                    return "Course Assign Successfuly";
                }
                else
                {
                    return "Course Assign Failed";
                }
            }
        }
    }
}
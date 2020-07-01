using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;
using UniversityMvcWebApp.Models.ViewModel;

namespace UniversityMvcWebApp.Manager
{
    public class CourseManager
    {
        private CourseGateway aCoursesGateway;

        public CourseManager()
        {
            aCoursesGateway=new CourseGateway();
        }

        public string Save(Course aCourse)
        {
            if (aCoursesGateway.IsExistsCourse(aCourse.Name))
            {
                return "Course Name Already Exist";
            }
            else
            {
                int rowAffect = aCoursesGateway.Save(aCourse);
                if (rowAffect == 1)
                {
                    return "Course Added Succesfuly";
                }
                else
                {
                    return "Course Added Failed";
                }
            }
        }

        public List<Course> GetAllCourseByDepartmentId(int departmentId)
        {
            return aCoursesGateway.GetAllCourseByDepartmentId(departmentId);
        }

        public Course GetACourseByCourseId(int courseId)
        {
            return aCoursesGateway.GetACourseByCourseId(courseId);
        }

        public void UpdateType(AssignCourse aAssignCourse)
        {
            aCoursesGateway.UpdateType(aAssignCourse);
        }

        public List<CourseInfo> GetAllCourseInfoByDepartmentId(int departmentId)
        {
            return aCoursesGateway.GetAllCourseInfoByDepartmentId(departmentId);

        }

        public List<Course> GetAllCourseByStudentId(int studentId)
        {
            return aCoursesGateway.GetAllCourseByStudentId(studentId);
        }
    }
}
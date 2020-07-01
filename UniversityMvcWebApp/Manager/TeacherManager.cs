using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;
using UniversityMvcWebApp.Models.ViewModel;

namespace UniversityMvcWebApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway aTeacherGateway;

        public TeacherManager()
        {
            aTeacherGateway=new TeacherGateway();
        }
        public string Save(Teacher aTeacher)
        {
            if (aTeacherGateway.IsExistsEmail(aTeacher.Email))
            {
                return "Email Already Exists";
            }
            else
            {
                int rowAffect = aTeacherGateway.Save(aTeacher);
                if (rowAffect==1)
                {
                    return "Teacher Saved Successfully";
                }
                else
                {
                    return "Teacher Saved Failed";
                    
                }
            }
        }




        public List<Teacher> GetAllTeacherByDepartmentId(int departmentId)
        {
            return aTeacherGateway.GetAllTeacherByDepartmentId(departmentId);
        }

        public Teacher GetATeacherByTeacherId(int teacherId)
        {
            return aTeacherGateway.GetATeacherByTeacherId(teacherId);
        }

        public void UpdateCreditLeft(AssignCourse aAssignCourse)
        {
            aTeacherGateway.UpdateCreditLeft(aAssignCourse);
        }

    }
}
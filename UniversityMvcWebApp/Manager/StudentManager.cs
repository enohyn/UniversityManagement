using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Manager
{
    public class StudentManager
    {
        private DepartmentManager aDepartmentManager;
        private StudentGateway aStudentGateway;
        public StudentManager()
        {
            aDepartmentManager=new DepartmentManager();
            aStudentGateway=new StudentGateway();
        }

        public int TotalStudentCountByDepartmentId(int departmentId)
        {
            return aStudentGateway.TotalStudentCountByDepartmentId(departmentId);
        }

        public string RegNoForAStudent(Student aStudent)
        {
            string DeptCode = aDepartmentManager.GetADepartmentCode(aStudent.DepartmentId);
            string FullD = aStudent.FullDate;
            string Year = FullD.Substring(6, 4);
            int totalCount = TotalStudentCountByDepartmentId(aStudent.DepartmentId)+1;
            string serialNo;

            if (totalCount >= 1 && totalCount < 10)
            {
                serialNo = "00" + totalCount;
            }
            else if (totalCount >= 10 && totalCount < 100)
            {
                serialNo = "0" + totalCount;
            }
            else
            {
                serialNo = totalCount.ToString();
            }

            return DeptCode + "-" + Year + "-" + serialNo;
        }

        public string Save(Student aStudent)
        {
            if (aStudentGateway.IsExistsEmail(aStudent.Email))
            {
                return "Email Already Exists";
            }
            else
            {
                int rowAffect = aStudentGateway.Save(aStudent);
                if (rowAffect == 1)
                {
                    return "Student Saved Successfully";
                }
                else
                {
                    return "Student Saved Failed";

                }
            }
        }


        public List<Student> GetAllStudent()
        {
            return aStudentGateway.GetAllStudent();
        }

        public List<Student> GetAllStudentRegNo()
        {
            return aStudentGateway.GetAllStudentRegNo();
        }
        public List<SelectListItem> GetAllStudentRegNoForDropdown()
        {
            List<Student> students = GetAllStudentRegNo();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Select RegNo--", Value = ""}
            };
            foreach (Student aStudent in students)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = aStudent.RegNo;
                selectListItem.Value = aStudent.Id.ToString();
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }

        public Student GetAStudentByStudentId(int studentId)
        {
            return aStudentGateway.GetAStudentByStudentId(studentId);
        }



    }
}
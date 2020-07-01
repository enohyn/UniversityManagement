using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Manager;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Controllers
{
    public class StudentController : Controller
    {
        private DepartmentManager aDepartmentManager;
        private StudentManager aStudentManager;
        private CourseManager aCourseManager;
        private EnrollCourseManager aEnrollCourseManager;
        public StudentController()
        {
            aDepartmentManager=new DepartmentManager();
            aStudentManager=new StudentManager();
            aCourseManager=new CourseManager();
            aEnrollCourseManager=new EnrollCourseManager();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartmentForDropdown();
            ViewBag.StudentList = aStudentManager.GetAllStudent();
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student aStudent)
        {
            aStudent.RegNo = aStudentManager.RegNoForAStudent(aStudent);
            ViewBag.Message = aStudentManager.Save(aStudent);
            ViewBag.Departments = aDepartmentManager.GetAllDepartmentForDropdown();
            ViewBag.StudentList = aStudentManager.GetAllStudent();
            return View();
        }
        [HttpGet]

        public ActionResult EnrollCourse()
        {
            ViewBag.RegNoList = aStudentManager.GetAllStudentRegNoForDropdown();
            return View();
        }

        public JsonResult GetAStudentByStudentId(int stuId)
        {
            Student aStudent = aStudentManager.GetAStudentByStudentId(stuId);
            return Json(aStudent);

        }
        public JsonResult GetAllCourseByStudentId(int stuId)
        {
            List<Course> courses = aCourseManager.GetAllCourseByStudentId(stuId);
            return Json(courses);

        }
        [HttpPost]

        public ActionResult EnrollCourse(EnrollCourse aCourse)
        {
           
            ViewBag.Message = aEnrollCourseManager.Save(aCourse);
            ViewBag.RegNoList = aStudentManager.GetAllStudentRegNoForDropdown();
            return View();
        }


    }
}
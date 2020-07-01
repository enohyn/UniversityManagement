using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Manager;
using UniversityMvcWebApp.Models;
using UniversityMvcWebApp.Models.ViewModel;

namespace UniversityMvcWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private DepartmentManager aDepartmentManager;
        private DesignationManager aDesignationManager;
        private TeacherManager aTeacherManager;
        private CourseManager aCourseManager;
        private AssignCourseManager aAssignCourseManager;
        public TeacherController()
        {
            aDepartmentManager=new DepartmentManager();
            aDesignationManager=new DesignationManager();
            aTeacherManager=new TeacherManager();
            aCourseManager=new CourseManager();
            aAssignCourseManager=new AssignCourseManager();
        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.DesignationList = aDesignationManager.GetAllDesignationForDropdown();
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Teacher aTeacher)
        {
            string message = aTeacherManager.Save(aTeacher);
            ViewBag.Message = message;
            ViewBag.DesignationList = aDesignationManager.GetAllDesignationForDropdown();
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            return View();
        }

        [HttpGet]
        public ActionResult AssignCourse()
        {
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            return View();

        }
        public JsonResult GetAllTeacherByDepartmentId(int deptId)
        {
            List<Teacher> teachers = aTeacherManager.GetAllTeacherByDepartmentId(deptId);
            return Json(teachers);

        }
        public JsonResult GetAllCourseByDepartmentId(int deptId)
        {
            List<Course> courses = aCourseManager.GetAllCourseByDepartmentId(deptId);
            return Json(courses);

        }
        public JsonResult GetATeacherByTeacherId(int teacherId)
        {
            Teacher aTeacher = aTeacherManager.GetATeacherByTeacherId(teacherId);
            return Json(aTeacher);

        }
        public JsonResult GetACourseByCourseId(int courseId)
        {
            Course aCourse = aCourseManager.GetACourseByCourseId(courseId);
            return Json(aCourse);

        }

        [HttpPost]

        
        public ActionResult AssignCourse(AssignCourse aCourse)
        {
            if (ModelState.IsValid)
            {
                aCourseManager.UpdateType(aCourse);
                aTeacherManager.UpdateCreditLeft(aCourse);
                ViewBag.Message = aAssignCourseManager.Save(aCourse);
                ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            }
            else
            {
                ViewBag.Message = "Please Field Correctly";
                ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();                
            }

            return View();
        }
    }

    
}
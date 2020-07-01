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
    public class CourseController : Controller
    {
        private SemesterManager aSemesterManager;
        private DepartmentManager aDepartmentManager;
        private CourseManager aCourseManager;
        public CourseController()
        {
            aSemesterManager=new SemesterManager();
            aDepartmentManager=new DepartmentManager();
            aCourseManager=new CourseManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            ViewBag.SemesterList = aSemesterManager.GetAllSemesterForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course aCourse)
        {
            string message = aCourseManager.Save(aCourse);
            ViewBag.Message = message;
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            ViewBag.SemesterList = aSemesterManager.GetAllSemesterForDropdown();
            return View();
        }

        public ActionResult ViewStatics()
        {
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            return View();
        }
        public JsonResult ViewCourseStatics(int deptId)
        {
            List<CourseInfo> courseList = aCourseManager.GetAllCourseInfoByDepartmentId(deptId);          
            return Json(courseList);
        }
    }
}
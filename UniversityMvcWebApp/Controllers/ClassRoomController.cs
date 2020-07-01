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
    public class ClassRoomController : Controller
    {
        private RoomManager aRoomManager;
        private DayManager aDayManager;
        private DepartmentManager aDepartmentManager;
        private CourseManager aCourseManager;
        private AllocateClassroomManager aAllocateClassroomManager;
        public ClassRoomController()
        {
            aRoomManager=new RoomManager();
            aDayManager=new DayManager();
            aDepartmentManager=new DepartmentManager();
            aCourseManager=new CourseManager();
            aAllocateClassroomManager=new AllocateClassroomManager();
        }

        [HttpGet]
        public ActionResult Allocate()
        {
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            ViewBag.DayList = aDayManager.GetAllDayForDropdown();
            ViewBag.RoomList = aRoomManager.GetAllRoomForDropdown();
            return View();
        }
        public JsonResult GetAllCourseByDepartmentId(int deptId)
        {
            List<Course> courses = aCourseManager.GetAllCourseByDepartmentId(deptId);
            return Json(courses);

        }

        [HttpPost]
        public ActionResult Allocate(ClassRoom aClassRoom)
        {
            ViewBag.Message = aAllocateClassroomManager.Save(aClassRoom);
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            ViewBag.DayList = aDayManager.GetAllDayForDropdown();
            ViewBag.RoomList = aRoomManager.GetAllRoomForDropdown();
            return View();
        }

        public ActionResult ViewClassSchedule(RoomAllocationInfo allocationInfo)
        {
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartmentForDropdown();
            return View();
        }

        public JsonResult GetAllRoomInfoByDepartmentId(int deptId)
        {
            List<RoomAllocationInfo> courses = aAllocateClassroomManager.GetAllRoomInfomartionByDepartmentId(deptId);
            return Json(courses);

        }
	}
}
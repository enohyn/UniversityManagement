using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Manager;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentManager aDepartmentManager;

        public DepartmentController()
        {
            aDepartmentManager=new DepartmentManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Department aDepartment)
        {
            if (ModelState.IsValid)
            {
                string message = aDepartmentManager.Save(aDepartment);
                ViewBag.Message = message;
            }
            else
            {
                ViewBag.Message = "Please Input Correctly";
                
            }
            return View();
        }
        public ActionResult ViewAll()
        {
            ViewBag.DepartmentList = aDepartmentManager.GetAllDepartment();
            return View();
        }

        

    }
}
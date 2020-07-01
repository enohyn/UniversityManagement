using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Manager
{
    public class SemesterManager
    {
        private SemesterGateway aSemesterGateway;

        public SemesterManager()
        {
            aSemesterGateway=new SemesterGateway();
            
        }
        public List<Semester> GetAllSemester()
        {
            return aSemesterGateway.GetAllSemester();
        }

        public List<SelectListItem> GetAllSemesterForDropdown()
        {
            List<Semester> semesterList = GetAllSemester();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Select Semester--", Value = ""}
            };
            foreach (Semester semester in semesterList)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = semester.Name;
                selectListItem.Value = semester.Id.ToString();
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }
    }
}
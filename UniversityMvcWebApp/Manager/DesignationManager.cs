using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Manager
{
    public class DesignationManager
    {
        private DesignationGateway aDesignationGateway;

        public DesignationManager()
        {
            aDesignationGateway=new DesignationGateway();
        }
        public List<Designation> GetAllDesignation()
        {
            return aDesignationGateway.GetAllDesignation();
        }

        public List<SelectListItem> GetAllDesignationForDropdown()
        {
            List<Designation> designationList = GetAllDesignation();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Select Designation--", Value = ""}
            };
            foreach (Designation designation in designationList)
            {
                SelectListItem aSelectListItem = new SelectListItem();
                aSelectListItem.Text = designation.DesignationName;
                aSelectListItem.Value = designation.Id.ToString();
                selectListItemList.Add(aSelectListItem);
            }
            return selectListItemList;
        }
    }
}
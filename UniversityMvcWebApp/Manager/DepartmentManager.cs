using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway aDepartmentGateway;

        public DepartmentManager()
        {
            aDepartmentGateway=new DepartmentGateway();
        }

        public string Save(Department aDepartment)
        {
            if (aDepartmentGateway.IsExistsDepartment(aDepartment.Name))
            {
                return "Department Name Already Exist";
            }
            else
            {
                int rowAffect = aDepartmentGateway.Save(aDepartment);
                if (rowAffect == 1)
                {
                    return "Department Added Succesfuly";
                }
                else
                {
                    return "Department Added Failed";
                }
            }
        }

        public List<Department> GetAllDepartment()
        {
            return aDepartmentGateway.GetAllDepartment();
        }
        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = GetAllDepartment();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Select Department--", Value = ""}
            };
            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = department.Name;
                selectListItem.Value = department.Id.ToString();
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }

        public string GetADepartmentCode(int departmentId)
        {
            return aDepartmentGateway.GetADepartmentCode(departmentId);
        }
    }
}
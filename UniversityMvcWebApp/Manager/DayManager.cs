using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Manager
{
    public class DayManager
    {
        private DayGateway aDayGateway;

        public DayManager()
        {
            aDayGateway=new DayGateway();
        }
        public List<Day> GetAllDay()
        {
            return aDayGateway.GetAllDay();
        }

        public List<SelectListItem> GetAllDayForDropdown()
        {
            List<Day> dayList = GetAllDay();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Select Day--", Value = ""}
            };
            foreach (Day aDay in dayList)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = aDay.Name;
                selectListItem.Value = aDay.Id.ToString();
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }
    }
}
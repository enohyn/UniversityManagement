using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Manager
{
    public class RoomManager
    {

        private RoomGateway aRoomGateway;

        public RoomManager()
        {
            aRoomGateway=new RoomGateway();
        }

        public List<Room> GetAllRoom()
        {
            return aRoomGateway.GetAllRoom();
        }

        public List<SelectListItem> GetAllRoomForDropdown()
        {
            List<Room> roomList = GetAllRoom();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Select Room--", Value = ""}
            };
            foreach (Room aRoom in roomList)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = aRoom.RoomNo;
                selectListItem.Value = aRoom.Id.ToString();
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }
    }
}
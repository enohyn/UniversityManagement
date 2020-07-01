using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;
using UniversityMvcWebApp.Models.ViewModel;

namespace UniversityMvcWebApp.Manager
{
    public class AllocateClassroomManager
    {
        private AllocateClassroomGateway aAllocateClassroomGateway;

        public AllocateClassroomManager()
        {
            aAllocateClassroomGateway=new AllocateClassroomGateway();
        }
        public int Save(ClassRoom aClassRoom)
        {
            return aAllocateClassroomGateway.Save(aClassRoom);
        }

        public List<RoomAllocationInfo> GetAllRoomInfoByDepartmentId(int departmentId)
        {
            return aAllocateClassroomGateway.GetAllRoomInfoByDepartmentId(departmentId);
        }

        public List<RoomAllocationInfo> GetAllRoomInfomartionByDepartmentId(int departmentId)
        {
            List<RoomAllocationInfo> roomAllocationList = GetAllRoomInfoByDepartmentId(departmentId);
            List<RoomAllocationInfo> roomAllocationReadyList = new List<RoomAllocationInfo>();
            foreach (RoomAllocationInfo allocationInfo in roomAllocationList)
            {
                if (roomAllocationReadyList.Count == 0)
                {
                    roomAllocationReadyList.Add(allocationInfo);

                }
                else
                {
                    foreach (RoomAllocationInfo aAllocation in roomAllocationReadyList.ToList())
                    {
                        if (aAllocation.CourseCode == allocationInfo.CourseCode)
                        {
                            aAllocation.TotalSchedule = allocationInfo.TotalSchedule +"---;;;;---" + aAllocation.TotalSchedule;
                        }
                        else
                        {
                            roomAllocationReadyList.Add(allocationInfo);
                        }
                    }
                }
            }
            return roomAllocationReadyList;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;
using UniversityMvcWebApp.Models.ViewModel;

namespace UniversityMvcWebApp.Gateway
{
    public class AllocateClassroomGateway : BaseClassGateway
    {
        public int Save(ClassRoom aClassRoom)
        {
            aClassRoom.Type = 1;
            string query = "INSERT INTO ClassRoomsAllocation(DepartmentId,CourseId,RoomId,DayId,StartTime,EndTime,Type) VALUES(@departmentId,@courseId,@roomId,@dayId,@startTime,@endTime,@type)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", aClassRoom.DepartmentId);
            command.Parameters.AddWithValue("@courseId", aClassRoom.CourseId);
            command.Parameters.AddWithValue("@roomId", aClassRoom.RoomId);
            command.Parameters.AddWithValue("@dayId", aClassRoom.DayId);
            command.Parameters.AddWithValue("@startTime", aClassRoom.FromTime);
            command.Parameters.AddWithValue("@endTime", aClassRoom.ToTime);

            command.Parameters.AddWithValue("@type", aClassRoom.Type);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }


        public List<RoomAllocationInfo> GetAllRoomInfoByDepartmentId(int departmentId)
        {

            string query = "SELECT * FROM RoomAllocationInfo WHERE DepartmentId=@depId AND Type=1 Order By Code ASC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@depId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();

            List<RoomAllocationInfo> roomList = new List<RoomAllocationInfo>();

            while (reader.Read())
            {
                RoomAllocationInfo aRoom = new RoomAllocationInfo();
                aRoom.CourseCode = (reader["Code"]).ToString();
                aRoom.CourseName = (reader["Name"]).ToString();
                aRoom.DepartmentName = (reader["DepartmentName"]).ToString();
                aRoom.RoomNo = (reader["RoomNo"]).ToString();
                aRoom.Day = (reader["Day"]).ToString();
                aRoom.StartTime = (reader["StartTime"]).ToString();
                aRoom.EndTime = (reader["EndTime"]).ToString();

                if ((reader["AssignType"]).ToString() == "1")
                {

                    aRoom.TotalSchedule = "Room No:" + aRoom.RoomNo + "," + aRoom.Day + "," + aRoom.StartTime + "-" +
                                          aRoom.EndTime;
                }
                else
                {
                    aRoom.TotalSchedule = "Not Scheduled Yet";
                }

                roomList.Add(aRoom);
            }
            connection.Close();
            return roomList;

        }
    }
}
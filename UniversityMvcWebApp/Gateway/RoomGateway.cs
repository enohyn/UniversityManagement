using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Gateway
{
    public class RoomGateway : BaseClassGateway
    {

        public List<Room> GetAllRoom()
        {
            command = new SqlCommand("SELECT * FROM Rooms", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Room> roomList = new List<Room>();

            while (reader.Read())
            {
                Room aRoom = new Room();
                aRoom.Id = Convert.ToInt32(reader["Id"]);
                aRoom.RoomNo = (reader["RoomNo"]).ToString();

                roomList.Add(aRoom);
            }
            connection.Close();
            return roomList;

        }
    }
}
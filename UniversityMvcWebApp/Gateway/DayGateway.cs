using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Gateway
{
    public class DayGateway : BaseClassGateway
    {
        public List<Day> GetAllDay()
        {
            command = new SqlCommand("SELECT * FROM Days", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Day> dayList = new List<Day>();

            while (reader.Read())
            {
                Day aDay = new Day();
                aDay.Id = Convert.ToInt32(reader["Id"]);
                aDay.Name = (reader["Day"]).ToString();

                dayList.Add(aDay);
            }
            connection.Close();
            return dayList;

        }
    }
}
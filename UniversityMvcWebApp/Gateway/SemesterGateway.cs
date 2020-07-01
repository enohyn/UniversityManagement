using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Gateway
{
    public class SemesterGateway : BaseClassGateway
    {
        public List<Semester> GetAllSemester()
        {
            command = new SqlCommand("SELECT * FROM Semesters", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Semester> semesterList = new List<Semester>();

            while (reader.Read())
            {
                Semester aSemester = new Semester();
                aSemester.Id = Convert.ToInt32(reader["Id"]);
                aSemester.Name = (reader["Name"]).ToString();

                semesterList.Add(aSemester);
            }
            connection.Close();
            return semesterList;

        }
    }
}
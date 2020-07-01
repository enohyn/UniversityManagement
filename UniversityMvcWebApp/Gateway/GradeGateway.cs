using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Gateway
{
    public class GradeGateway : BaseClassGateway
    {

        public List<Grade> GetAllGrade()
        {
            command = new SqlCommand("SELECT * FROM Semesters", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Grade> semesterList = new List<Grade>();

            while (reader.Read())
            {
                Grade aSemester = new Grade();
                aSemester.Id = Convert.ToInt32(reader["Id"]);
                aSemester.Name = (reader["Name"]).ToString();

                semesterList.Add(aSemester);
            }
            connection.Close();
            return semesterList;

        }
    }
}
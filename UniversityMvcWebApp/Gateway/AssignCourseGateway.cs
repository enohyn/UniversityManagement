using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Gateway
{
    public class AssignCourseGateway :BaseClassGateway
    {
        public int Save(AssignCourse aAssignCourse)
        {
            aAssignCourse.Type = 1;
            string query = "INSERT INTO AssignCourses(TeacherId,CourseId,Type) VALUES(@teacherId,@coureId,@type)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@teacherId", aAssignCourse.TeacherId);
            command.Parameters.AddWithValue("@coureId", aAssignCourse.CourseId);
            command.Parameters.AddWithValue("@type", aAssignCourse.Type);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsExistsAssignCourse(int aCourseId)
        {
            string query = "SELECT * FROM AssignCourses WHERE CourseId=@aId AND Type=1";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@aId", aCourseId);
            connection.Open();
            reader = command.ExecuteReader();
            bool hasRows = reader.HasRows;
            connection.Close();
            return hasRows;
        }

    }
}
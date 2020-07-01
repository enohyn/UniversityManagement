using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Gateway
{
    public class EnrollCourseGateway : BaseClassGateway
    {

        public int Save(EnrollCourse aAssignCourse)
        {
            aAssignCourse.GradeId = 0;
            string query = "INSERT INTO EnrollCourses(StudentId,CourseId,Date,GradeId) VALUES(@studentId,@coureId,@date,@gradeId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", aAssignCourse.StudentId);
            command.Parameters.AddWithValue("@coureId", aAssignCourse.CourseId);
            command.Parameters.AddWithValue("@date", aAssignCourse.FullDate);
            command.Parameters.AddWithValue("@gradeId", aAssignCourse.GradeId);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsExistsCourse(EnrollCourse aAssignCourse)
        {
            string query = "SELECT * FROM EnrollCourses WHERE StudentId=@aStuId AND CourseId=@aCourId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@aStuId", aAssignCourse.StudentId);
            command.Parameters.AddWithValue("@aCourId", aAssignCourse.CourseId);
            connection.Open();
            reader = command.ExecuteReader();
            bool hasRows = reader.HasRows;
            connection.Close();
            return hasRows;
        }
    }
}
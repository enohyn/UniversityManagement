using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;
using UniversityMvcWebApp.Models.ViewModel;

namespace UniversityMvcWebApp.Gateway
{
    public class CourseGateway : BaseClassGateway
    {
       
        public int Save(Course aCourse)
        {
            aCourse.Type = 0;
            string query = "INSERT INTO Courses(Code,Name,Credit,Description,DepartmentId,SemesterId,Type) VALUES(@code,@name,@credit,@description,@departmentId,@semesterId,@type)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@code", aCourse.Code);
            command.Parameters.AddWithValue("@name", aCourse.Name);
            command.Parameters.AddWithValue("@credit", aCourse.Credit);
            command.Parameters.AddWithValue("@description", aCourse.Description);
            command.Parameters.AddWithValue("@departmentId", aCourse.DepartmentId);
            command.Parameters.AddWithValue("@semesterId", aCourse.SemesterId);
            command.Parameters.AddWithValue("@type", aCourse.Type);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsExistsCourse(string aCourseName)
        {
            string query = "SELECT * FROM Courses WHERE Name=@aName";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@aName", aCourseName);
            connection.Open();
            reader = command.ExecuteReader();
            bool hasRows = reader.HasRows;
            connection.Close();
            return hasRows;
        }

        public List<Course> GetAllCourseByDepartmentId(int departmentId)
        {
            string query = "SELECT * FROM Courses WHERE DepartmentId=@depId Order By Code ASC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@depId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();

            List<Course> courseList = new List<Course>();

            while (reader.Read())
            {
                Course aCourse = new Course();
                aCourse.Id = Convert.ToInt32(reader["Id"]);
                aCourse.Code = (reader["Code"]).ToString();
                aCourse.Name = (reader["Name"]).ToString();

                courseList.Add(aCourse);
            }
            connection.Close();
            return courseList;

        }

        public Course GetACourseByCourseId(int courseId)
        {
            string query = "SELECT * FROM Courses WHERE Id=@courseId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courseId", courseId);
            connection.Open();
            reader = command.ExecuteReader();
            Course aCourse = null;
            while (reader.Read())
            {
                aCourse = new Course();
                aCourse.Name = reader["Name"].ToString();
                aCourse.Credit = Convert.ToDouble(reader["Credit"]);

            }
            connection.Close();
            return aCourse;

        }

        public int UpdateType(AssignCourse aAssignCourse)
        {
            aAssignCourse.Type = 1;
            string query = "UPDATE Courses SET Type=@type WHERE Id=@courseId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@type", aAssignCourse.Type);
            command.Parameters.AddWithValue("@courseId", aAssignCourse.CourseId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public List<CourseInfo> GetAllCourseInfoByDepartmentId(int departmentId)
        {

            string query = "SELECT * FROM CourseInfo WHERE CourseDepartmentId=@depId Order By CourseCode ASC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@depId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();

            List<CourseInfo> courseList = new List<CourseInfo>();
            
            while (reader.Read())
            {
                CourseInfo aCourse=new CourseInfo();
                aCourse.CourseId = Convert.ToInt32(reader["CourseId"]);
                aCourse.CourseCode = (reader["CourseCode"]).ToString();
                aCourse.CourseTitle = (reader["CourseName"]).ToString();
                aCourse.Semester = (reader["SemesterName"]).ToString();
                aCourse.Type = Convert.ToInt32(reader["Type"]);
                if (aCourse.Type == 1)
                {
                    aCourse.CourseTeacherName = (reader["TeacherName"]).ToString();
                    
                }
                else if (aCourse.Type == 0)
                {
                    aCourse.CourseTeacherName = "Not Assigned Yet";
                }
                
                courseList.Add(aCourse);
            }
            connection.Close();
            return courseList;

        }

        public List<Course> GetAllCourseByStudentId(int studentId)
        {
            string queryOne = "SELECT * FROM Students WHERE Id=@studeId";
            SqlCommand commandOne = new SqlCommand(queryOne, connection);
            commandOne.Parameters.AddWithValue("@studeId", studentId);
            connection.Open();
            reader = commandOne.ExecuteReader();
            int departmentId = 0;
            while (reader.Read())
            {
                departmentId = Convert.ToInt32(reader["DepartmentId"].ToString());

            }
            connection.Close();

            string query = "SELECT * FROM Courses WHERE DepartmentId=@depId Order By Code ASC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@depId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();

            List<Course> courseList = new List<Course>();

            while (reader.Read())
            {
                Course oneCourse = new Course();
                oneCourse.Id = Convert.ToInt32(reader["Id"]);
                oneCourse.Code = (reader["Code"]).ToString();
                oneCourse.Name = (reader["Name"]).ToString();

                courseList.Add(oneCourse);
            }
            connection.Close();
            return courseList;

        }
    }
}
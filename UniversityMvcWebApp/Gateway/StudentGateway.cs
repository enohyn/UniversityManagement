using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Gateway
{
    public class StudentGateway : BaseClassGateway
    {

        public int TotalStudentCountByDepartmentId(int departmentId)
        {
            string query = "SELECT Count(Id) As Total FROM Students WHERE DepartmentId=@depId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@depId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();
            int totalCount = 0;
            while (reader.Read())
            {
                totalCount = Convert.ToInt32(reader["Total"]);

            }
            connection.Close();
            return totalCount;
        }

        public int Save(Student aStudent)
        {
            string query = "INSERT INTO Students(RegNo,Name,Email,ContactNo,Date,Address,DepartmentId) VALUES(@regNo,@name,@email,@conatctNo,@date,@Address,@depatId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@regNo", aStudent.RegNo);
            command.Parameters.AddWithValue("@name", aStudent.Name);
            command.Parameters.AddWithValue("@email", aStudent.Email);
            command.Parameters.AddWithValue("@conatctNo", aStudent.ContactNo);
            command.Parameters.AddWithValue("@date", aStudent.FullDate);
            command.Parameters.AddWithValue("@Address", aStudent.Address);
            command.Parameters.AddWithValue("@depatId", aStudent.DepartmentId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsExistsEmail(string aEmail)
        {
            string query = "SELECT * FROM Students WHERE Email=@email";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", aEmail);
            connection.Open();
            reader = command.ExecuteReader();
            bool hasRows = reader.HasRows;
            connection.Close();
            return hasRows;
        }

        public List<Student> GetAllStudent()
        {
            command = new SqlCommand("SELECT * FROM StudentInfo Order By RegNo ASC", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Student> studentList = new List<Student>();

            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.RegNo = (reader["RegNo"]).ToString();
                aStudent.Name = reader["Name"].ToString();
                aStudent.Email = reader["Email"].ToString();
                aStudent.ContactNo = reader["ContactNo"].ToString();
                aStudent.FullDate = reader["Date"].ToString();
                aStudent.Address = reader["Address"].ToString();
                aStudent.DepartmentName = reader["DepartmentName"].ToString();

                studentList.Add(aStudent);
            }
            connection.Close();
            return studentList;

        }

        public List<Student> GetAllStudentRegNo()
        {
            command = new SqlCommand("SELECT * FROM Students Order By RegNo ASC", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Student> regNoList = new List<Student>();

            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = Convert.ToInt32(reader["Id"]);
                aStudent.RegNo = (reader["RegNo"]).ToString();

                regNoList.Add(aStudent);
            }
            connection.Close();
            return regNoList;

        }

        public Student GetAStudentByStudentId(int studentId)
        {
            string queryOne = "SELECT * FROM Students WHERE Id=@studeId";
            SqlCommand commandOne = new SqlCommand(queryOne, connection);
            commandOne.Parameters.AddWithValue("@studeId", studentId);
            connection.Open();
            reader = commandOne.ExecuteReader();
            Student aStudent = null;
            while (reader.Read())
            {
                aStudent = new Student();
                aStudent.Name = reader["Name"].ToString();
                aStudent.Email = reader["Email"].ToString();
                aStudent.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());

            }
            connection.Close();

            string queryTwo = "SELECT Name FROM Departments WHERE Id=@depId";
            SqlCommand commandTwo = new SqlCommand(queryTwo, connection);
            commandTwo.Parameters.AddWithValue("@depId", aStudent.DepartmentId);
            connection.Open();
            reader = commandTwo.ExecuteReader();
            while (reader.Read())
            {
                aStudent.DepartmentName = reader["Name"].ToString();

            }
            connection.Close();
            return aStudent;

        }

    }
}
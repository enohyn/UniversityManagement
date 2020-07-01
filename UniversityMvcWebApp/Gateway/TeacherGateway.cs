using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;
using UniversityMvcWebApp.Models.ViewModel;

namespace UniversityMvcWebApp.Gateway
{
    public class TeacherGateway :BaseClassGateway
    {
        public int Save(Teacher aTeacher)
        {
            aTeacher.CreditLeft = aTeacher.CreditBeTaken;
            string query = "INSERT INTO Teachers(Name,Address,Email,ContactNo,DesignationId,DepartmentId,CreditBeTaken,CreditLeft) VALUES(@name,@address,@email,@contactNo,@designationId,@departmentId,@creditBeTaken,@creditLeft)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", aTeacher.Name);
            command.Parameters.AddWithValue("@address", aTeacher.Address);
            command.Parameters.AddWithValue("@email", aTeacher.Email);
            command.Parameters.AddWithValue("@contactNo", aTeacher.ContactNo);
            command.Parameters.AddWithValue("@designationId", aTeacher.DesignationId);
            command.Parameters.AddWithValue("@departmentId", aTeacher.DepartmentId);
            command.Parameters.AddWithValue("@creditBeTaken", aTeacher.CreditBeTaken);
            command.Parameters.AddWithValue("@creditLeft", aTeacher.CreditLeft);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsExistsEmail(string aEmail)
        {
            string query = "SELECT * FROM Teachers WHERE Email=@email";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", aEmail);
            connection.Open();
            reader = command.ExecuteReader();
            bool hasRows = reader.HasRows;
            connection.Close();
            return hasRows;
        }

        public List<Teacher> GetAllTeacherByDepartmentId(int departmentId)
        {
            string query ="SELECT * FROM Teachers WHERE DepartmentId=@depId Order By Name ASC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@depId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();

            List<Teacher> teacherList = new List<Teacher>();

            while (reader.Read())
            {
                Teacher aTeacher = new Teacher();
                aTeacher.Id = Convert.ToInt32(reader["Id"]);
                aTeacher.Name = (reader["Name"]).ToString();


                teacherList.Add(aTeacher);
            }
            connection.Close();
            return teacherList;

        }

        public Teacher GetATeacherByTeacherId(int teacherId)
        {
            string query = "SELECT * FROM Teachers WHERE Id=@teachId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@teachId", teacherId);
            connection.Open();
            reader = command.ExecuteReader();
            Teacher aTeacher = null;
            while (reader.Read())
            {
                aTeacher = new Teacher();
                aTeacher.CreditBeTaken = Convert.ToDouble(reader["CreditBeTaken"]);
                aTeacher.CreditLeft = Convert.ToDouble(reader["CreditLeft"]);

            }
            connection.Close();
            return aTeacher;

        }

        public int UpdateCreditLeft(AssignCourse aAssignCourse)
        {
            aAssignCourse.CreditLeft -= aAssignCourse.CourseCredit;
            string query = "UPDATE Teachers SET CreditLeft=@cLeft WHERE Id=@teacherId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@cLeft", aAssignCourse.CreditLeft);
            command.Parameters.AddWithValue("@teacherId", aAssignCourse.TeacherId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}
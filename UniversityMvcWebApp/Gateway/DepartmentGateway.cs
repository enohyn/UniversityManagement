using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Gateway
{
    public class DepartmentGateway : BaseClassGateway
    {

        public int Save(Department aDepartment)
        {
            string query = "INSERT INTO Departments(Code,Name) VALUES(@code,@name)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@code", aDepartment.Code);
            command.Parameters.AddWithValue("@name", aDepartment.Name);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsExistsDepartment(string aDepartmentName)
        {
            string query = "SELECT * FROM Departments WHERE Name=@aName";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@aName", aDepartmentName);
            connection.Open();
            reader = command.ExecuteReader();
            bool hasRows = reader.HasRows;
            connection.Close();
            return hasRows;
        }

        public List<Department> GetAllDepartment()
        {
            command = new SqlCommand("SELECT * FROM Departments Order By Name ASC", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Department> departmentList = new List<Department>();

            while (reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = Convert.ToInt32(reader["Id"]);
                aDepartment.Code = (reader["Code"]).ToString();
                aDepartment.Name = reader["Name"].ToString();

                departmentList.Add(aDepartment);
            }
            connection.Close();
            return departmentList;

        }

        public string GetADepartmentCode(int departmentId)
        {
            command = new SqlCommand("SELECT Code FROM Departments WHERE Id=@depId", connection);
            command.Parameters.AddWithValue("@depId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();
            string aDepartmentCode = null;
            while (reader.Read())
            {
                aDepartmentCode = (reader["Code"]).ToString();

            }
            connection.Close();
            return aDepartmentCode;
        }

    }
}
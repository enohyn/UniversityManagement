using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Gateway
{
    public class DesignationGateway :BaseClassGateway
    {
        public List<Designation> GetAllDesignation()
        {
            command = new SqlCommand("SELECT * FROM Designations", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Designation> designationList = new List<Designation>();

            while (reader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.Id = Convert.ToInt32(reader["Id"]);
                aDesignation.DesignationName = (reader["Designation"]).ToString();

                designationList.Add(aDesignation);
            }
            connection.Close();
            return designationList;

        }
    }
}
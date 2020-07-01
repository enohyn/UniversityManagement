using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityMvcWebApp.Gateway
{
    public class BaseClassGateway
    {
        
            public SqlConnection connection;
            public SqlCommand command;
            public SqlDataReader reader;
            public SqlDataAdapter adapter;
            public BaseClassGateway()
            {
                string aConnectionString = WebConfigurationManager.ConnectionStrings["XoomUniversityConString"].ConnectionString;
                connection = new SqlConnection(aConnectionString);

            }

        
    }
}
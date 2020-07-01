using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcWebApp.Gateway;
using UniversityMvcWebApp.Models;

namespace UniversityMvcWebApp.Manager
{
    public class GradeManager
    {
        private GradeGateway aGradeGateway;

        public GradeManager()
        {
            aGradeGateway=new GradeGateway();
        }

        public List<Grade> GetAllGrade()
        {
            return aGradeGateway.GetAllGrade();
        }

    }
}
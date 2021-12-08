using DocsVision.BackOffice.WebClient.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaTestServer.Models
{
    public class CustomEmployeeData
    {
        public string Phone { get; set; }
        public EmployeeModel Manager { get; set; }
    }
}
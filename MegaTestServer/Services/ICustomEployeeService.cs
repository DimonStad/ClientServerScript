using MegaTestServer.Models;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaTestServer.Services
{
    public interface ICustomEployeeService
    {
        CustomEmployeeData GetEmployeeData(SessionContext context, Guid employeeId);
    }
}
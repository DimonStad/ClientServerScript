using MegaTestServer.Models;
using MegaTestServer.Services;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.WebClient.Department;
using DocsVision.BackOffice.WebClient.Employee;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MegaTestServer.Services
{
    public class CustomEployeeService : ICustomEployeeService
    {
        public CustomEmployeeData GetEmployeeData(SessionContext context, Guid employeeId)
        {
            StaffEmployee employee = context.ObjectContext.GetObject<StaffEmployee>(employeeId);
            if (employee == null) { return null; }
            CustomEmployeeData model = new CustomEmployeeData()
            {
                Phone = employee.Phone
            };
            StaffEmployee manager = null;
            if (employee.Manager != null) { manager = employee.Manager; }
            else { manager = employee.Unit.Manager; }
            if (manager != null)
            {
                EmployeeModel employeeModel = new EmployeeModel();
                employeeModel.Initialize(manager);
                model.Manager = employeeModel;
            }
            return model;
        }
    }
}
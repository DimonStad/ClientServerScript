using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.WebClient.Employee;
using DocsVision.Platform.WebClient;
using MegaTestServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaTestServer.Services
{
    public class SecretaryService : ISecretaryService
    {
        public SecretaryData GetSecretary(SessionContext context, string nameGroup)
        {
            
            StaffGroup groupSecretary = context.ObjectContext.FindObject<StaffGroup>(new DocsVision.Platform.ObjectModel.Search.QueryObject(
                StaffGroup.NameProperty.Name, nameGroup));
            if (groupSecretary == null) { return null; }
            List<EmployeeModel> groupEmployee = new List<EmployeeModel>();

            foreach(var m in groupSecretary.Employees)
            {
                EmployeeModel temp = new EmployeeModel();
                temp.Initialize(m);
                groupEmployee.Add(temp);
            }

            SecretaryData model = new SecretaryData()
            {
                Secretary = groupEmployee.ToArray()
            };
            return model;
        }
    }
}
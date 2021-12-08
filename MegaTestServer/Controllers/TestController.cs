using MegaTestServer.Models;
using MegaTestServer.Services;
using DocsVision.BackOffice.WebClient.Helpers;
using DocsVision.Platform.WebClient.Helpers;
using DocsVision.Platform.WebClient.Models;
using DocsVision.Platform.WebClient.Models.Generic;
using MegaTestServer.Models;
using MegaTestServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaTestServer.Contollers
{
    public class TestController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DocsVision.BackOffice.WebClient.Helpers.ServiceHelper _serviceHelper;
        public TestController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _serviceHelper = new DocsVision.BackOffice.WebClient.Helpers.ServiceHelper(serviceProvider);
        }

        public ActionResult GetEmployeeData(Guid employeeId)
        {
            var context = _serviceHelper.CurrentObjectContextProvider.GetOrCreateCurrentSessionContext();
            ICustomEployeeService service = ServiceUtil.GetService<ICustomEployeeService>(_serviceProvider);
            CustomEmployeeData model = service.GetEmployeeData(context, employeeId);
            CommonResponse<CustomEmployeeData> response = new CommonResponse<CustomEmployeeData>();
            response.InitializeSuccess(model);
            return Content(JsonHelper.SerializeToJson(response));

        }
    }
}
using DocsVision.Platform.WebClient.Helpers;
using DocsVision.Platform.WebClient.Models.Generic;
using MegaTestServer.Models;
using MegaTestServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaTestServer.Controllers
{
    public class SecretaryController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DocsVision.BackOffice.WebClient.Helpers.ServiceHelper _serviceHelper;
        public SecretaryController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _serviceHelper = new DocsVision.BackOffice.WebClient.Helpers.ServiceHelper(serviceProvider);
        }

        public ActionResult GetSecretary(string nameGroup)
        {
            var context = _serviceHelper.CurrentObjectContextProvider.GetOrCreateCurrentSessionContext();
            ISecretaryService service = ServiceUtil.GetService<ISecretaryService>(_serviceProvider);
            SecretaryData model = service.GetSecretary(context, nameGroup);
            CommonResponse<SecretaryData> response = new CommonResponse<SecretaryData>();
            response.InitializeSuccess(model);
            return Content(JsonHelper.SerializeToJson(response));

        }

    }
}
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
    public class CityController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DocsVision.BackOffice.WebClient.Helpers.ServiceHelper _serviceHelper;
        public CityController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _serviceHelper = new DocsVision.BackOffice.WebClient.Helpers.ServiceHelper(serviceProvider);
        }

        public ActionResult GetCityData(Guid cityId)
        {
            var context = _serviceHelper.CurrentObjectContextProvider.GetOrCreateCurrentSessionContext();
            ICityService service = ServiceUtil.GetService<ICityService>(_serviceProvider);
            CityData model = service.GetCityData(context, cityId);
            CommonResponse<CityData> response = new CommonResponse<CityData>();
            response.InitializeSuccess(model);
            return Content(JsonHelper.SerializeToJson(response));

        }
    }
}
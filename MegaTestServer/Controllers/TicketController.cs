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
    public class TicketController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DocsVision.BackOffice.WebClient.Helpers.ServiceHelper _serviceHelper;
        public TicketController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _serviceHelper = new DocsVision.BackOffice.WebClient.Helpers.ServiceHelper(serviceProvider);
        }

        public ActionResult GetTicketData(string homeCity, string bisTripCity, DateTime depart_date, DateTime return_date)
        {
            var context = _serviceHelper.CurrentObjectContextProvider.GetOrCreateCurrentSessionContext();
            ITicketService service = ServiceUtil.GetService<ITicketService>(_serviceProvider);
            TicketData model = service.GetTicketData(context, homeCity, bisTripCity, depart_date, return_date);
            CommonResponse<TicketData> response = new CommonResponse<TicketData>();
            response.InitializeSuccess(model);
            return Content(JsonHelper.SerializeToJson(response));

        }
    }
}
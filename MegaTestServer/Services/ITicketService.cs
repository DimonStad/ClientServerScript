using DocsVision.Platform.WebClient;
using MegaTestServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaTestServer.Services
{
    public interface ITicketService
    {
        TicketData GetTicketData(SessionContext context, string homeCity, string bisTripCity, DateTime depart_date, DateTime return_date);
    }
}
using DocsVision.Platform.WebClient;
using MegaTestServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaTestServer.Services
{
    public interface ICityService
    {
        CityData GetCityData(SessionContext context, Guid cityId);
    }
}
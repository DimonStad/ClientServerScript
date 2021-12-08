using DocsVision.BackOffice.ObjectModel;
using DocsVision.Platform.WebClient;
using MegaTestServer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MegaTestServer.Services
{
    public class CityService : ICityService
    {
        public CityData GetCityData(SessionContext context, Guid cityId)
        {
            BaseUniversalItem item = context.ObjectContext.GetObject<BaseUniversalItem>(cityId);
            string daily = item.ItemCard.MainInfo["Daily"].ToString().Replace('.', ',');

            decimal valueDaily = decimal.Parse(decimal.Parse(daily).ToString("N", CultureInfo.GetCultureInfo("ru-RU")));
            string cityCode = item.ItemCard.MainInfo["CodeAir"].ToString();
            CityData model = new CityData()
            {
                CodeAir = cityCode,
                Daily = valueDaily
            };
            return model;
        }
    }
}
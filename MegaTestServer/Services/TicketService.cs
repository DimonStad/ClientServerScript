using DocsVision.Platform.WebClient;
using MegaTestServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace MegaTestServer.Services
{
    public class TicketService : ITicketService
    {
        public decimal value;
        public string destination;
        public string depart_date;
        private IServiceProvider serviceProvider;

        public TicketService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TicketData GetTicketData(SessionContext context, string homeCity, string bisTripCity, DateTime depart_date, DateTime return_date)
        {
			decimal ticket_depart = tickets_there(homeCity, bisTripCity, depart_date.ToString("yyyy-MM-dd"));
			decimal ticket_back = tickets_there(bisTripCity, homeCity, return_date.ToString("yyyy-MM-dd"));

			if (ticket_depart == 0 || ticket_back == 0)
            {
				decimal result = -1000;
				TicketData model = new TicketData()
				{
					TicketPrice = result
				};

				return model;

			}
            else 
			{ 

				decimal result = ticket_depart + ticket_back;
				TicketData model = new TicketData()
				{
					TicketPrice = result
				};

				return model;
				}
		}

		public static string getContent(string url)
		{

			HttpWebRequest request =
			(HttpWebRequest)WebRequest.Create(url);

			request.Method = "GET";
			request.Accept = "application/json";
			request.UserAgent = "Mozilla/5.0 ....";

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream());
			StringBuilder output = new StringBuilder();
			output.Append(reader.ReadToEnd());
			response.Close();
			return output.ToString();
		}


		public decimal tickets_there(string origin, string cityCode, string depart_date)
		{
			string url = string.Format(@"http://min-prices.aviasales.ru/calendar_preload?origin={0}&destination={1}&depart_date={2}&one_way=false", origin, cityCode, depart_date);

			string result = getContent(url);

			Ticket data = JsonConvert.DeserializeObject<Ticket>(result);

			List<TicketService> bestPriceTicket = data.best_prices;
			decimal minPrice;
			try
			{
				minPrice = bestPriceTicket
				   .Where(x => x.destination == cityCode && x.depart_date == depart_date)
				   .Select(p => p.value)
				   .Min();
			}
			catch
			{
				return 0;
			}
			TicketService minTicket = bestPriceTicket
					.FirstOrDefault(x =>
					x.destination == cityCode
					&& x.value == minPrice);
			return minPrice;
		}
	}
	public class Ticket
	{
		public List<TicketService> current_depart_date_prices { get; set; }
		public List<TicketService> best_prices { get; set; }

	}
}
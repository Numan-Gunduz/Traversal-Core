//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using TraversalCoreProje.Areas.Admin.Models;

//namespace TraversalCoreProje.Areas.Admin.Controllers
//{
//	public class ApiExchangeController : Controller
//	{
//		[Area("Admin")]
//		[AllowAnonymous]
//		public async Task <IActionResult> Index()
//		{
//			List<BookingExxchangeViewModel2>bookingExxhangeViewModel = new List<BookingExxchangeViewModel2>();
//			//using System.Net.Http.Headers;
//			var client = new HttpClient();
//			var request = new HttpRequestMessage
//			{
//				Method = HttpMethod.Get,
//				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
//				Headers =
//	{
//		{ "X-RapidAPI-Key", "1d334c7fe2msh2159895426a82ccp1305a3jsn1aea55313e21" },
//		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
//	},
//			};
//			using (var response = await client.SendAsync(request))
//			{
//				response.EnsureSuccessStatusCode();
//				var body = await response.Content.ReadAsStringAsync();
//				var	values=JsonConvert.DeserializeObject<BookingExxchangeViewModel2>(body);
//				return View(values.exchange_rates);
//			}

//		}
//	}
//}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	public class ApiExchangeController : Controller
	{
		[Area("Admin")]
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			List<BookingExxchangeViewModel2.Exchange_Rates> exchangeRatesList = new List<BookingExxchangeViewModel2.Exchange_Rates>();

			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
				Headers =
				{
					{ "X-RapidAPI-Key", "1d334c7fe2msh2159895426a82ccp1305a3jsn1aea55313e21" },
					{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
				},
			};

			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var bookingExxchangeViewModel = JsonConvert.DeserializeObject<BookingExxchangeViewModel2>(body);

				// Diziyi List'e çevir
				exchangeRatesList = bookingExxchangeViewModel.exchange_rates.ToList();

				return View(exchangeRatesList);
			}
		}
	}
}


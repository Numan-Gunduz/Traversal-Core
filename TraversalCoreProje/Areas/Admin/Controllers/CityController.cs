using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CityController : Controller
	{
		private readonly IDestinationService _destinationService;
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
		{
			return View();
		}
		
		public IActionResult CityList()
		{
			var jsonCity = JsonConvert.SerializeObject(_destinationService.GetList());
			return Json(jsonCity);
		}

		[HttpPost]
		public IActionResult AddCityDestination(Destination destination)
		{
			destination.Status = true;
			destination.CoverImages = ("default");
			destination.Image = ("default");
			destination.Description = ("default");
			destination.Details1 = ("default");
			destination.Details2 = ("default");
			destination.Image2 = ("default");
            _destinationService.TAdd(destination);
			var values = JsonConvert.SerializeObject(destination);
			return Json(values);
		}
		public IActionResult GetById(int DestinationID)
		{
			var values =_destinationService.GetById(DestinationID);

			var jsonValues=JsonConvert.SerializeObject(values);
			return Json(jsonValues);
		}

		public IActionResult DeleteCity(int id)
		{
			var values = _destinationService.GetById(id);
			_destinationService.TDelete(values);
		
			return NoContent();
		}
		public IActionResult UpdateCity(Destination destination)
		{
			var values = _destinationService.GetById(destination.DestinationID);
			destination.Status = values.Status;
			destination.Price = values.Price;
			destination.Image = values.Image;
			destination.Description = values.Description;
			destination.Capacity = values.Capacity;
			destination.CoverImages = values.CoverImages;
			destination.Details1 = values.Details1;
			destination.Details2 = values.Details2;
			destination.Image2 = values.Image2;
			_destinationService.TUpdate(destination);
			var v=JsonConvert.SerializeObject(destination);


			return Json(v);
		}

	}
}

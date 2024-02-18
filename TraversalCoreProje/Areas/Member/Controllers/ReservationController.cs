using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	
	public class ReservationController : Controller
	{
		DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
		ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
		private readonly UserManager<AppUser> _userManager;

		public ReservationController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> MyCurrentReservation()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = reservationManager.GetListWithReservationByAccepted(values.Id);
			return View(valuesList);

		}
		public async Task<IActionResult> MyOldReservation()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = reservationManager.GetListWithReservationByPrevious(values.Id);
			return View(valuesList);


		}
		public  async Task<IActionResult> MyApprovalReservation()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList=reservationManager.GetListWithReservationByWaitApproval(values.Id);
			return View(valuesList);

		}

		[HttpGet]
		public IActionResult NewReservation()
		{
			List<SelectListItem> values = (from x in destinationManager.GetList()
										   select new SelectListItem
										   {
											   Text=x.City,
											   Value=x.DestinationID.ToString(),
										   }).ToList();

			ViewBag.v = values;
			return View();
		}
		//[HttpPost]

		//public async Task<IActionResult> NewReservation(Reservation p)
		//{
		//	//var user = await _userManager.FindByIdAsync(p.AppUserId);
		// // if (user == null)
		// // {
		// //     ModelState.AddModelError("", "Geçerli bir kullanıcı seçmelisiniz.");
		// //     // Hata durumunda sayfaya geri dönmek için gerekli işlemler
		// //     return View(p);
		// // }
		//	p.AppUserId =18;
		//	p.Status ="Onay Bekliyor";
		//	reservationManager.TAdd(p);

		//	return RedirectToAction("MyCurrentReservation"); 
		//}
		[HttpPost]
		public async Task<IActionResult> NewReservation(Reservation p)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (user == null)
			{
				ModelState.AddModelError("", "Geçerli bir kullanıcı seçmelisiniz.");
				// Hata durumunda sayfaya geri dönmek için gerekli işlemler
				return View(p);
			}

			p.AppUserId = user.Id; // Kullanıcının ID'sini rezervasyon sahibi olarak atayın
			p.Status = "Onay Bekliyor";
			reservationManager.TAdd(p);

			return RedirectToAction("MyCurrentReservation");
		}



	}
}

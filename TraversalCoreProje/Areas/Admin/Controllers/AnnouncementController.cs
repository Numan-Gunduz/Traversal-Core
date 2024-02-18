using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("/Admin/[controller]/[action]")]
	public class AnnouncementController : Controller
	{
		private readonly IAnnouncementService _announcementService;
		private readonly IMapper _mapper;
		public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
		{
			_announcementService = announcementService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			//List<Announcement> announcements = _announcementService.GetList();
			//List<AnnouncementListViewModel> model = new List<AnnouncementListViewModel>();
			//foreach (var item in announcements)
			//{
			//	AnnouncementListViewModel announcementListViewModel = new AnnouncementListViewModel();
			//	announcementListViewModel.ID = item.AnnouncementID;
			//	announcementListViewModel.Title = item.Title;
			//	announcementListViewModel.Content = item.Content;

			//	model.Add(announcementListViewModel);

			//}
			//return View(model);
			var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.GetList());
			return View(values);


		}
		[HttpGet]
		public IActionResult AddAnnouncement()
		{

			return View();
		}
		[HttpPost]
		public IActionResult AddAnnouncement(AnnouncementAddDto model)
		{
			if (ModelState.IsValid)
			{
				_announcementService.TAdd(new Announcement()
				{
					Content = model.Content,
					Title = model.Title,
					Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
				});
				return RedirectToAction("Index");
			}
			return View(model);
		}
		[Route("{id}")]
		public IActionResult DeleteAnnouncement(int id)
		{
			var values =_announcementService.GetById(id);
			_announcementService.TDelete(values);
			TempData["SuccessMessage"] = "Duyuru başarıyla Silindi.";
			return RedirectToAction("Index");
		}
		[Route("{id}")]
		[HttpGet]
		public IActionResult UpdateAnnouncement(int id)
		{	var values = _mapper.Map<AnnouncementUpdateDto>(_announcementService.GetById(id));
			return View(values);
		}



		[Route("{id}")]
		[HttpPost]
		public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
		{

			if (ModelState.IsValid)
			{
				_announcementService.TUpdate(new Announcement
				{
					AnnouncementID = model.AnnouncementID,
					Title = model.Title,
					Content = model.Content,
					Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
				});
				return RedirectToAction("Index");

			}
			return View(model);
		}
	}
}

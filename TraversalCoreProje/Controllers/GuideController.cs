using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
	public class GuideController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			GuideManager guideManager = new GuideManager(new EfGuideDal());
			var values = guideManager.GetList();
			return View(values);
		}
	}
}

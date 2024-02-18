using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	public class DashboardController : Controller
	{
        private readonly UserManager<AppUser> userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task< IActionResult> Index()
		{
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values.Name + " " + values.Surname;
            ViewBag.userImage = values.ImageUrl;
            return View();
		}
	}
}

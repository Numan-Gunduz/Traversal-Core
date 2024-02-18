using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			this.userManager = userManager;
		}



        [HttpGet]
		public async Task<IActionResult> Index()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.mail = values.Email;
            

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if(p.Image != null)
            {
                var resoruce = Directory.GetCurrentDirectory();
                var extansion = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extansion;
                var savelocation = resoruce + "/wwwroot/UserImages/"+imagename;
                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    

                    await p.Image.CopyToAsync(stream);
                }
                user.ImageUrl=imagename;
                    

			}
            user.Name = p.name;
            user.Surname = p.surname;
            user.PasswordHash=userManager.PasswordHasher.HashPassword(user,p.password);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();


		}
    }
}

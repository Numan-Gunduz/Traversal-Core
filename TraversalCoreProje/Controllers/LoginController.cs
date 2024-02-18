using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]

	public class LoginController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Email,
                UserName = p.UserName,
			
			};
            if (p.Password == p.ConfirmPassword)
            {
                var result = await userManager.CreateAsync(appUser,p.Password);
                 
                     if (result.Succeeded)
                                 {
                                 return RedirectToAction("SignIn");
                                  }
                        else
                         {
                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError("", item.Description);
                            }
                        }
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }



        [HttpPost]
		public async Task <ActionResult> SignIn(UserSignInViewModel p)
		{
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(p.username,p.password,false,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile",new {area="Member"});
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }

			return View();
		}

	}
}

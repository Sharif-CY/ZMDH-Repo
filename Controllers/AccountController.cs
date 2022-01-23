using WDPR.Models;
using WDPR.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WDPR.Areas.Identity.Pages.Account;

namespace WDPR.Controllers {

    public class AccountController : Controller {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
            }

            [HttpPost]
         //   [AllowAnonymous]
            public async Task<IActionResult> Register(RegisterModel model)
            {
                if(ModelState.IsValid)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                    };

                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Success){
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("index", "home");
                    }

           foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
    }

    return View(model);
}
            }
    }

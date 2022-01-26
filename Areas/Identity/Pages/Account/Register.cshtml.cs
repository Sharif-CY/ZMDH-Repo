using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using WDPR.Models;

namespace WDPR.Areas.Identity.Pages.Account
{
    // [Authorize(Roles = "Moderator")]
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;


        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }



        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            [Required]
            [Display(Name = "Wat bent u")]
            [RegularExpression(@"^Hulpverlener|Moderator|Client|Ouder")]
            public string Role { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            public string voornaam{get; set;}
            public string achternaam{get; set;}
            public string specialisme{get; set;}
            public string wiebenik{get; set;}
            public string mijnstudie{get; set;}
            public string watals{get; set;}
            public string hoehelpen{get; set;}



            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

       
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                 if(Input.Role == "Hulpverlener"){
                    var user = new Hulpverlener { 
                        UserName = Input.Email, 
                        Email = Input.Email, 
                        WiebenIk = Input.wiebenik,
                        VoorNaam = Input.voornaam,
                        achterNaam = Input.achternaam,
                        WatAls = Input.watals,
                        Specialisme = Input.specialisme,
                        MijnSTudie = Input.mijnstudie,
                        HoeHelpen = Input.hoehelpen
                        };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    _userManager.AddToRoleAsync(user,"Hulpverlener").Wait();
                    
                
                if (result.Succeeded)
                 {
                     return RedirectToAction("gelukt");
                //     _logger.LogInformation("User created a new account with password.");

                //     var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //     code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //     var callbackUrl = Url.Page(
                //         "/Account/ConfirmEmail",
                //         pageHandler: null,
                //         values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                //         protocol: Request.Scheme);

                //     await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //         $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //     if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //     {
                //         return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                //     }
                //     else
                //     {
                //         await _signInManager.SignInAsync(user, isPersistent: false);
                //         return LocalRedirect(returnUrl);
                //     }
                // }
                // foreach (var error in result.Errors)
                // {
                //     ModelState.AddModelError(string.Empty, error.Description);
                 }
                
            }



            //Client wordt hier aangemaakt
             if(Input.Role == "Client"){
                    var user = new Client { UserName = Input.Email, Email = Input.Email };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    _userManager.AddToRoleAsync(user,"Client").Wait();
                    
                
                if (result.Succeeded)
                {
                    return RedirectToAction("gelukt");
                //     _logger.LogInformation("User created a new account with password.");

                //     var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //     code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //     var callbackUrl = Url.Page(
                //         "/Account/ConfirmEmail",
                //         pageHandler: null,
                //         values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                //         protocol: Request.Scheme);

                //     await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //         $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //     if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //     {
                //         return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                //     }
                //     else
                //     {
                //         await _signInManager.SignInAsync(user, isPersistent: false);
                //         return LocalRedirect(returnUrl);
                //     }
                // }
                // foreach (var error in result.Errors)
                // {
                //     ModelState.AddModelError(string.Empty, error.Description);
                }
            }



            //Ouder wordt hier aangemaakt
             if(Input.Role == "Ouder"){
                    var user = new Ouder { UserName = Input.Email, Email = Input.Email };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    _userManager.AddToRoleAsync(user,"Ouder").Wait();
                    
                
                 if (result.Succeeded)
                {
                    return RedirectToAction("gelukt");
                //     _logger.LogInformation("User created a new account with password.");

                //     var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //     code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //     var callbackUrl = Url.Page(
                //         "/Account/ConfirmEmail",
                //         pageHandler: null,
                //         values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                //         protocol: Request.Scheme);

                //     await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //         $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //     if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //     {
                //         return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                //     }
                //     else
                //     {
                //         await _signInManager.SignInAsync(user, isPersistent: false);
                //         return LocalRedirect(returnUrl);
                //     }
                // }
                // foreach (var error in result.Errors)
                // {
                //     ModelState.AddModelError(string.Empty, error.Description);
                 }
            }



            // Moderator wordt hier aangemaakt
             if(Input.Role == "Moderator"){
                    var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    _userManager.AddToRoleAsync(user,"Moderator").Wait();
                    
                
                 if (result.Succeeded)
                 {
                     return RedirectToAction("gelukt");
                //     _logger.LogInformation("User created a new account with password.");

                //     var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //     code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //     var callbackUrl = Url.Page(
                //         "/Account/ConfirmEmail",
                //         pageHandler: null,
                //         values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                //         protocol: Request.Scheme);

                //     await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //         $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //     if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //     {
                //         return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                //     }
                //     else
                //     {
                //         await _signInManager.SignInAsync(user, isPersistent: false);
                //         return LocalRedirect(returnUrl);
                //     }
                // }
                // foreach (var error in result.Errors)
                // {
                //     ModelState.AddModelError(string.Empty, error.Description);
                 }
            }




                //jaaaaa
            }
            
            // If we got this far, something failed, redisplay form
            
            return Redirect("register");
        }

        
    }
}

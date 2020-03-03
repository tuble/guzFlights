using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using guzFlightsUltra.Data;
using guzFlightsUltra.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace guzFlightsUltra.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Administrator")]

    public class RegisterModel : PageModel
    {
        private readonly SignInManager<GuzUser> _signInManager;
        private readonly UserManager<GuzUser> _userManager;
        // private readonly IEmailSender _emailSender;
        private readonly guzFlightsUltraDbContext guzFlightsUltraDbContext;


        public RegisterModel(
            UserManager<GuzUser> userManager,
            SignInManager<GuzUser> signInManager, guzFlightsUltraDbContext guzDb)
        //IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            guzFlightsUltraDbContext = guzDb;
            // _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        /*        public async Task OnGetAsync(string returnUrl = null)
                {
                    ReturnUrl = returnUrl;
                    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                }
        */

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");  // return to home

            if (ModelState.IsValid)
            {
                var user = new GuzUser { Id = Guid.NewGuid().ToString(), UserName = Input.Username, Email = Input.Email }; // add other fields !!


                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "Employee");

                    return LocalRedirect(returnUrl); // return to home page
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}

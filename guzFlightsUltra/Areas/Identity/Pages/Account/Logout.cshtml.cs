﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guzFlightsUltra.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace guzFlightsUltra.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<GuzUser> _signInManager;

        public LogoutModel(SignInManager<GuzUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();

            return Redirect("/");
        }

        /*        public async Task<IActionResult> OnPost(string returnUrl = null)
                {
                    await _signInManager.SignOutAsync();
                    if (returnUrl != null)
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToPage();
                    }
                }*/
    }
}

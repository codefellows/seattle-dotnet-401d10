using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSD10DemoCode.Models;
using CMSD10DemoCode.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMSD10DemoCode.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public LoginViewModel Input { get; set; }

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // attempt to validate the user inputted email and pw against the database
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, false);

                // if the login was successful...redirect them to the home page
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // let them they are wrong
                    ModelState.AddModelError("", "Invalid Login Attempt.");
                    return Page();
                }
            }

            return Page();
        }

    }
}

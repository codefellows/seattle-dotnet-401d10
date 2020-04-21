using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CMSD10DemoCode.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMSD10DemoCode.Pages.Account
{
    // route will be /account/register
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManger;
        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public RegisterInput RegisterData { get; set; }

        public RegisterModel(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signIn)
        {
            _userManger = usermanager;
            _signInManager = signIn;

        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = RegisterData.Email,
                    Email = RegisterData.Email,
                    FirstName = RegisterData.FirstName,
                    LastName = RegisterData.LastName,
                    Birthdate = RegisterData.Birthday
                };

                // Create the account using Idenity

                var result = await _userManger.CreateAsync(user, RegisterData.Password);

                if (result.Succeeded)
                {
                    // sign the user in. 
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    // load up all the errors and send them to the view page.
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        public class RegisterInput
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }
            
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            
            [Required]
            [DataType(DataType.Date)]
            public DateTime Birthday { get; set; }

            [Required]
            [StringLength(100, ErrorMessage ="The {0} must be at least {2} and at max {1} characters long", MinimumLength = 8)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage ="The passwords do not match")]
            public string ConfirmPassword { get; set; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.Models;

namespace WebApp1.Pages.Davalar
{
    public class KullaniciBilgileriModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HukukDTSContext _context;

        public KullaniciBilgileriModel(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            HukukDTSContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public AppUsers users { get; set; }

        [BindProperty]
        public EditInputModel input { get; set; }

        public class EditInputModel
        {

            [Required]
            [Display(Name = "Username")]
            public string UserFullName { get; set; }

            [Required]
            [Display(Name = "User Duty")]
            public string UserDuty { get; set; }

            [Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Role { get; set; }

            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; }

        }


        public async Task<IActionResult> OnGetAsync(string userId)
        {
            users = await _context.AppUsers.FindAsync(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string userId)
        {
            users = await _context.AppUsers.FindAsync(userId);
            var userPassword = users.PasswordHash;
            if(!ModelState.IsValid)
            {
                return Page();
            }
            users.UserFullName = input.UserFullName;
            users.PhoneNumber = input.PhoneNumber;
            users.UserDuty = input.UserDuty;
            if(userPassword != input.Password)
            {
            users.PasswordHash = _userManager.PasswordHasher.HashPassword(users, input.Password);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Davalar/Kullanicilar");
        }
    }
}

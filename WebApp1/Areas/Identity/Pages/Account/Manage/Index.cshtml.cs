﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Models;

namespace WebApp1.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly HukukDTSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            HukukDTSContext context,
            IHttpContextAccessor httpContextAccessor )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public AppUsers users { get; set; }

        [BindProperty]
        public InputModel input { get; set; }

        public class InputModel
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

        }

       

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = _httpContextAccessor.HttpContext
                .User.FindFirst(ClaimTypes.NameIdentifier).Value;

            users = await _context.AppUsers.FindAsync(userId);
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            var userId = _httpContextAccessor.HttpContext
               .User.FindFirst(ClaimTypes.NameIdentifier).Value;

            users = await _context.AppUsers.FindAsync(userId);
            var userPassword = users.PasswordHash;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            users.UserFullName = input.UserFullName;
            users.PhoneNumber = input.PhoneNumber;
            users.UserDuty = input.UserDuty;
            if (userPassword != input.Password)
            {
                users.PasswordHash = _userManager.PasswordHasher.HashPassword(users, input.Password);
            }

            await _context.SaveChangesAsync();
            return Page();
        }
    }
}

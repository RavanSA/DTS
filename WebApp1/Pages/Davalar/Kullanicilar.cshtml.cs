using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Pages.Davalar
{
    [Authorize]
    public class KullanicilarModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly HukukDTSContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public KullanicilarModel(UserManager<IdentityUser> userManager, HukukDTSContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public class Users_in_Role_ViewModel
        {
            public string UserId { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string UserFullName { get; set; }
            public string PhoneNumber { get; set; }
            public string UserDuty { get; set; }
            public string Role { get; set; }
        }

        public IQueryable<Users_in_Role_ViewModel> userWithRoles = null;

        public async Task<IActionResult> OnGetAsync()
        {

            userWithRoles =  from user in _context.AppUsers
                             join userRole in _context.UserRoles on user.Id equals userRole.UserId
                             join roles in _context.Roles on userRole.RoleId equals roles.Id
                             where roles.Name == "Admin" || roles.Name == "User"
             select new Users_in_Role_ViewModel() {
                 UserId = user.Id,
                 Username = user.UserName, 
                 Email = user.Email,
                 UserFullName = user.UserFullName,
                 PhoneNumber = user.PhoneNumber,
                 UserDuty = user.UserDuty,
                 Role = roles.Name
             };

            return Page();
        }

    }
}

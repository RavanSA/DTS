using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApp1.Models;

namespace WebApp1.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly HukukDTSContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public LogoutModel(
            SignInManager<IdentityUser> signInManager,
            ILogger<LogoutModel> logger,
            UserManager<IdentityUser> userManager,
            HukukDTSContext context
            )
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

                    var userInfo = await _userManager.GetUserAsync(User);
                    var roles = await _userManager.GetRolesAsync(userInfo);

                    var yeniDava = new LogTable
                    {
                        UserId = userInfo.Id,
                        UserEmail = userInfo.UserName,
                        LogTuru = "LOGOUT",
                        LogDate = DateTime.Now,
                        Aciklama = $"{userInfo.UserName} isimli kullanıcı {DateTime.Now} tarihinde sistemden çıkış yaptı, Rol: {roles[0]}"
                    };

                    await _context.LogTable.AddAsync(yeniDava);
                    await _context.SaveChangesAsync();
  
            return RedirectToPage("Login");
           
        }

    }
}

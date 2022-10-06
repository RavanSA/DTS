using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Models;
    
namespace WebApp1.Pages.Davalar
{
    [Authorize]
    public class YeniDavaModel : PageModel
    {

        private readonly HukukDTSContext _db;
        public readonly UserManager<IdentityUser> _userManager;

        public YeniDavaModel(HukukDTSContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [BindProperty]
        public WebApp1.Models.Dava Dava { get; set; }
        public WebApp1.Models.DavaTuru DavaTuru {get; set;}
        public WebApp1.Models.ParaBirimi ParaBirimi { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            
            if (ModelState.IsValid)
            {
                await _db.Dava.AddAsync(Dava);


                var userInfo = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(userInfo);

                var yeniDava = new LogTable
                {
                    UserId = userInfo.Id,
                    UserEmail = userInfo.UserName,
                    LogTuru = "YENI DAVA OLUSTURULDU",
                    LogDate = DateTime.Now,
                    Aciklama = $"{userInfo.UserName} isimli kullanýcý {DateTime.Now} tarihinde, yeni dava olusturuldu Rol: {roles[0]}"
                };

                await _db.LogTable.AddAsync(yeniDava);
                await _db.SaveChangesAsync();

                return RedirectToPage("/Davalar/Index");
            } else
            {
                return Page();
            }
        } 
    }
}

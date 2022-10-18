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
            var userInfo = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(userInfo);

            Dava.OlusturulmaTarihi = DateTime.UtcNow;
            Dava.DegistirilmeTarihi = DateTime.UtcNow;
            Dava.OlusturanKisi = userInfo.UserName.ToString();
            Dava.DegistirenKisi = userInfo.UserName.ToString();
            Dava.DavaFormTipi = 1;


                                var yeniDava = new LogTable
                                {
                                    UserId = userInfo.Id,
                                    UserEmail = userInfo.UserName,
                                    LogTuru = "YENI DAVA OLUSTURULDU",
                                    LogDate = DateTime.Now,
                                    Aciklama = $"{userInfo.UserName} isimli kullanýcý {DateTime.Now} tarihinde, yeni dava olusturuldu Rol: {roles[0]}"
                                };

                    await _db.LogTable.AddAsync(yeniDava);       
                    await _db.Dava.AddAsync(Dava);
                    await _db.SaveChangesAsync();

                    return RedirectToPage("/Davalar/Index");

        } 
    }
}

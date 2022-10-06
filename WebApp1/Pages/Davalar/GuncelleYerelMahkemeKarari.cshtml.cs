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
    public class GuncelleYerelMahkemeKarariModel : PageModel
    {
        public readonly HukukDTSContext _db;
        public readonly UserManager<IdentityUser> _userManager;

        public GuncelleYerelMahkemeKarariModel(HukukDTSContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [BindProperty]
        public YerelMahkemeKarari Karar { get; set; }

        public async Task OnGet(int id)
        {
            Karar = await _db.YerelMahkemeKarari.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(int davaKayitNo)
        {
            if (ModelState.IsValid)
            {

                var userInfo = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(userInfo);

                var davaDetay = new LogTable
                {
                    UserId = userInfo.Id,
                    UserEmail = userInfo.UserName,
                    LogTuru = "YEREL MAHKEME KARARÝ GUNCELLEME",
                    LogDate = DateTime.Now,
                    Aciklama = $"{userInfo.UserName} isimli kullanýcý {DateTime.Now} tarihinde {davaKayitNo} nolu davanýn yerel mahkeme kararýný güncelledi, Rol: {roles[0]}"
                };

                _db.Entry(Karar).State = !_db.YerelMahkemeKarari.Any(k => k.DavaKayitNo == Karar.DavaKayitNo) 
                    ? EntityState.Added : EntityState.Modified;

                await _db.LogTable.AddAsync(davaDetay);

                await _db.SaveChangesAsync();

                return RedirectToPage("/Davalar/Detay", new { davaKayitNo = davaKayitNo });

            }
            else
            {
                return Page();
            }
        }
    }
}

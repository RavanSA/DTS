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
    public class DavaSonucuModel : PageModel
    {

        public readonly HukukDTSContext _db;
        public readonly UserManager<IdentityUser> _userManager;

        public DavaSonucuModel(HukukDTSContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [BindProperty]
        public DavaSonucu DavaSonucu { get; set; }


        public async Task OnGet(int id)
        {
            DavaSonucu = await _db.DavaSonucu.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(int davaKayitNo)
        {
            if(ModelState.IsValid)
            {

                var userInfo = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(userInfo);

                var davaDetay = new LogTable
                {
                    UserId = userInfo.Id,
                    UserEmail = userInfo.UserName,
                    LogTuru = "DAVA SONUCU",
                    LogDate = DateTime.Now,
                    Aciklama = $"{userInfo.UserName} isimli kullan�c� {DateTime.Now} tarihinde {davaKayitNo} nolu davay� sonuclandirdi, Rol: {roles[0]}"
                };

                _db.Entry(DavaSonucu).State = !_db.DavaSonucu.Any(t => t.DavaKayitNo == DavaSonucu.DavaKayitNo) ?
                    EntityState.Added : EntityState.Modified;

                await _db.LogTable.AddAsync(davaDetay);
                await _db.SaveChangesAsync();

                return RedirectToPage("/Davalar/Detay", new { davaKayitNo = davaKayitNo });
            }
            return Page();
        }
    }
}

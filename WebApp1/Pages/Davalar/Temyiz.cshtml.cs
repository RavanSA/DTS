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
    public class TemyizModel : PageModel
    {
        public readonly HukukDTSContext _db;
        public readonly UserManager<IdentityUser> _userManager;

        public TemyizModel(HukukDTSContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [BindProperty]
        public Temyiz Temyiz { get; set; }

        public async Task OnGet(int id)
        {
            Temyiz = await _db.Temyiz.FindAsync(id);
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
                    LogTuru = "TEMYIZ",
                    LogDate = DateTime.Now,
                    Aciklama = $"{userInfo.UserName} isimli kullanýcý {DateTime.Now} tarihinde {davaKayitNo} nolu temyiz sonucunu güncelledi, Rol: {roles[0]}"
                };

                _db.Entry(Temyiz).State = !_db.Temyiz.Any(t => t.DavaKayitNo == Temyiz.DavaKayitNo) ?
                    EntityState.Added : EntityState.Modified;
                await _db.LogTable.AddAsync(davaDetay);
                await _db.SaveChangesAsync();
                    return RedirectToPage("/Davalar/Detay", new { davaKayitNo = davaKayitNo });
            }

            return Page();

        }
    }
}

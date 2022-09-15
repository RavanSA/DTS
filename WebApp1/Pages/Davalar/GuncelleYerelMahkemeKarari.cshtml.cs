using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public GuncelleYerelMahkemeKarariModel(HukukDTSContext db)
        {
            _db = db;
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
                _db.Entry(Karar).State = !_db.YerelMahkemeKarari.Any(k => k.DavaKayitNo == Karar.DavaKayitNo) 
                    ? EntityState.Added : EntityState.Modified;

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

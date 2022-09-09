using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Pages.Davalar
{
    public class DavaGuncelleModel : PageModel
    {
        public readonly HukukDTSContext _db;
        public DavaGuncelleModel(HukukDTSContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Dava Dava { get; set; }

        public async Task OnGetAsync(int id)
        {
            Dava = await _db.Dava.FindAsync(id);

        }

        public async Task<IActionResult> OnPostAsync(int davaKayitNo)
        {
            if (ModelState.IsValid)
            {
                _db.Attach(Dava).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return RedirectToPage("/Davalar/Detay", new { davaKayitNo = davaKayitNo });

            }

            return Page();
        }
    }
}

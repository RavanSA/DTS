using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Models;

namespace WebApp1.Pages.Davalar
{
    public class TemyizModel : PageModel
    {
        public readonly HukukDTSContext _db;

        public TemyizModel(HukukDTSContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Temyiz Temyiz { get; set; }

        public async Task OnGet(int id)
        {
            Temyiz = await _db.Temyiz.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
              if(ModelState.IsValid)
            {
                await _db.Temyiz.AddAsync(Temyiz);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}

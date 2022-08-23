using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Models;

namespace WebApp1.Pages.Davalar
{
    public class YeniDavaModel : PageModel
    {

        private readonly HukukDTSContext _db;

        public YeniDavaModel(HukukDTSContext db)
        {
            _db = db;
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
            
                await _db.SaveChangesAsync();

                return RedirectToPage("/Davalar/Index");
            } else
            {
                return Page();
            }
        } 
    }
}

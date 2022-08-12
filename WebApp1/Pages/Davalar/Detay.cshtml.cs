        using System.Collections.Generic;
        using System.Threading.Tasks;
        using Microsoft.AspNetCore.Mvc;
        using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Pages.Davalar
{
    public class DetayModel : PageModel
    {
        public readonly HukukDTSContext _db;

        public DetayModel(HukukDTSContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Dava Dava { get; set; }
        [BindProperty]
        public YerelMahkemeKarari YerelMahkemeKarari {get; set;}
        [BindProperty]
        public DavaSonucu DavaSonucu { get; set; }
        [BindProperty]
        public DavaTuru DavaTuru { get; set; }
        [BindProperty]
        public ParaBirimi ParaBirimi { get; set; }
        [BindProperty]
        public Temyiz Temyiz { get; set; } 
       
        public async Task<IActionResult> OnGetAsync(int? davaKayitNo)
        {
            //if(davaKayitNo == null)
            //{
            //    return NotFound();
            //}

            var dava = await _db.Dava.FirstOrDefaultAsync( d => d.DavaKayitNo == davaKayitNo);
            var mahkemeKarari = await _db.YerelMahkemeKarari.FirstOrDefaultAsync(d => d.DavaKayitNo == davaKayitNo);
            var davaSonucu = await _db.DavaSonucu.FirstOrDefaultAsync(d => d.DavaKayitNo == davaKayitNo);
            var davaTuru = await _db.DavaTuru.FirstOrDefaultAsync(d => d.KayitNo == davaKayitNo);
            var ParaBirimi = await _db.ParaBirimi.FirstOrDefaultAsync(d => d.KayitNo == davaKayitNo);
            var Temyiz = await _db.Temyiz.FirstOrDefaultAsync(d => d.DavaKayitNo == davaKayitNo);
            ////if(dava == null)
            ////{
            ////    return NotFound();
            ////}

            //DavaTuru = await _db.DavaTuru.FindAsync(da)
            Dava = dava;
            YerelMahkemeKarari = mahkemeKarari;
            DavaSonucu = davaSonucu;
            return Page();
        }
    }
}

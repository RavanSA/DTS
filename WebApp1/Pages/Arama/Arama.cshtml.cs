using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApp1.Models;

namespace WebApp1.Pages.Arama
{
    [Authorize]
    public class AramaModel : PageModel
    {

        public readonly HukukDTSContext _db;
        public readonly IConfiguration _configuration;

        public AramaModel(HukukDTSContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public IList<DavaListeleri> Dava { get; set;}

        public bool isListEmpty = false;

        public DateTime ilkTarih { get; set; }

        public DateTime sonTarih { get; set; }

        public string davaTurleri { get; set; }

        
        public async Task OnGetAsync(DateTime ilkTarih, DateTime sonTarih, string davaTurleri)
        {

            IQueryable<DavaListeleri> davaIQ = from d in _db.DavaListeleri select d;

            if (davaTurleri != null)
            {
                switch (davaTurleri)
                {
                    case "arasinda_acilan_davalar":
                        davaIQ = davaIQ.Where(s =>
                        (s.DavaTarihi >= ilkTarih && s.DavaTarihi <= sonTarih)
                        && (s.SonucTarihi == null));
                        isListEmpty = true;
                        break;
                    case "arasinda_sonuclanan_davalar":
                        davaIQ = davaIQ.Where(s =>
                        (s.SonucTarihi >= ilkTarih && s.SonucTarihi <= sonTarih));
                        isListEmpty = true;
                        break;
                    case "arasinda_lehe_sonuclanan_davalar":
                        davaIQ = davaIQ.Where(s =>
                        (s.SonucTarihi >= ilkTarih && s.SonucTarihi <= sonTarih)
                        && (s.DavaSonucu == "Lehte"));
                        isListEmpty = true;
                        break;
                    case "arasinda_aleyhe_sonuclanan_davalar":
                        davaIQ = davaIQ.Where(s =>
                       (s.SonucTarihi >= ilkTarih && s.SonucTarihi <= sonTarih)
                       && (s.DavaSonucu == "Aleyhte"));
                        isListEmpty = true;
                        break;
                }
            }

                Dava = await davaIQ.AsNoTracking().ToListAsync();
        }
    }
}

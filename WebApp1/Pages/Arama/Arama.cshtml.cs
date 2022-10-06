using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        public readonly UserManager<IdentityUser> _userManager;

        public AramaModel(
            HukukDTSContext db,
            IConfiguration configuration,
            UserManager<IdentityUser> userManager
            )
        {
            _db = db;
            _configuration = configuration;
            _userManager = userManager;
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

                var userInfo = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(userInfo);

                var detayliArama = new LogTable
                {
                    UserId = userInfo.Id,
                    UserEmail = userInfo.UserName,
                    LogTuru = "DETAYLI ARAMA",
                    LogDate = DateTime.Now,
                    Aciklama = $"{userInfo.UserName} isimli kullanýcý {DateTime.Now} tarihinde, {ilkTarih} ve {sonTarih} {davaTurleri}i sorguladý, Rol: {roles[0]}"
                };

               await _db.LogTable.AddAsync(detayliArama);
               await _db.SaveChangesAsync();

                Dava = await davaIQ.AsNoTracking().ToListAsync();
            }      
        }
    }
}

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
    public class DavaGuncelleModel : PageModel
    {
        public readonly HukukDTSContext _db;
        public readonly UserManager<IdentityUser> _userManager;
        public DavaGuncelleModel(HukukDTSContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [BindProperty]
        public Dava Dava { get; set; }

        [BindProperty]
        public YerelMahkemeKarari MahkemeKarari { get; set; }

        [BindProperty]
        public DavaSonucu DavaSonucu { get; set; }

        [BindProperty]
        public Temyiz Temyiz { get; set; }

        public async Task OnGetAsync(int id)
        {
            Dava = await _db.Dava.FindAsync(id);
            MahkemeKarari = await _db.YerelMahkemeKarari.FindAsync(id);
            DavaSonucu = await _db.DavaSonucu.FindAsync(id);
            Temyiz = await _db.Temyiz.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int davaKayitNo)
        {

            if (ModelState.IsValid)
            {
                var userInfo = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(userInfo);

                var davaDetay = new LogTable
                {
                    UserId = userInfo.Id,
                    UserEmail = userInfo.UserName,
                    LogTuru = "",
                    LogDate = DateTime.Now,
                    Aciklama = $"{userInfo.UserName} {DateTime.Now}  {davaKayitNo}  {roles[0]}"
                };


                //MahkemeKarari = await _db.YerelMahkemeKarari.FindAsync(davaKayitNo);
                //DavaSonucu = await _db.DavaSonucu.FindAsync(davaKayitNo);
                //Temyiz = await _db.Temyiz.FindAsync(davaKayitNo);

                //_db.Entry(Dava).State = EntityState.Modified;
                var dava = 
                    (from d in _db.Dava where d.DavaKayitNo == davaKayitNo select d).SingleOrDefault();

                dava.EsasNo = Dava.EsasNo;
                dava.DefterSiraNo = Dava.DefterSiraNo;
                dava.YargitayDosyaNo = Dava.YargitayDosyaNo;
                dava.DavaTarihi = Dava.DavaTarihi;
                dava.DavaTuruKayitNo = Dava.DavaTuruKayitNo;
                dava.DavaKonusu = Dava.DavaKonusu;
                dava.Lehte = Dava.Lehte;
                dava.SonucTahmini = Dava.SonucTahmini;
                dava.Mahkemesi = Dava.Mahkemesi;
                dava.DavaTutari = Dava.DavaTutari;
                dava.IslahDegeri = Dava.IslahDegeri;
                dava.ParaBirimiKayitNo = Dava.ParaBirimiKayitNo;
                dava.Davaci = Dava.Davaci;
                dava.Davali = Dava.Davali;
                dava.DigerDavacilar = Dava.DigerDavacilar;
                dava.DigerDavalilar = Dava.DigerDavalilar;
                dava.Aciklama = Dava.Aciklama;
                dava.OlusturulmaTarihi = Dava.OlusturulmaTarihi;
                dava.DegistirilmeTarihi = Dava.DegistirilmeTarihi;
                dava.OlusturanKisi = Dava.OlusturanKisi;
                dava.DegistirenKisi = Dava.DegistirenKisi;
                dava.DavaFormTipi = Dava.DavaFormTipi;


                var mahkemeKarari = await _db.YerelMahkemeKarari.FindAsync(davaKayitNo);
                var davaSonucu = await _db.DavaSonucu.FindAsync(davaKayitNo);
                var temyiz = await _db.Temyiz.FindAsync(davaKayitNo);
                if (mahkemeKarari == null && MahkemeKarari.KararNo != null)
                {
                    var insertMahkemeKarari = new YerelMahkemeKarari
                    {
                        DavaKayitNo = davaKayitNo,
                        KararNo = MahkemeKarari.KararNo,
                        KararTarihi = MahkemeKarari.KararTarihi,
                        KararSonucu = MahkemeKarari.KararSonucu,
                        KararOzeti = MahkemeKarari.KararOzeti
                    };

                    await _db.YerelMahkemeKarari.AddAsync(insertMahkemeKarari);
                }

                else if(mahkemeKarari != null)
                {
                    mahkemeKarari.KararNo = MahkemeKarari.KararNo;
                    mahkemeKarari.KararTarihi = MahkemeKarari.KararTarihi;
                    mahkemeKarari.KararOzeti = MahkemeKarari.KararOzeti;
                    mahkemeKarari.KararSonucu = MahkemeKarari.KararSonucu;
                }

                if (davaSonucu == null && DavaSonucu.KaldirmaNo != null)
                {
                    var insertDavaSonucu = new DavaSonucu
                    {
                        DavaKayitNo = davaKayitNo,
                        SonucTarihi = DavaSonucu.SonucTarihi,
                        KaldirmaNo = DavaSonucu.KaldirmaNo,
                        DavaSonucu1 = DavaSonucu.DavaSonucu1,
                        IcraSafhasi = DavaSonucu.IcraSafhasi,
                        AsilAlacak = DavaSonucu.AsilAlacak,
                        IslenmisFaiz = DavaSonucu.IslenmisFaiz,
                        MahkemeHarcveMasrafi = DavaSonucu.MahkemeHarcveMasrafi,
                        IcraMasraflari = DavaSonucu.IcraMasraflari,
                        VekaletUcretleri = DavaSonucu.VekaletUcretleri,
                        IcraVekaletUcreti = DavaSonucu.IcraVekaletUcreti,
                        OdemeTarihi = DavaSonucu.OdemeTarihi
                    };

                    await _db.DavaSonucu.AddAsync(insertDavaSonucu);
                }
                else if(davaSonucu != null)
                {
                    davaSonucu.SonucTarihi = DavaSonucu.SonucTarihi;
                    davaSonucu.KaldirmaNo = DavaSonucu.KaldirmaNo;
                    davaSonucu.DavaSonucu1 = DavaSonucu.DavaSonucu1;
                    davaSonucu.IcraSafhasi = DavaSonucu.IcraSafhasi;
                    davaSonucu.AsilAlacak = DavaSonucu.AsilAlacak;
                    davaSonucu.MahkemeHarcveMasrafi = DavaSonucu.MahkemeHarcveMasrafi;
                    davaSonucu.IcraMasraflari = DavaSonucu.IcraMasraflari;
                    davaSonucu.VekaletUcretleri = DavaSonucu.VekaletUcretleri;
                    davaSonucu.IcraVekaletUcreti = DavaSonucu.IcraVekaletUcreti;
                    davaSonucu.OdemeTarihi = DavaSonucu.OdemeTarihi;
                }

                if (temyiz == null && Temyiz.Aciklama != null)
                {
                    var insertTemyiz = new Temyiz
                    {
                        DavaKayitNo = davaKayitNo,
                        TemyizEdenPetkim = Temyiz.TemyizEdenPetkim,
                        TemyizTarihi = Temyiz.TemyizTarihi,
                        TemyizSonucu = Temyiz.TemyizSonucu,
                        Aciklama = Temyiz.Aciklama
                    };

                    await _db.Temyiz.AddAsync(insertTemyiz);
                }
                else if(temyiz != null)
                {
                    temyiz.TemyizEdenPetkim = Temyiz.TemyizEdenPetkim;
                    temyiz.TemyizTarihi = Temyiz.TemyizTarihi;
                    temyiz.TemyizSonucu = Temyiz.TemyizSonucu;
                    temyiz.Aciklama = Temyiz.Aciklama;
                }
                //_db.Entry(MahkemeKarari).State = await _db.YerelMahkemeKarari.FindAsync(davaKayitNo) == null
                //   ? EntityState.Added : EntityState.Modified;

                //_db.Entry(DavaSonucu).State = await _db.DavaSonucu.FindAsync(davaKayitNo) == null
                //    ? EntityState.Added : EntityState.Modified;

                //_db.Entry(Temyiz).State = await _db.Temyiz.FindAsync(davaKayitNo) == null
                //    ? EntityState.Added : EntityState.Modified;

                //await _db.LogTable.AddAsync(davaDetay);


                await _db.SaveChangesAsync();

                return RedirectToPage("/Davalar/Detay", new { davaKayitNo = davaKayitNo });
            }   

            return Page();
        }
    }
}

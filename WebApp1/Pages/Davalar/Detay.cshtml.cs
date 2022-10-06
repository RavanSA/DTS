using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Pages.Davalar
{
    [Authorize]
    public class DetayModel : PageModel
    {
        public readonly HukukDTSContext _db;
        public readonly UserManager<IdentityUser> _userManager;

        public DetayModel(HukukDTSContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
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
        [BindProperty]
        public List<DavaEki> DavaEki { get; set; }
        public string davaKayitNo { get; set; }
        public string dosyaAdi { get; set; }
       
        public async Task<IActionResult> OnGetAsync(int? davaKayitNo)
        {


            //var userInfo = await _userManager.GetUserAsync(User);
            //var roles = await _userManager.GetRolesAsync(userInfo);

            //var davaDetay = new LogTable
            //{
            //    UserId = userInfo.Id,
            //    UserEmail = userInfo.UserName,
            //    LogTuru = "DAVA DETAYÝ",
            //    LogDate = DateTime.Now,
            //    Aciklama = $"{userInfo.UserName} isimli kullanýcý {DateTime.Now} tarihinde {davaKayitNo} nolu dosyayý inceledi, Rol: {roles[0]}"
            //};

            //await _db.LogTable.AddAsync(davaDetay);
            //await _db.SaveChangesAsync();

            var dava = await _db.Dava.FirstOrDefaultAsync( d => d.DavaKayitNo == davaKayitNo);
            var mahkemeKarari = await _db.YerelMahkemeKarari.FirstOrDefaultAsync(d => d.DavaKayitNo == davaKayitNo);
            var davaSonucu = await _db.DavaSonucu.FirstOrDefaultAsync(d => d.DavaKayitNo == davaKayitNo);
            var davaTuru = await _db.DavaTuru.FirstOrDefaultAsync(d => d.KayitNo == davaKayitNo);
            var paraBirimi = await _db.ParaBirimi.FirstOrDefaultAsync(d => d.KayitNo == davaKayitNo);
            var temyiz = await _db.Temyiz.FirstOrDefaultAsync(d => d.DavaKayitNo == davaKayitNo);
            var davaEki = await _db.DavaEki.Where(d => d.DavaKayitNo == davaKayitNo).ToListAsync();

            Dava = dava;
            YerelMahkemeKarari = mahkemeKarari;
            DavaSonucu = davaSonucu;
            DavaTuru = davaTuru;
            ParaBirimi = paraBirimi;
            Temyiz = temyiz;
            DavaEki = davaEki;
            return Page();
        }


        public async Task<IActionResult> OnPostUploadFile(IFormFile dosya)
        {
            
            //var dosya = Request.Form["davaEki"];
            var davaKayitNo = Int32.Parse(Request.Form["davaKayitNo"]);
            string dosyaAdi = Path.GetFileName(dosya.FileName);
            string dosyaTuru = dosya.ContentType;

            
            var userInfo = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(userInfo);

            var davaDetay = new LogTable
            {
                UserId = userInfo.Id,
                UserEmail = userInfo.UserName,
                LogTuru = "DAVA EKÝ YUKLENDÝ",
                LogDate = DateTime.Now,
                Aciklama = $"{userInfo.UserName} isimli kullanýcý {DateTime.Now} tarihinde" +
                $" {davaKayitNo} nolu davanýn ekini yukledi, Rol: {roles[0]}"
            };

            using (MemoryStream stream = new MemoryStream())
            {
                dosya.CopyTo(stream);

                var davaEki = new DavaEki
                {
                    DavaKayitNo = davaKayitNo,
                    DosyaAdi = dosyaTuru,
                    Ek = stream.ToArray(),
                };


                _db.Entry(davaEki).State = EntityState.Added;
                await _db.LogTable.AddAsync(davaDetay);
               await _db.SaveChangesAsync();
            }

            return RedirectToPage("/Davalar/Detay", new { davaKayitNo = davaKayitNo });
        }

        public async Task<IActionResult> OnPostDeleteFile(int kayitNo, int davaKayitNo)
        {

            var files = _db.DavaEki.Find(kayitNo);

            var userInfo = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(userInfo);

            var davaDetay = new LogTable
            {
                UserId = userInfo.Id,
                UserEmail = userInfo.UserName,
                LogTuru = "DAVA EKÝ SÝLME",
                LogDate = DateTime.Now,
                Aciklama = $"{userInfo.UserName} isimli kullanýcý {DateTime.Now} tarihinde" +
                $" {davaKayitNo} nolu davanýn {kayitNo} nolu ekini sildi, Rol: {roles[0]}"
            };


            await _db.LogTable.AddAsync(davaDetay);
            _db.DavaEki.Remove(files);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Davalar/Detay", new { davaKayitNo = davaKayitNo });
        }

        public async Task<FileResult> OnGetDownloadFile(int dosyaId)
        {

            var davaEki =  _db.DavaEki.Find(dosyaId);
            
            byte [] ek = (byte[])davaEki.Ek;
            string dosyaTuru = davaEki.DosyaAdi.ToString();
            string fileExtension = "";


            if (dosyaTuru == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                fileExtension = ".xlsx";
            }
            else if (dosyaTuru == "image/png")
            {
                fileExtension = ".png";
            }
            else if (dosyaTuru == "image/jpg")
            {
                fileExtension = ".jpg";
            }
            else if (dosyaTuru == "text/plain")
            {
                fileExtension = ".txt";
            }
            else if (dosyaTuru == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            {
                fileExtension = ".doc";
            }
            else if ( dosyaTuru == "application/pdf")
            {
                fileExtension = ".pdf";
            }

            string utcNow = System.DateTime.Now.ToString();


            var userInfo = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(userInfo);

            var davaDetay = new LogTable
            {
                UserId = userInfo.Id,
                UserEmail = userInfo.UserName,
                LogTuru = "DAVA EKI INDIRILDI",
                LogDate = DateTime.Now,
                Aciklama = $"{userInfo.UserName} isimli kullanýcý {DateTime.Now} tarihinde" +
                $" {davaKayitNo} nolu davanýn {dosyaId} nolu ekini indirdi, Rol: {roles[0]}"
            };


            await _db.LogTable.AddAsync(davaDetay);


            return File(ek, dosyaTuru, $"EK-{dosyaId}-{utcNow}{fileExtension}");
        }
    }
}

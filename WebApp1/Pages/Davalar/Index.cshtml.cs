using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ClosedXML.Excel;  
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApp1.Pages.Davalar
{
    public class IndexModel : PageModel
    {
        private readonly HukukDTSContext _db;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(HukukDTSContext db, 
            IConfiguration configuration,
            UserManager<IdentityUser> userManager)
        {
            _db = db;
            _configuration = configuration;
            _userManager = userManager;
        }

        public string DavaKayitNoSort { get; set; }
        public string DavaTarihiSort { get; set; }
        public string EsasNoSort { get; set; }
        public string YargitayDosyaNoSort { get; set; }
        public string OlusturulmaTarihiSort { get; set; }
        public string KararNoSort { get; set; }
        public string TemyizDurumuSort{ get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<WebApp1.Models.DavaListeleri> Dava{ get; set; }
            

        public async Task<IActionResult> OnGetAsync(string sortOrder, string currentFilter, 
            string searchString, int? pageIndex) {

                                                                                                                                                                                                                                                                                                                        
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var userInfo = await _userManager.GetUserAsync(User);
            

            CurrentSort = sortOrder;

            DavaKayitNoSort = String.IsNullOrEmpty(sortOrder) ? "dava_kayit_desc" : "dava_kayit_asc";
            DavaTarihiSort = sortOrder == "Date" ? "date_desc" : "Date";
            EsasNoSort = String.IsNullOrEmpty(sortOrder) ? "esas_no_sort" : "";
            YargitayDosyaNoSort = String.IsNullOrEmpty(sortOrder) ? "yargi_dosya_no" : "";
            OlusturulmaTarihiSort = sortOrder == "date_olusturma" ? "date_olusturma_desc" : "date_olusturma";
            KararNoSort = String.IsNullOrEmpty(sortOrder) ? "karar_no" : "";
            TemyizDurumuSort = String.IsNullOrEmpty(sortOrder) ? "temyiz_durumu" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            } else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<DavaListeleri> davaIQ = from d in _db.DavaListeleri select d;


            if(!String.IsNullOrEmpty(searchString)) 
            {   

                davaIQ = davaIQ.Where(s => s.DavaKayitNo.ToString().Contains(searchString)
                                            || s.EsasNo.Contains(searchString)
                                            || s.YargitayDosyaNo.Contains(searchString)
                                            || s.TemyizDurumu.Contains(searchString)
                                            || s.KaldirmaNo.Contains(searchString)
                                            || s.KararNo.Contains(searchString));
                
            }       


            switch (sortOrder)
            {
                case "dava_kayit_asc": 
                    davaIQ = davaIQ.OrderBy(s => s.DavaKayitNo);
                    break;
                case "temyiz_durumu":
                    davaIQ = davaIQ.OrderBy(s => s.TemyizDurumu);
                    break;
                case "dava_kayit_desc":
                    davaIQ = davaIQ.OrderByDescending(s => s.DavaKayitNo);
                    break;
                case "esas_no_sort":
                    davaIQ = davaIQ.OrderByDescending(s => s.EsasNo);
                    break;
                case "yargi_dosya_no":
                    davaIQ = davaIQ.OrderByDescending(s => s.YargitayDosyaNo);
                    break;
                case "date_olusturma":
                    davaIQ = davaIQ.OrderBy(s => s.OlusturulmaTarihi);
                    break;
                case "date_desc":
                    davaIQ = davaIQ.OrderByDescending(s => s.DavaTarihi);
                    break;
                case "Date":
                    davaIQ = davaIQ.OrderBy(s => s.DavaTarihi);
                    break;
                case "karar_no":
                    davaIQ = davaIQ.OrderByDescending(s => s.KararNo);
                    break;
                default:    
                    davaIQ = davaIQ.OrderByDescending(s => s.OlusturulmaTarihi);
                    break;
            }

            var pageSize = _configuration.GetValue("PageSize", 6);

            Dava = await PaginatedList<DavaListeleri>.CreateAsync(davaIQ.AsNoTracking(),
                pageIndex ?? 1, 13);
            return Page();
        }

        public async Task<FileResult> OnPostExport()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[36] {
               new DataColumn("Dava Kay�t No"),
               new DataColumn("Esas No"),
               new DataColumn("Defter Sira No"),
               new DataColumn("Yarg�tay Dosya No"),
               new DataColumn("Dava Tarihi"),
               new DataColumn("Dava Konusu"),
               new DataColumn("Dava Acilma Turu"),
               new DataColumn("Sonuc Tahmini"),
               new DataColumn("Mahkemesi"),
               new DataColumn("DavaTutari"),
               new DataColumn("�slah Degeri"),
               new DataColumn("Davaci"),
               new DataColumn("Davali"),
               new DataColumn("DigerDavacilar"),
               new DataColumn("DigerDavalilar"),
               new DataColumn("Aciklama"),
               new DataColumn("Olusturulma Tarihi"),
               new DataColumn("Degistirilme Tarihi"),
               new DataColumn("Olusturan Kisi"),
               new DataColumn("Degistiren Kisi"),
               new DataColumn("Dava Form Tipi"),
               new DataColumn("Temyiz Durumu"),
               new DataColumn("Dava Turu"),
               new DataColumn("Para Birim"),
               new DataColumn("Karar No"),
               new DataColumn("Karar Tarihi"),
               new DataColumn("Karar Sonucu"),
               new DataColumn("Karar Ozeti"),
               new DataColumn("Temyiz Eden"),
               new DataColumn("Temyiz Tarihi"),
               new DataColumn("Temyiz Sonucu"),
               new DataColumn("Temyiz Aciklamasi"),
               new DataColumn("Sonuc Tarihi"),
               new DataColumn("Kaldirma No"),
               new DataColumn("Dava Sonucu"),
               new DataColumn("Icra Safhasi"),

            });

            var davalar = from d in _db.DavaListeleri select d;

            foreach( var dava in davalar)
            {
                dt.Rows.Add(
                    dava.DavaKayitNo, 
                    dava.EsasNo,
                    dava.DefterSiraNo,
                    dava.YargitayDosyaNo,
                    dava.DavaTarihi,
                    dava.DavaKonusu,
                    dava.DavaAcilmaTuru,
                    dava.SonucTahmini, 
                    dava.Mahkemesi,
                    dava.DavaTutari,
                    dava.IslahDegeri,
                    dava.Davaci,
                    dava.Davali,
                    dava.DigerDavacilar,
                    dava.DigerDavalilar,
                    dava.Aciklama,
                    dava.OlusturulmaTarihi,
                    dava.DegistirilmeTarihi,
                    dava.OlusturanKisi,
                    dava.DegistirenKisi,
                    dava.DavaFormTipi,
                    dava.TemyizDurumu,
                    dava.DavaTuruTanim,
                    dava.ParaBirimiKodu,
                    dava.KararNo,
                    dava.KararTarihi,
                    dava.KararSonucu,
                    dava.KararOzeti,
                    dava.TemyizEden,
                    dava.TemyizTarihi,
                    dava.TemyizAciklamasi,
                    dava.SonucTarihi,
                    dava.KaldirmaNo,
                    dava.DavaSonucu,
                    dava.IcraSafhasi
                    );

            }

            using(XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using( MemoryStream stream = new MemoryStream())
                {


                    var userInfo = await _userManager.GetUserAsync(User);
                    var roles = await _userManager.GetRolesAsync(userInfo);

                    var davaDetay = new LogTable
                    {
                        UserId = userInfo.Id,
                        UserEmail = userInfo.UserName,
                        LogTuru = "TUM DAVALAR EXCELE DONUSTURULDU",   
                        LogDate = DateTime.Now,
                        Aciklama = $"{userInfo.UserName} isimli kullan�c� {DateTime.Now} tarihinde tum davalari excele donusturdu, Rol: {roles[0]}"
                    };

                    await _db.LogTable.AddAsync(davaDetay);
                    await _db.SaveChangesAsync();
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dava_list.xlsx");
                }
            }
        }
    }
}   
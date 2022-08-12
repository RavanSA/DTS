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

namespace WebApp1.Pages.Davalar
{
    public class IndexModel : PageModel
    {
        private readonly HukukDTSContext _db;
        private readonly IConfiguration _configuration;
        public IndexModel(HukukDTSContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public string DavaKayitNoSort { get; set; }
        public string DavaTarihiSort { get; set; }
        public string EsasNoSort { get; set; }
        public string DefterSiraNoSort { get; set; }
        public string YargitayDosyaNoSort { get; set; }
        public string DavaTutariSort { get; set; }
        public string IslahDegeriSort { get; set; }
        
        public string OlusturulmaTarihiSort { get; set; }
        public string KararNoSort { get; set; }
        public string TemyizTarihiSort{ get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<WebApp1.Models.DavaListeleri> Dava{ get; set; }
            

        public async Task OnGetAsync(string sortOrder, string currentFilter, 
            string searchString, int? pageIndex){

            CurrentSort = sortOrder;

            DavaKayitNoSort = String.IsNullOrEmpty(sortOrder) ? "dava_kayit_desc" : "";
            DavaTarihiSort = sortOrder == "Date" ? "date_desc" : "Date";
            EsasNoSort = String.IsNullOrEmpty(sortOrder) ? "esas_no_sort" : "";
            DefterSiraNoSort = String.IsNullOrEmpty(sortOrder) ? "defter_sira_no" : "";
            YargitayDosyaNoSort = String.IsNullOrEmpty(sortOrder) ? "yargi_dosya_no" : "";
            DavaTutariSort = String.IsNullOrEmpty(sortOrder) ? "dava_tutar" : "";
            IslahDegeriSort = String.IsNullOrEmpty(sortOrder) ?  "islah_degeri" : "";
            OlusturulmaTarihiSort = sortOrder == "date_olusturma" ? "date_olusturma_desc" : "date_olusturma";
            KararNoSort = String.IsNullOrEmpty(sortOrder) ? "karar_no" : "";
            TemyizTarihiSort = sortOrder == "date_temyiz" ? "date_temyiz_desc" : "date_temyiz";

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
                                            || s.DefterSiraNo.Contains(searchString)
                                            || s.YargitayDosyaNo.Contains(searchString)
                                            || s.KararNo.Contains(searchString));
                
            }       


            switch (sortOrder)
            {   
                case "dava_kayit_desc":
                    davaIQ = davaIQ.OrderByDescending(s => s.DavaKayitNo);
                    break;
                case "esas_no_sort":
                        davaIQ = davaIQ.OrderByDescending(s => s.EsasNo);
                    break;
                case "defter_sira_no":
                    davaIQ = davaIQ.OrderByDescending(s => s.DefterSiraNo);
                    break;
                case "yargi_dosya_no":
                    davaIQ = davaIQ.OrderByDescending(s => s.YargitayDosyaNo);
                    break;
                case "dava_tutar":
                    davaIQ = davaIQ.OrderByDescending(s => s.DavaTutari);
                    break;
                case "islah_degeri":
                    davaIQ = davaIQ.OrderByDescending(s => s.IslahDegeri);
                    break;
                case "date_olusturma":
                    davaIQ = davaIQ.OrderBy(s => s.OlusturulmaTarihi);
                    break;
                case "date_olusturma_desc":
                    davaIQ = davaIQ.OrderByDescending(s => s.OlusturulmaTarihi);
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
                case "date_temyiz_desc":
                    davaIQ = davaIQ.OrderByDescending(s => s.TemyizTarihi);
                    break;
                case "date_temyiz":
                    davaIQ = davaIQ.OrderByDescending(s => s.TemyizTarihi);
                    break;
                default:    
                    davaIQ = davaIQ.OrderByDescending(s => s.DegistirilmeTarihi);
                    break;
            }

            var pageSize = _configuration.GetValue("PageSize", 4);

            Dava = await PaginatedList<DavaListeleri>.CreateAsync(davaIQ.AsNoTracking(),
                pageIndex ?? 1, pageSize);
        }
    }
}   
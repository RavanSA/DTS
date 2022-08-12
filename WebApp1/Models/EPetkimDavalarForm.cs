using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class EPetkimDavalarForm
    {
        public string Id { get; set; }
        public string Ruser { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Fdate { get; set; }
        public int? Status { get; set; }
        public int? Version { get; set; }
        public DateTime? Lastchange { get; set; }
        public int? Followstatus { get; set; }
        public string Processlink { get; set; }
        public string Linkdesc { get; set; }
        public string Flow { get; set; }
        public string EsasNo { get; set; }
        public DateTime? DavaTarihi { get; set; }
        public string Davaci { get; set; }
        public string Davali { get; set; }
        public string MahkemeAdi { get; set; }
        public decimal? LeheDavaninDegeri { get; set; }
        public string KararinOzeti { get; set; }
        public DateTime? KararTarihi { get; set; }
        public string KararNumarasi { get; set; }
        public DateTime? TemyizTarihi { get; set; }
        public string TemyizNumarasi { get; set; }
        public string Aciklamasi { get; set; }
        public string DavaciVekili { get; set; }
        public string TemyizAciklamasi { get; set; }
        public string FormNo { get; set; }
        public string KaldirmaNo { get; set; }
        public string MahkemeTipi { get; set; }
        public string MahkemeTipiText { get; set; }
        public string YeniDavaOzeti { get; set; }
        public string Metin1 { get; set; }
        public string DavaVekili { get; set; }
        public string Metin2 { get; set; }
        public decimal? AleyheDavaninDegeri { get; set; }
        public DateTime? DavaSonucuTarihi { get; set; }
        public string DefterSiraNo { get; set; }
        public string DavaTar { get; set; }
        public string DavaOzeti { get; set; }
        public string Sonuc { get; set; }
        public string SonucText { get; set; }
        public int? TemyizEdildim { get; set; }
        public int? TemyizEdilmedim { get; set; }
        public decimal? IslahDegeri { get; set; }
        public string DavaYil { get; set; }
        public string DavaAy { get; set; }
        public string DavaGun { get; set; }
        public string DavaTurleri { get; set; }
        public string DavaTurleriText { get; set; }
        public string DigerDavali { get; set; }
        public string DigerDavacilar { get; set; }
        public string DigerDavalilar { get; set; }
        public int? Lehe { get; set; }
        public int? Aleyhe { get; set; }
    }
}

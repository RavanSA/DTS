using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public partial class Dava
    {
        public Dava()
        {
            DavaEki = new HashSet<DavaEki>();
        }

        public int DavaKayitNo { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string EsasNo { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string DefterSiraNo { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string YargitayDosyaNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DavaTarihi { get; set; }

        [Required]
        public int? DavaTuruKayitNo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string DavaKonusu { get; set; }

        public bool? Lehte { get; set; }
        public bool? SonucTahmini { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Mahkemesi { get; set; }
        public double? DavaTutari { get; set; }
        public double? IslahDegeri { get; set; }
        public int? ParaBirimiKayitNo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Davaci { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Davali { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string DigerDavacilar { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string DigerDavalilar { get; set; }
        [Required]
        [StringLength(8000, MinimumLength = 1)]
        public string Aciklama { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OlusturulmaTarihi { get; set; }
        [DataType(DataType.Date)]   
        public DateTime? DegistirilmeTarihi { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)] 
        public string OlusturanKisi { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string DegistirenKisi { get; set; }
        public int? DavaFormTipi { get; set; }
        public int? TopluDavaKayitNo { get; set; }
        public bool? TemyizEdildi { get; set; }
        
        public virtual DavaTuru? DavaTuruKayitNoNavigation { get; set; }
        public virtual ParaBirimi? ParaBirimiKayitNoNavigation { get; set; }
        public virtual DavaSonucu? DavaSonucu { get; set; }
        public virtual Temyiz? Temyiz { get; set; }
        public virtual YerelMahkemeKarari? YerelMahkemeKarari { get; set; }
        public virtual ICollection<DavaEki>? DavaEki { get; set; }
    }
}

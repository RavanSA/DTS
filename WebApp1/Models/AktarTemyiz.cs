using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class AktarTemyiz
    {
        public int? DavaKayitNo { get; set; }
        public int? IsPetkim { get; set; }
        public DateTime? TemyizTarihi { get; set; }
        public int? Sonuc { get; set; }
        public string TemyizAciklamasi { get; set; }
    }
}

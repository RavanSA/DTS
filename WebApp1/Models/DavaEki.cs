using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class DavaEki
    {
        public int KayitNo { get; set; }
        public int? DavaKayitNo { get; set; }
        public string DosyaAdi { get; set; }
        public byte[] Ek { get; set; }
        public int? SiraNo { get; set; }

        public virtual Dava DavaKayitNoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class DavaSonucu
    {
        public int DavaKayitNo { get; set; }
        public DateTime? SonucTarihi { get; set; }
        public string KaldirmaNo { get; set; }
        public bool? DavaSonucu1 { get; set; }
        public string IcraSafhasi { get; set; }
        public double? AsilAlacak { get; set; }
        public double? IslenmisFaiz { get; set; }
        public double? MahkemeHarcveMasrafi { get; set; }
        public double? IcraMasraflari { get; set; }
        public double? VekaletUcretleri { get; set; }
        public double? IcraVekaletUcreti { get; set; }
        public DateTime? OdemeTarihi { get; set; }

        public virtual Dava DavaKayitNoNavigation { get; set; }
    }
}

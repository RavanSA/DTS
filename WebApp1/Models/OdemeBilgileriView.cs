using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class OdemeBilgileriView
    {
        public string DavaKonusu { get; set; }
        public DateTime? SonucTarihi { get; set; }
        public bool? DavaSonucu { get; set; }
        public double Toplam { get; set; }
        public double? AsilAlacak { get; set; }
        public double? IslenmisFaiz { get; set; }
        public double? MahkemeHarcveMasrafi { get; set; }
        public double? IcraMasraflari { get; set; }
        public double? VekaletUcretleri { get; set; }
        public double? IcraVekaletUcreti { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public string EsasNo { get; set; }
        public string DefterSiraNo { get; set; }
        public DateTime? DavaTarihi { get; set; }
        public string IcraSafhasi { get; set; }
        public string KaldirmaNo { get; set; }
        public int DavaKayitNo { get; set; }
    }
}

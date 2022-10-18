using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public partial class DavaSonucu
    {   
        [ConcurrencyCheck]
        public int DavaKayitNo { get; set; }
        [ConcurrencyCheck]
        [DataType(DataType.Date)]
        public DateTime? SonucTarihi { get; set; }
        [StringLength(20, MinimumLength = 1)]
        public string KaldirmaNo { get; set; }
        public bool? DavaSonucu1 { get; set; }
        [StringLength(8000, MinimumLength =1)]
        public string IcraSafhasi { get; set; }
        public double? AsilAlacak { get; set; }
        public double? IslenmisFaiz { get; set; }
        public double? MahkemeHarcveMasrafi { get; set; }
        public double? IcraMasraflari { get; set; }
        public double? VekaletUcretleri { get; set; }
        public double? IcraVekaletUcreti { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public virtual Dava DavaKayitNoNavigation { get; set; }
    }
}

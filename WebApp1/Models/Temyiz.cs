using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public partial class Temyiz
    {
        [ConcurrencyCheck]
        public int DavaKayitNo { get; set; }
        [ConcurrencyCheck]
        public bool? TemyizEdenPetkim { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TemyizTarihi { get; set; }
        public bool? TemyizSonucu { get; set; }
        [StringLength(8000, MinimumLength =1)]
        public string Aciklama { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public virtual Dava? DavaKayitNoNavigation { get; set; }
    }
}

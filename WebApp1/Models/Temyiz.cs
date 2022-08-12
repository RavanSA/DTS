using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class Temyiz
    {
        public int DavaKayitNo { get; set; }
        public bool? TemyizEdenPetkim { get; set; }
        public DateTime? TemyizTarihi { get; set; }
        public bool? TemyizSonucu { get; set; }
        public string Aciklama { get; set; }

        public virtual Dava? DavaKayitNoNavigation { get; set; }
    }
}

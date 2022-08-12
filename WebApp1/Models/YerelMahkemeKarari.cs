using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class YerelMahkemeKarari
    {
        public int DavaKayitNo { get; set; }
        public string KararNo { get; set; }
        public DateTime? KararTarihi { get; set; }
        public bool? KararSonucu { get; set; }
        public string KararOzeti { get; set; }

        public virtual Dava? DavaKayitNoNavigation { get; set; }
    }
}

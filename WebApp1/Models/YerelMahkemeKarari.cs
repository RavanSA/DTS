using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public partial class YerelMahkemeKarari
    {   
        [ConcurrencyCheck]
        public int DavaKayitNo { get; set; }
        [ConcurrencyCheck]
        [StringLength(20, MinimumLength = 1)]
        public string KararNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime? KararTarihi { get; set; }
        public bool? KararSonucu { get; set; }
        [StringLength(8000, MinimumLength = 1)]
        public string KararOzeti { get; set; }
        public virtual Dava? DavaKayitNoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public partial class Temyiz
    {
        public int DavaKayitNo { get; set; }
        public bool? TemyizEdenPetkim { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TemyizTarihi { get; set; }
        public bool? TemyizSonucu { get; set; }
        [Required]
        [StringLength(8000, MinimumLength =1)]
        public string Aciklama { get; set; }

        public virtual Dava? DavaKayitNoNavigation { get; set; }
    }
}

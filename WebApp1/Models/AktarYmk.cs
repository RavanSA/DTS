using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class AktarYmk
    {
        public int? DavaKayitNo { get; set; }
        public int? KararNo { get; set; }
        public DateTime? KararTarihi { get; set; }
        public int? KararSonucu { get; set; }
        public string KararinOzeti { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class KolonIsimleri
    {
        public string TabloAdi { get; set; }
        public string KolonAdi { get; set; }
        public string KolonTakmaAdi { get; set; }
        public Guid RowId { get; set; }
    }
}

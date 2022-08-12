using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class ParaBirimi
    {
        public ParaBirimi()
        {
            Dava = new HashSet<Dava>();
        }

        public int KayitNo { get; set; }
        public string ParaBirimiKodu { get; set; }
        public string Tanimi { get; set; }
        public int? SiraNo { get; set; }

        public virtual ICollection<Dava>? Dava { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApp1.Models
{
    public partial class DavaTuru
    {
        public DavaTuru()
        {
            Dava = new HashSet<Dava>();
        }

        public int? KayitNo { get; set; }
        public string Tanim { get; set; }
        public int? SiraNo { get; set; }

        public virtual ICollection<Dava>? Dava { get; set; }
    }
}

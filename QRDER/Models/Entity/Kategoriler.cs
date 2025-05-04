using System;
using System.Collections.Generic;

#nullable disable

namespace QRDER.Models.Entity
{
    public partial class Kategoriler
    {
        public Kategoriler()
        {
            Tercihlers = new HashSet<Tercihler>();
        }

        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        public virtual ICollection<Tercihler> Tercihlers { get; set; }
    }
}

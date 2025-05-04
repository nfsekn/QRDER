using System;
using System.Collections.Generic;

#nullable disable

namespace QRDER.Models.Entity
{
    public partial class Tercihler
    {
        public int? KategoriId { get; set; }
        public int Id { get; set; }
        public string MenuAdi { get; set; }

        public virtual Kategoriler Kategori { get; set; }
    }
}

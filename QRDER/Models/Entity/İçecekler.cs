using System;
using System.Collections.Generic;

#nullable disable

namespace QRDER.Models.Entity
{
    public partial class İçecekler
    {
        public int Id { get; set; }
        public int? IdKategori { get; set; }
        public int? IdMenuKategori { get; set; }
        public string Tercihler { get; set; }
        public decimal? Fiyat { get; set; }
    }
}

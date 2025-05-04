using System;
using System.Collections.Generic;

#nullable disable

namespace QRDER.Models.Entity
{
    public partial class Tatlılar
    {
        public int Id { get; set; }
        public int? IdKategori { get; set; }
        public int IdMenuKategori { get; set; }
        public string TercihAdi { get; set; }
        public decimal? Fiyat { get; set; }
    }
}

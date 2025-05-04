using System;
using System.Collections.Generic;

#nullable disable

namespace QRDER.Models.Entity
{
    public partial class AraYemek
    {
        public int Id { get; set; }
        public int? KategoriId { get; set; }
        public int? MenuKategoriId { get; set; }
        public string TercihAdi { get; set; }
        public decimal? Fiyat { get; set; }
    }
}

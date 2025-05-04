using System;
using System.Collections.Generic;

#nullable disable

namespace QRDER.Models.Entity
{
    public partial class AnaYemek
    {
        public int Id { get; set; }
        public int Kategori { get; set; }
        public int MenuKategori { get; set; }
        public string TercihAdi { get; set; }
        public decimal? Fiyat { get; set; }
    }
}

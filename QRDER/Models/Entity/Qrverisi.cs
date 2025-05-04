using System;
using System.Collections.Generic;

#nullable disable

namespace QRDER.Models.Entity
{
    public partial class Qrverisi
    {
        public int Id { get; set; }
        public string Numara { get; set; }
        public byte[] Qrresim { get; set; }
    }
}

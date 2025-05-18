using System;
using System.Collections.Generic;

namespace Project__.Models.Data;

public partial class QrVerisi
{
    public int Id { get; set; }

    public string Numara { get; set; } = null!;

    public byte[]? Qrresim { get; set; }
}

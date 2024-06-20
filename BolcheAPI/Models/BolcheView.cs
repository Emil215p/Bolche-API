using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class BolcheView
{
    public string BolcheNavn { get; set; } = null!;

    public string? Farve { get; set; }

    public string? Surhed { get; set; }

    public string? Styrke { get; set; }

    public string? Smag { get; set; }

    public int? Price { get; set; }

    public int? Weight { get; set; }
}

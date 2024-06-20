using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class Test2
{
    public string BolcheNavn { get; set; } = null!;

    public string? BolcheTrait { get; set; }

    public int Weight { get; set; }

    public int Price { get; set; }
}

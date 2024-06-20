using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class DebugBolcheView
{
    public string BolcheNavn { get; set; } = null!;

    public string? BolcheType { get; set; }

    public string? TraitNames { get; set; }
}

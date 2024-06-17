using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class BolcheStat
{
    public int StatsId { get; set; }

    public string Name { get; set; } = null!;

    public string Unit { get; set; } = null!;
}

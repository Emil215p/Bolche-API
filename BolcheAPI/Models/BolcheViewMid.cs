﻿using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class BolcheViewMid
{
    public string BolcheNavn { get; set; } = null!;

    public string BolcheTrait { get; set; } = null!;

    public int Weight { get; set; }

    public int Price { get; set; }
}

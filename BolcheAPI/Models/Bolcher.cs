using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class Bolcher
{
    public int BolcheId { get; set; }

    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public virtual ICollection<Indkøbsvogn> Indkøbsvogns { get; set; } = new List<Indkøbsvogn>();

    public virtual BolcheType Type { get; set; } = null!;
}

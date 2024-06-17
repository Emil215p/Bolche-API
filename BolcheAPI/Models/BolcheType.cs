using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class BolcheType
{
    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Bolcher> Bolchers { get; set; } = new List<Bolcher>();
}

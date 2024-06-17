using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class Indkøbsvogn
{
    public int IndkøbsvognId { get; set; }

    public int BolcheId { get; set; }

    public int Mængde { get; set; }

    public virtual Bolcher Bolche { get; set; } = null!;

    public virtual ICollection<Ordre> Ordres { get; set; } = new List<Ordre>();
}

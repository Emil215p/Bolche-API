using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class BolcheTraitName
{
    public int TraitNameId { get; set; }

    public string TraitNames { get; set; } = null!;

    public virtual ICollection<BolcheTyper> BolcheTypers { get; set; } = new List<BolcheTyper>();
}

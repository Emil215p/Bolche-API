using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class ItemTrait
{
    public int BolcheId { get; set; }

    public int TraitTypeId { get; set; }

    public int StatsId { get; set; }

    public string Value { get; set; } = null!;

    public virtual Bolcher Bolche { get; set; } = null!;

    public virtual BolcheStat Stats { get; set; } = null!;

    public virtual TypeofTrait TraitType { get; set; } = null!;
}

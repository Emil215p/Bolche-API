using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class AssignedTrait
{
    public int? BolcheId { get; set; }

    public int? BolcheTypeId { get; set; }

    public virtual Bolcher? Bolche { get; set; }

    public virtual BolcheTyper? BolcheType { get; set; }
}

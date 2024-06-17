using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class Ordre
{
    public int OrdreId { get; set; }

    public int? KundeId { get; set; }

    public int IndkøbsvognId { get; set; }

    public int ForsendelsesInfoId { get; set; }

    public DateTime OrdreDato { get; set; }

    public virtual ForsendelsesInfo ForsendelsesInfo { get; set; } = null!;

    public virtual Indkøbsvogn Indkøbsvogn { get; set; } = null!;

    public virtual Kunder? Kunde { get; set; }
}

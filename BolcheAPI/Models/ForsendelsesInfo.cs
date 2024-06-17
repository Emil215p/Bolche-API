using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class ForsendelsesInfo
{
    public int ForsendelsesInfoId { get; set; }

    public string Adresse { get; set; } = null!;

    public int Postnummer { get; set; }

    public string ByNavn { get; set; } = null!;

    public virtual ICollection<Kunder> Kunders { get; set; } = new List<Kunder>();

    public virtual ICollection<Ordre> Ordres { get; set; } = new List<Ordre>();
}

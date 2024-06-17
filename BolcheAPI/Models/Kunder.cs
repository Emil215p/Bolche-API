using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class Kunder
{
    public int KundeId { get; set; }

    public string Navn { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Adgangskode { get; set; } = null!;

    public int? ForsendelsesInfoId { get; set; }

    public virtual ForsendelsesInfo? ForsendelsesInfo { get; set; }

    public virtual ICollection<Ordre> Ordres { get; set; } = new List<Ordre>();
}

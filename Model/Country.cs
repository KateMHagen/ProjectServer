using System;
using System.Collections.Generic;

namespace Model;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Iso2 { get; set; } = null!;

    public string Iso3 { get; set; } = null!;
}

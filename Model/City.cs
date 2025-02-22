using System;
using System.Collections.Generic;

namespace Model;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Population { get; set; }

    public int CountryId { get; set; }
}

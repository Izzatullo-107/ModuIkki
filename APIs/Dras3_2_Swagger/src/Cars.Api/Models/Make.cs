using System;
using System.Collections.Generic;

namespace Cars.Api.Models;

public partial class Make
{
    public int MakeId { get; set; }

    public string MakeName { get; set; } = null!;

    public string? MakeCountry { get; set; }

    public string? MakeLogoUrl { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}

using System;
using System.Collections.Generic;

namespace Cars.Api.Models;

public partial class Car
{
    public int CarId { get; set; }

    public int MakeId { get; set; }

    public string ModelName { get; set; } = null!;

    public short? Year { get; set; }

    public string? Color { get; set; }

    public decimal? EngineVolume { get; set; }

    public decimal Price { get; set; }

    public string? VinNumber { get; set; }

    public virtual Make Make { get; set; } = null!;

    public virtual Sale? Sale { get; set; }
}

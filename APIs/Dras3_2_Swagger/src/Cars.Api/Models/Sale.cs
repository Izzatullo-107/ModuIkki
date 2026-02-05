using System;
using System.Collections.Generic;

namespace Cars.Api.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int CarId { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly SaleDate { get; set; }

    public decimal FinalPrice { get; set; }

    public string? PaymentMethod { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}

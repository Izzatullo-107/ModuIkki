using System;
using System.Collections.Generic;

namespace Cars.Api.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? Oylik { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

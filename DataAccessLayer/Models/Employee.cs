using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public int EmpCode { get; set; }

    public virtual ICollection<Guard> Guards { get; } = new List<Guard>();
}

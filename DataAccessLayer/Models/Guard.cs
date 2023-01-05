using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Guard
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string TemporaryBadge { get; set; } = null!;

    public DateTime SignIn { get; set; }

    public DateTime SignOut { get; set; }

    public int EmpCode { get; set; }

    public virtual Employee EmpCodeNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class User
{
    public int PersonId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }
}

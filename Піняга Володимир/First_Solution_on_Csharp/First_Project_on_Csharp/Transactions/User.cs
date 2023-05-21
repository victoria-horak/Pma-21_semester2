using System;
using System.Collections.Generic;

namespace Transactions.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? Money { get; set; }
}

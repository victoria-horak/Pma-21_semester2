using System;
using System.Collections.Generic;

namespace DataBase.Entities;

public partial class UserTable
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }
}

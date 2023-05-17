using System;
using System.Collections.Generic;

namespace MVC.Entities;

public partial class Jobplace
{
    public int UserId { get; set; }

    public string Company { get; set; }

    public string Location { get; set; }

    public string Position { get; set; }

    // virtual ICollection<User> Users { get; set; } = new List<User>();

    public Jobplace()
    {
        UserId = 0;
        Company = string.Empty;
        Location = string.Empty;
        Position = string.Empty;
    }
    public override string ToString()
    {
        return "\nCompany: " + Company + "\nLocation: " + Location + "\nPosition: " + Position;
    }
}

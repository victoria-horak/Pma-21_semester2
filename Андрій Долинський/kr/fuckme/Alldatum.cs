using System;
using System.Collections.Generic;

namespace andrew.Models;

public partial class Alldatum
{
    public int AllDataId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Title { get; set; }

    public int? CountPage { get; set; }

    public string? JournalType { get; set; }

    public string? JournalTite { get; set; }
}

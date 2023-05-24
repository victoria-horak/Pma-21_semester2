using System;
using System.Collections.Generic;

namespace andrew.Models;

public partial class Book
{
    public int BookId { get; set; }

    public int? AuthorId { get; set; }

    public string? Title { get; set; }

    public int? CountPage { get; set; }

    public virtual Author? Author { get; set; }
}

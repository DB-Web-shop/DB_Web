using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class BookStatus
{
    public int Id { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

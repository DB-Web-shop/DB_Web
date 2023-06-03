using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class Category
{
    public int Id { get; set; }

    public string Tenloai { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

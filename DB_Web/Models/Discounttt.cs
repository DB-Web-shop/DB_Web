using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class Discounttt
{
    public string Magg { get; set; } = null!;

    public double Rate { get; set; }

    public bool? Stt { get; set; }

    public int? Soluong { get; set; }

    public virtual ICollection<Ordercart> Ordercarts { get; set; } = new List<Ordercart>();
}

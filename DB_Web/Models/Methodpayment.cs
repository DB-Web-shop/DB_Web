using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class Methodpayment
{
    public int Id { get; set; }

    public string? NameMethod { get; set; }

    public virtual ICollection<Ordercart> Ordercarts { get; set; } = new List<Ordercart>();
}

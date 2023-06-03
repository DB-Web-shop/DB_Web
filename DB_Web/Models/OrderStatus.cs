using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class OrderStatus
{
    public int Id { get; set; }

    public string DesStatus { get; set; } = null!;

    public virtual ICollection<Ordercart> Ordercarts { get; set; } = new List<Ordercart>();
}

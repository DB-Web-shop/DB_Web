using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class Cart
{
    public int AccountId { get; set; }

    public string? Spvsl { get; set; }

    public virtual Account Account { get; set; } = null!;
}

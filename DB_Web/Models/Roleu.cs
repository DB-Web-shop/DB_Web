using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class Roleu
{
    public string Id { get; set; } = null!;

    public string Rolename { get; set; } = null!;

    public string? Mota { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}

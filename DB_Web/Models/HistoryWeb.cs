using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class HistoryWeb
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string ActionHis { get; set; } = null!;

    public DateTime TimeHis { get; set; }

    public virtual Account Account { get; set; } = null!;
}

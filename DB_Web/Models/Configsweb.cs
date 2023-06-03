using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class Configsweb
{
    public int Id { get; set; }

    public string? Tenweb { get; set; }

    public string? DiachiDuong { get; set; }

    public string? DiachiThanhpho { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Facebook { get; set; }

    public string? Zalo { get; set; }

    public string? Instagram { get; set; }

    public string? Banner1 { get; set; }

    public string? Banner2 { get; set; }

    public string? Banner3 { get; set; }

    public string? Banner4 { get; set; }

    public bool? SystemStatus { get; set; }
}

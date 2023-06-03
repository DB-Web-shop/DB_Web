using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class Ordercart
{
    public int Id { get; set; }

    public string? Hoten { get; set; }

    public string? Phone { get; set; }

    public int AccountId { get; set; }

    public double Total { get; set; }

    public int? Stt { get; set; }

    public string Diachi { get; set; } = null!;

    public DateTime? Thoigian { get; set; }

    public string? Email { get; set; }

    public int? Method { get; set; }

    public double? TotalFirst { get; set; }

    public double? Phiship { get; set; }

    public string? Magg { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Discounttt? MaggNavigation { get; set; }

    public virtual Methodpayment? MethodNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderStatus? SttNavigation { get; set; }
}

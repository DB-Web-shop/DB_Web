using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class OrderDetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int Soluong { get; set; }

    public double Thanhtien { get; set; }

    public double? Giaban { get; set; }

    public int? SachId { get; set; }

    public virtual Ordercart? Order { get; set; }

    public virtual Book? Sach { get; set; }
}

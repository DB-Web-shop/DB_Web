using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class Book
{
    public int Id { get; set; }

    public string Tensach { get; set; } = null!;

    public string Dinhdang { get; set; } = null!;

    public double Trongluong { get; set; }

    public double Giaban { get; set; }

    public int CategoryId { get; set; }

    public int? Giamgia { get; set; }

    public int? StatusId { get; set; }

    public string? Image { get; set; }

    public DateTime? Ngaythem { get; set; }

    public int Soluong { get; set; }

    public int? Idtacgia { get; set; }

    public string? Mota { get; set; }

    public int? Daban { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Tacgia? IdtacgiaNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual BookStatus? Status { get; set; }
}

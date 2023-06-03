using System;
using System.Collections.Generic;

namespace DB_Web.Models;
[Serializable]
public partial class Account
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Hoten { get; set; }

    public string? Diachi { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Img { get; set; }

    public string? RoleId { get; set; }

    public int? Stt { get; set; }

    public DateTime? TimeSignup { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<HistoryWeb> HistoryWebs { get; set; } = new List<HistoryWeb>();

    public virtual ICollection<Ordercart> Ordercarts { get; set; } = new List<Ordercart>();

    public virtual Roleu? Role { get; set; }
}

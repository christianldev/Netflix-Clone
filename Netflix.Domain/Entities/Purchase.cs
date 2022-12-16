using System;
using System.Collections.Generic;

namespace Netflix.Domain.Entities;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int? ProviderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Total { get; set; }

    public int? State { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int? AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; } = new List<PurchaseDetail>();

    public virtual User? User { get; set; }
}

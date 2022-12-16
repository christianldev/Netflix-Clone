using System;
using System.Collections.Generic;

namespace Netflix.Domain.Entities;

public partial class Director
{
    public int DirectorId { get; set; }

    public string? Name { get; set; }

    public int? State { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int? AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}

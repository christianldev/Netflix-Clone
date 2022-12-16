using System;
using System.Collections.Generic;

namespace Netflix.Domain.Entities;

public partial class Movie
{
    public int MovieId { get; set; }

    public string? Title { get; set; }

    public int? IdCategory { get; set; }

    public int? IdDirector { get; set; }

    public int? Year { get; set; }

    public int? IdActor { get; set; }

    public int? Rating { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int? State { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int? AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public virtual Actor? IdActorNavigation { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Director? IdDirectorNavigation { get; set; }
}

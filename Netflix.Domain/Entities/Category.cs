using System;
using System.Collections.Generic;

namespace Netflix.Domain.Entities;

public partial class Category : BaseEntity
{


    public string? Name { get; set; }

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}

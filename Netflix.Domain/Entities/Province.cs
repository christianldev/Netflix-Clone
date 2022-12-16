﻿using System;
using System.Collections.Generic;

namespace Netflix.Domain.Entities;

public partial class Province
{
    public int ProvinceId { get; set; }

    public string Name { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int State { get; set; }

    public virtual ICollection<Country> Countries { get; } = new List<Country>();
}

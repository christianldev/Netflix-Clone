using System;
using System.Collections.Generic;

namespace Netflix.Domain.Entities;

public partial class BranchOffice
{
    public int BranchOfficeId { get; set; }

    public string Code { get; set; } = null!;

    public int BusinessId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CountryId { get; set; }

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int State { get; set; }

    public virtual Business Business { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}

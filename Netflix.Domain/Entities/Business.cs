using System;
using System.Collections.Generic;

namespace Netflix.Domain.Entities;

public partial class Business
{
    public int BusinessId { get; set; }

    public string Code { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string BusinessName { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public int CountryId { get; set; }

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public string Phone { get; set; } = null!;

    public string? Vision { get; set; }

    public string? Mision { get; set; }

    public int State { get; set; }

    public virtual ICollection<BranchOffice> BranchOffices { get; } = new List<BranchOffice>();

    public virtual Country Country { get; set; } = null!;
}

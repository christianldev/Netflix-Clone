using System;
using System.Collections.Generic;

namespace Netflix.Domain.Entities;

public partial class User : BaseEntity
{


    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Image { get; set; }


    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}

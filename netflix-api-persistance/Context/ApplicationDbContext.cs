using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using netflix_api_application.Interfaces;
using netflix_api_domain.Commons;
using netflix_api_domain.Entities;

namespace netflix_api_persistance.Context;

public class ApplicationDbContext : DbContext
{
    private readonly IDateTimeService _dateTimeService;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime)
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _dateTimeService = dateTime;
    }
    public DbSet<Customer> Customers { get; set; }


    // Metodo para guardar y sobreescribir los cambios en la base de datos con su fecha de creacion y modificacion
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = _dateTimeService.NowUtc;
                    entry.Entity.CreatedBy = "admin";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = _dateTimeService.NowUtc;
                    entry.Entity.LastModifiedBy = "admin";
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}
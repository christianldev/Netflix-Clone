using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netflix_api_domain.Entities;

namespace netflix_api_persistance.Configuration;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.UserName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Phone).HasMaxLength(10).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Password).HasMaxLength(100).IsRequired();
        builder.Property(p => p.BirthDate).IsRequired();
        builder.Property(p => p.Age);
        builder.Property(p => p.Status).HasDefaultValue('A');
        builder.Property(p => p.CreatedBy).HasMaxLength(30);
        builder.Property(p => p.LastModifiedBy).HasMaxLength(30);

    }
}

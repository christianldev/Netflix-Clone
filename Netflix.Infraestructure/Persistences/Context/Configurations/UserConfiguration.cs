using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netflix.Domain.Entities;

namespace Netflix.Infraestructure.Persistences.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Users__1788CC4C4BFA0114");
            builder.Property(e => e.Id).HasColumnName("UserId");


            builder.Property(e => e.Address).IsUnicode(false);
            builder.Property(e => e.Email).IsUnicode(false);
            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Image).IsUnicode(false);
            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Password).IsUnicode(false);
            builder.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.State).HasDefaultValueSql("((1))");
            builder.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
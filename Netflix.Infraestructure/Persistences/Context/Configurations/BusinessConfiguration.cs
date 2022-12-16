using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netflix.Domain.Entities;

namespace Netflix.Infraestructure.Persistences.Context.Configurations
{
    public class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(e => e.BusinessId).HasName("PK__Business__F1EAA36E56986442");

            builder.ToTable("Business");

            builder.Property(e => e.Address).IsUnicode(false);
            builder.Property(e => e.BusinessName)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CreationDate).HasColumnType("datetime");
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Logo).IsUnicode(false);
            builder.Property(e => e.Mision).IsUnicode(false);
            builder.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false);
            builder.Property(e => e.Vision).IsUnicode(false);

            builder.HasOne(d => d.Country).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Business__Countr__5165187F");
        }
    }
}
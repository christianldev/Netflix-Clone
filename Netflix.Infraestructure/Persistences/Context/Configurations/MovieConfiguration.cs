using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netflix.Domain.Entities;

namespace Netflix.Infraestructure.Persistences.Context.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2941A07787F2C");

            builder.Property(e => e.Description).IsUnicode(false);
            builder.Property(e => e.Image).IsUnicode(false);
            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdActorNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.IdActor)
                .HasConstraintName("FK__Movies__IdActor__00200768");

            builder.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Movies__IdCatego__7E37BEF6");

            builder.HasOne(d => d.IdDirectorNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.IdDirector)
                .HasConstraintName("FK__Movies__IdDirect__7F2BE32F");
        }
    }
}
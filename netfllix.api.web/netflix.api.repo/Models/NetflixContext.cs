using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using netflix.api.application.Table;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace netflix.api.repo.Models
{
    public partial class NetflixContext : DbContext
    {
        public NetflixContext()
        {
        }

        public NetflixContext(DbContextOptions<NetflixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerMovie> CustomerMovie { get; set; }
        public virtual DbSet<CustomerMovieCustomer> CustomerMovieCustomer { get; set; }
        public virtual DbSet<CustomerMovieMovie> CustomerMovieMovie { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=Netflix; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors>(entity =>
            {
                entity.ToTable("actors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.IdCountries).HasColumnName("id_countries");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(255);

                entity.Property(e => e.StreetAddress)
                    .HasColumnName("street_address")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContinentName)
                    .HasColumnName("continent_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__customer__AB6E616421726891")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__customer__F3DBC57238D77D1F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.IdAddress).HasColumnName("id_address");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.IdAddress)
                    .HasConstraintName("FK__customer__id_add__46E78A0C");
            });

            modelBuilder.Entity<CustomerMovie>(entity =>
            {
                entity.ToTable("customer_movie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdMovie).HasColumnName("id_movie");
            });

            modelBuilder.Entity<CustomerMovieCustomer>(entity =>
            {
                entity.HasKey(e => new { e.CustomerMovieIdCustomer, e.CustomerCustomerId })
                    .HasName("PK__customer__0318110B79354072");

                entity.ToTable("customer_movie_customer");

                entity.Property(e => e.CustomerMovieIdCustomer).HasColumnName("customer_movie_id_customer");

                entity.Property(e => e.CustomerCustomerId).HasColumnName("customer_customer_id");

                entity.HasOne(d => d.CustomerCustomer)
                    .WithMany(p => p.CustomerMovieCustomer)
                    .HasForeignKey(d => d.CustomerCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___custo__534D60F1");

                entity.HasOne(d => d.CustomerMovieIdCustomerNavigation)
                    .WithMany(p => p.CustomerMovieCustomer)
                    .HasForeignKey(d => d.CustomerMovieIdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___custo__52593CB8");
            });

            modelBuilder.Entity<CustomerMovieMovie>(entity =>
            {
                entity.HasKey(e => new { e.CustomerMovieIdMovie, e.MovieMovieId })
                    .HasName("PK__customer__70A57FD910AA2FD7");

                entity.ToTable("customer_movie_movie");

                entity.Property(e => e.CustomerMovieIdMovie).HasColumnName("customer_movie_id_movie");

                entity.Property(e => e.MovieMovieId).HasColumnName("movie_movie_id");

                entity.HasOne(d => d.CustomerMovieIdMovieNavigation)
                    .WithMany(p => p.CustomerMovieMovie)
                    .HasForeignKey(d => d.CustomerMovieIdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___custo__5629CD9C");

                entity.HasOne(d => d.MovieMovie)
                    .WithMany(p => p.CustomerMovieMovie)
                    .HasForeignKey(d => d.MovieMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___movie__571DF1D5");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("director");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasColumnName("genre_name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Genres)
                    .HasForeignKey<Genres>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__genres__id__4D94879B");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateMovie)
                    .HasColumnName("date_movie")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdActor).HasColumnName("id_actor");

                entity.Property(e => e.IdDirector).HasColumnName("id_director");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdActorNavigation)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.IdActor)
                    .HasConstraintName("FK__movie__id_actor__4F7CD00D");

                entity.HasOne(d => d.IdDirectorNavigation)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.IdDirector)
                    .HasConstraintName("FK__movie__id_direct__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CigarShop.DataAccess.Entities
{
    public partial class Project0Context : DbContext
    {
        public Project0Context()
        {
        }

        public Project0Context(DbContextOptions<Project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cigar> Cigar { get; set; }
        public virtual DbSet<CigarBodyChar> CigarBodyChar { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        // Unable to generate entity type for table 'Cigar.OrderItems'. Please see the warning messages.
        // Unable to generate entity type for table 'Cigar.InvintoryItem'. Please see the warning messages.

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Cigar>(entity =>
            {
                entity.ToTable("Cigar", "Cigar");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ManufacturerId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Body)
                    .WithMany(p => p.Cigar)
                    .HasForeignKey(d => d.BodyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cigar_CigarBodyChar");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Cigar)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cigar_Manufacturer");
            });

            modelBuilder.Entity<CigarBodyChar>(entity =>
            {
                entity.ToTable("CigarBodyChar", "Cigar");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Cigar");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaultStore)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer", "Cigar");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('unknown')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders", "Cigar");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatePlaced).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderTotal).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customer");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Cigar");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}

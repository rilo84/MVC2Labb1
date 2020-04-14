﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC2Labb2.Models
{
    public partial class sakilaContext : DbContext
    {
        public sakilaContext()
        {
        }

        public sakilaContext(DbContextOptions<sakilaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerList> CustomerList { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmActor> FilmActor { get; set; }
        public virtual DbSet<FilmCategory> FilmCategory { get; set; }
        public virtual DbSet<FilmList> FilmList { get; set; }
        public virtual DbSet<FilmText> FilmText { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Rental> Rental { get; set; }
        public virtual DbSet<SalesByFilmCategory> SalesByFilmCategory { get; set; }
        public virtual DbSet<SalesByStore> SalesByStore { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StaffList> StaffList { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=sakila;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActorId)
                    .HasName("PK__actor__8B2447B533DA5FF1")
                    .IsClustered(false);

                entity.HasIndex(e => e.LastName)
                    .HasName("idx_actor_last_name");

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__address__CAA247C9CB35C940")
                    .IsClustered(false);

                entity.HasIndex(e => e.CityId)
                    .HasName("idx_fk_city_id");

                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.District).IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_address_city");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__category__D54EE9B51195E903")
                    .IsClustered(false);

                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__city__031491A938281FFD")
                    .IsClustered(false);

                entity.HasIndex(e => e.CountryId)
                    .HasName("idx_fk_country_id");

                entity.Property(e => e.City1).IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_city_country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__country__7E8CD0541AC759E2")
                    .IsClustered(false);

                entity.Property(e => e.Country1).IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__customer__CD65CB84AF9E2DCA")
                    .IsClustered(false);

                entity.HasIndex(e => e.AddressId)
                    .HasName("idx_fk_address_id");

                entity.HasIndex(e => e.LastName)
                    .HasName("idx_last_name");

                entity.HasIndex(e => e.StoreId)
                    .HasName("idx_fk_store_id");

                entity.Property(e => e.Active)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_address");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_store");
            });

            modelBuilder.Entity<CustomerList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("customer_list");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.FilmId)
                    .HasName("PK__film__349764A83ACA1969")
                    .IsClustered(false);

                entity.HasIndex(e => e.LanguageId)
                    .HasName("idx_fk_language_id");

                entity.HasIndex(e => e.OriginalLanguageId)
                    .HasName("idx_fk_original_language_id");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rating)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('G')");

                entity.Property(e => e.ReleaseYear).IsUnicode(false);

                entity.Property(e => e.RentalDuration).HasDefaultValueSql("((3))");

                entity.Property(e => e.RentalRate).HasDefaultValueSql("((4.99))");

                entity.Property(e => e.ReplacementCost).HasDefaultValueSql("((19.99))");

                entity.Property(e => e.SpecialFeatures).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.FilmLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_language");

                entity.HasOne(d => d.OriginalLanguage)
                    .WithMany(p => p.FilmOriginalLanguage)
                    .HasForeignKey(d => d.OriginalLanguageId)
                    .HasConstraintName("fk_film_language_original");
            });

            modelBuilder.Entity<FilmActor>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.FilmId })
                    .HasName("PK__film_act__086D31FFE97CB313")
                    .IsClustered(false);

                entity.HasIndex(e => e.ActorId)
                    .HasName("idx_fk_film_actor_actor");

                entity.HasIndex(e => e.FilmId)
                    .HasName("idx_fk_film_actor_film");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.FilmActor)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_actor_actor");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmActor)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_actor_film");
            });

            modelBuilder.Entity<FilmCategory>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CategoryId })
                    .HasName("PK__film_cat__69C38A331444D72F")
                    .IsClustered(false);

                entity.HasIndex(e => e.CategoryId)
                    .HasName("idx_fk_film_category_category");

                entity.HasIndex(e => e.FilmId)
                    .HasName("idx_fk_film_category_film");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.FilmCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_category_category");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmCategory)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_category_film");
            });

            modelBuilder.Entity<FilmList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("film_list");

                entity.Property(e => e.Actors).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.Rating).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<FilmText>(entity =>
            {
                entity.HasKey(e => e.FilmId)
                    .HasName("PK__film_tex__349764A8E65BD265")
                    .IsClustered(false);

                entity.Property(e => e.FilmId).ValueGeneratedNever();

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId)
                    .HasName("PK__inventor__B59ACC48B839E739")
                    .IsClustered(false);

                entity.HasIndex(e => e.FilmId)
                    .HasName("idx_fk_film_id");

                entity.HasIndex(e => new { e.StoreId, e.FilmId })
                    .HasName("idx_fk_film_id_store_id");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_film");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_store");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.LanguageId)
                    .HasName("PK__language__804CF6B26B588760")
                    .IsClustered(false);

                entity.Property(e => e.LanguageId).ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__payment__ED1FC9EB03F8C291")
                    .IsClustered(false);

                entity.HasIndex(e => e.CustomerId)
                    .HasName("idx_fk_customer_id");

                entity.HasIndex(e => e.StaffId)
                    .HasName("idx_fk_staff_id");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_payment_customer");

                entity.HasOne(d => d.Rental)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.RentalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_payment_rental");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_payment_staff");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => e.RentalId)
                    .HasName("PK__rental__67DB611AF0C335D0")
                    .IsClustered(false);

                entity.HasIndex(e => e.CustomerId)
                    .HasName("idx_fk_customer_id");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("idx_fk_inventory_id");

                entity.HasIndex(e => e.StaffId)
                    .HasName("idx_fk_staff_id");

                entity.HasIndex(e => new { e.RentalDate, e.InventoryId, e.CustomerId })
                    .HasName("idx_uq")
                    .IsUnique();

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rental)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rental_customer");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Rental)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rental_inventory");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Rental)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rental_staff");
            });

            modelBuilder.Entity<SalesByFilmCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("sales_by_film_category");

                entity.Property(e => e.Category).IsUnicode(false);
            });

            modelBuilder.Entity<SalesByStore>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("sales_by_store");

                entity.Property(e => e.Manager).IsUnicode(false);

                entity.Property(e => e.Store).IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__staff__1963DD9D81542EBB")
                    .IsClustered(false);

                entity.HasIndex(e => e.AddressId)
                    .HasName("idx_fk_address_id");

                entity.HasIndex(e => e.StoreId)
                    .HasName("idx_fk_store_id");

                entity.Property(e => e.StaffId).ValueGeneratedOnAdd();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_staff_address");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_staff_store");
            });

            modelBuilder.Entity<StaffList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("staff_list");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__store__A2F2A30DC2BF0C42")
                    .IsClustered(false);

                entity.HasIndex(e => e.AddressId)
                    .HasName("idx_fk_store_address");

                entity.HasIndex(e => e.ManagerStaffId)
                    .HasName("idx_fk_address_id")
                    .IsUnique();

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_address");

                entity.HasOne(d => d.ManagerStaff)
                    .WithOne(p => p.StoreNavigation)
                    .HasForeignKey<Store>(d => d.ManagerStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_staff");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

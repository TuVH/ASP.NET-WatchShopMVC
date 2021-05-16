﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Model
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartDetails> CartDetails { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Specifications> Specifications { get; set; }
        public virtual DbSet<Trademark> Trademark { get; set; }
        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.Property(e => e.Id).IsFixedLength();
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id).IsFixedLength();

                entity.Property(e => e.IdCartDetails).IsFixedLength();

                entity.Property(e => e.IdProduct).IsFixedLength();

                entity.HasOne(d => d.IdCartDetailsNavigation)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.IdCartDetails)
                    .HasConstraintName("FK_Cart_Cart_details");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Cart_Product");
            });

            modelBuilder.Entity<CartDetails>(entity =>
            {
                entity.Property(e => e.Id).IsFixedLength();

                entity.Property(e => e.IdProduct).IsFixedLength();
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).IsFixedLength();

                entity.Property(e => e.IdOrderDetails).IsFixedLength();

                entity.Property(e => e.IdUser).IsFixedLength();

                entity.HasOne(d => d.IdOrderDetailsNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdOrderDetails)
                    .HasConstraintName("FK_Order_Order_details");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.IdOrderDetails).IsFixedLength();

                entity.Property(e => e.DiscountCode).IsFixedLength();

                entity.Property(e => e.IntoMoney).IsFixedLength();

                entity.Property(e => e.ProductId).IsFixedLength();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Order_details_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.IdProduct).IsFixedLength();

                entity.Property(e => e.Evaluate).IsFixedLength();

                entity.Property(e => e.Price).IsFixedLength();

                entity.Property(e => e.SpecificationsId).IsFixedLength();

                entity.Property(e => e.TrademarkId).IsFixedLength();

                entity.HasOne(d => d.Specifications)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SpecificationsId)
                    .HasConstraintName("FK_Product_Specifications");

                entity.HasOne(d => d.Trademark)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.TrademarkId)
                    .HasConstraintName("FK_Product_Trademark");
            });

            modelBuilder.Entity<Specifications>(entity =>
            {
                entity.Property(e => e.IdSpecifications).IsFixedLength();

                entity.Property(e => e.CaseDepthApprox).IsFixedLength();

                entity.Property(e => e.CaseShape).IsFixedLength();

                entity.Property(e => e.ClaspType).IsFixedLength();

                entity.Property(e => e.Guarantee).IsFixedLength();

                entity.Property(e => e.MovementCalibre).IsFixedLength();

                entity.Property(e => e.PrimaryMaterial).IsFixedLength();

                entity.Property(e => e.StrapColour).IsFixedLength();

                entity.Property(e => e.StrapType).IsFixedLength();

                entity.Property(e => e.TrademarkId).IsFixedLength();

                entity.Property(e => e.Weight).IsFixedLength();

                entity.HasOne(d => d.Trademark)
                    .WithMany(p => p.Specifications)
                    .HasForeignKey(d => d.TrademarkId)
                    .HasConstraintName("FK_Specifications_Trademark");
            });

            modelBuilder.Entity<Trademark>(entity =>
            {
                entity.Property(e => e.IdTrademark).IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).IsFixedLength();

                entity.Property(e => e.PhoneNumber).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

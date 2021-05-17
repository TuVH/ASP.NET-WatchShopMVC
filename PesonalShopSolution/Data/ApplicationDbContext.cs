using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PesonalShopSolution.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Data
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

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartDetails> CartDetails { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Specification> Specification { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

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

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

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

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

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
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("Date_of_birth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasColumnName("User_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.IdBrand)
                    .HasName("PK_Trademark");

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.BrandName)
                    .HasColumnName("Brand_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCartDetails).HasColumnName("id_cart_details");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

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
                entity.ToTable("Cart_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.TotalMoney)
                    .HasColumnName("Total_money")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Cart_details_Product");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment1).HasColumnName("Comment");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Comment_Product");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Comment_AspNetUsers");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrderDetails).HasColumnName("id_order_details");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasMaxLength(128);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("Order_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdOrderDetailsNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdOrderDetails)
                    .HasConstraintName("FK_Order_Order_details");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Order_AspNetUsers");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.IdOrderDetails);

                entity.ToTable("Order_details");

                entity.Property(e => e.IdOrderDetails).HasColumnName("id_order_details");

                entity.Property(e => e.Amount)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DiscountCode)
                    .HasColumnName("Discount_code")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Order_details_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DetailDescription)
                    .HasColumnName("Detail_description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Evaluate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.IdSpecifications).HasColumnName("id_specifications");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode).HasColumnName("product_code");

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdBrand)
                    .HasConstraintName("FK_Product_Trademark");

                entity.HasOne(d => d.IdSpecificationsNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdSpecifications)
                    .HasConstraintName("FK_Product_Specification");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.IdSpecifications);

                entity.Property(e => e.IdSpecifications).HasColumnName("id_specifications");

                entity.Property(e => e.Colour).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.Shape).HasMaxLength(50);

                entity.Property(e => e.Warranty).HasMaxLength(50);

                entity.Property(e => e.Weight).HasMaxLength(50);

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Specification)
                    .HasForeignKey(d => d.IdBrand)
                    .HasConstraintName("FK_Specification_Trademark");
            });

        }

    }
}

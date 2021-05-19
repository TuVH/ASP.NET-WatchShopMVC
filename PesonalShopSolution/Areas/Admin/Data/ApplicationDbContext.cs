using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PesonalShopSolution.Areas.Admin.Models;
using PesonalShopSolution.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Data
{
    public class ApplicationDbContext : IdentityDbContext<AspNetUsers, AspNetRoles, int, AspNetUserClaims, AspNetUserRoles, AspNetUserLogins, AspNetRoleClaims, AspNetUserToken>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Specification> Specification { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AspNetRoleClaims>(builder =>
            {
                builder.HasOne(roleClaim => roleClaim.Role).WithMany(role => role.AspNetRoleClaims).HasForeignKey(roleClaim => roleClaim.RoleId);
                builder.ToTable("AspNetRoleClaim");
            });
            modelBuilder.Entity<AspNetRoles>(builder =>
            {
                builder.ToTable("AspNetRoles");
            });
            modelBuilder.Entity<AspNetUserClaims>(builder =>
            {
                builder.HasOne(userClaim => userClaim.User).WithMany(user => user.AspNetUserClaims).HasForeignKey(userClaim => userClaim.UserId);
                builder.ToTable("AspNetUserClaims");
            });
            modelBuilder.Entity<AspNetUserLogins>(builder =>
            {
                builder.HasOne(userLogin => userLogin.User).WithMany(user => user.AspNetUserLogins).HasForeignKey(userLogin => userLogin.UserId);
                builder.ToTable("AspNetUserLogins");
            });
            modelBuilder.Entity<AspNetUsers>(builder =>
            {
                builder.ToTable("AspNetUsers");
            });
            modelBuilder.Entity<AspNetUserRoles>(builder =>
            {
                builder.HasOne(userRole => userRole.Role).WithMany(role => role.AspNetUserRoles).HasForeignKey(userRole => userRole.RoleId);
                builder.HasOne(userRole => userRole.User).WithMany(user => user.AspNetUserRoles).HasForeignKey(userRole => userRole.UserId);
                builder.ToTable("AspNetUserRoles");
            });
            modelBuilder.Entity<AspNetUserToken>(builder =>
            {
                builder.HasOne(userToken => userToken.User).WithMany(user => user.AspNetUserTokens).HasForeignKey(userToken => userToken.UserId);
                builder.ToTable("AspNetUserToken");
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

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Cart_Product");
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

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.Shape).HasMaxLength(50);

                entity.Property(e => e.Warranty).HasMaxLength(50);

                entity.Property(e => e.Weight).HasMaxLength(50);

            });

        }

    }
}

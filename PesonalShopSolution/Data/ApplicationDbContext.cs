using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PesonalShopSolution.Models;


namespace PesonalShopSolution.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public virtual DbSet<Bill> Bill { get; set; }
        
        public virtual DbSet<BillDetails> BillDetails { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductHung> ProductHung { get; set; }
        public virtual DbSet<ProductHuy> ProductHuy { get; set; }
        public virtual DbSet<ProductKha> ProductKha { get; set; }
        public virtual DbSet<ProductLan> ProductLan { get; set; }
        public virtual DbSet<ProductLinh> ProductLinh { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BillDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BillId).HasColumnName("Bill_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BillDetai__Bill___5070F446");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BillDetai__Produ__5165187F");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
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

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Product__idCateg__02FC7413");
            });

            modelBuilder.Entity<ProductHung>(entity =>
            {
                entity.ToTable("Product_Hung");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProductHuy>(entity =>
            {
                entity.ToTable("Product_Huy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProductKha>(entity =>
            {
                entity.ToTable("Product_Kha");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProductLan>(entity =>
            {
                entity.ToTable("Product_Lan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProductLinh>(entity =>
            {
                entity.ToTable("Product_Linh");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasDefaultValueSql("((1))");
            });

        }


    
}
}

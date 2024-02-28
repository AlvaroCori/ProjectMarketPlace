using Microsoft.EntityFrameworkCore;
using ProjectMarketPlace.InternModels;

namespace ProjectMarketPlace.Models
{
    public partial class MarketPlaceDBContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public MarketPlaceDBContext(DbContextOptions<MarketPlaceDBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public MarketPlaceDBContext() {}
        public MarketPlaceDBContext(DbContextOptions<MarketPlaceDBContext> options) : base(options) {}
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserEntity> UserEntities { get; set; }
        public virtual DbSet<ProductEntity> ProductEntities { get; set; }
        public virtual DbSet<InventoryEntity> InventoryEntities { get; set; }
        public virtual DbSet<OrderEntity> OrderEntities { set; get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ProjectMarketPlace;User ID=sa;Password=sqlserver;TrustServerCertificate=True;");
            // optionsBuilder.UseSqlServer("Server=localhost;Database=MarketPlaceDB;User ID=sa;Password=Diego#123;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

/*

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__INVENTOR__3214EC27BC8F0FDC");

            entity.ToTable("INVENTORY");

            entity.HasIndex(e => e.IdProduct, "IX_INVENTORY_ID_PRODUCT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Balance).HasColumnName("BALANCE");
            entity.Property(e => e.IdProduct).HasColumnName("ID_PRODUCT");
            entity.Property(e => e.InDate)
                .HasColumnType("datetime")
                .HasColumnName("IN_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.OutDate)
                .HasColumnType("datetime")
                .HasColumnName("OUT_DATE");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_INVENTORY_PRODUCT");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("ORDER");

            entity.HasIndex(e => e.UserEntityId, "IX_ORDER_UserEntityId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Lastupdate)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATE");
            entity.Property(e => e.Name).HasColumnName("NAME");

            entity.HasOne(d => d.UserEntity).WithMany(p => p.Orders).HasForeignKey(d => d.UserEntityId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT__3214EC27597B7432");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CURRENCY");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USER");

            entity.HasIndex(e => e.UserCode, "IX_USER_USER_CODE")
                .IsUnique()
                .HasFilter("([USER_CODE] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(1000)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.UserCode)
                .HasMaxLength(50)
                .HasColumnName("USER_CODE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
 */